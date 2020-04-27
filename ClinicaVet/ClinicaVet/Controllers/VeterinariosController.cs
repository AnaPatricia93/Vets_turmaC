﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVet.Data;
using ClinicaVet.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ClinicaVet.Controllers
{
    public class VeterinariosController : Controller
    {   
        /// <summary>
        /// este atributo representa uma referência à nossa base de dados
        /// </summary>
        private readonly VetsDB db;
        //recolhe nele os dados do servidor
        private readonly IWebHostEnvironment _caminho;
        //construtor
        public VeterinariosController(VetsDB context, IWebHostEnvironment caminho)
        {
            this.db = context;
            this._caminho = caminho;
        }

        // GET: Veterinarios - objeto devolvido de forma assincrona (acesso aos dados de forma assincrona)
        public async Task<IActionResult> Index()
        {
            //db.Veterinarios.ToListAsync() == SELECT * FROM VETERINARIOS
            //LINQ - Linguagem intermédia de query/pesquisa
            //Controlador do C# controla as nossas querys 
            return View(await db.Veterinarios.ToListAsync());
        }

        // GET: Veterinarios/Details/5
        /// <summary>
        /// Mostra os detalhes de um veterinário, usando Lazy Loading
        /// </summary>
        /// <param name="id">Valor da chave primária do Veterinário. Admite um valor null, por causa do sinal ?</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //vai a BD veterinarios e vai a procura da primeira ocorrencias
            // é uma forma diferente de escrever o comando SELCT
            // SELECT * FROM Veterinarios v WHERE v.ID = id
            //esta expressão é uma escrita em LINQ  - linguagem de Interrogação para Querys
            var veterinarios = await db.Veterinarios.FirstOrDefaultAsync(v => v.ID == id);
            if (veterinarios == null)
            {
                return RedirectToAction("Index");
            }

            return View(veterinarios);
        }


        // GET: Veterinarios/Details/5
        /// <summary>
        /// Mostra os detalhes de um veterinário, usando Eager Loading
        /// </summary>
        /// <param name="id">Valor da chave primária do Veterinário. Admite um valor null, por causa do sinal ?</param>
        /// <returns></returns>
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //é uma forma deiferente de escrever o seguinte comando
            /// Select * 
            /// FROM db.Veterinarios v, db.Consultas c, db.Animais a, db.Donos d
            /// WHERE c.VeterinarioFK=v.ID AND
            ///     c.AnimalFK=a.ID AND
            ///     a.AnimaisFK=d.ID AND
            ///     v.ID = id

            //esta expressão é escrita e, LINQ
            var veterinarios = await db.Veterinarios
                                        .Include(v => v.Consulta)
                                        .ThenInclude(a=> a.Animal)
                                        .ThenInclude(d => d.Dono)
                                        .FirstOrDefaultAsync(v => v.ID == id);

            if (veterinarios == null)
            {
                return RedirectToAction("Index");
            }

            return View(veterinarios);
        }





        // GET: Veterinarios/Create
        /// <summary>
        /// Invocar a view de criação de um novo veterinario
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Concretiza a escrita do novo veterinário
        /// </summary>
        /// <param name="veterinario">Dados do novo veterinário</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,NumCedulaProf,Foto")] Veterinarios veterinario, iFormFile fotoVet)
        {

            //processar imagem


            //vars auxiliares
            bool haFicheiro = false;
            string caminhoCompleto = "";


            //será q há imagem?
            if (fotoVet == null)
            {
                //o utilizador nao fez upload de um ficheiro
                veterinario.Foto = "avatar.jpg";
            }
            else
            {
                //existe fotografia, mas será boa?
                if(fotoVet.ContentType=="image/jpeg" || fotoVet.ContentType == "image/png")
                {//estamos perante uma boa foto
                    //temos de gerar um nome para o ficheiro
                    Guid g;
                    g = Guid.NewGuid();
                    //obter extensão do ficheiro
                    string extensao = Path.GetExtension(fotoVet.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extensao;
                    //onde guardar o ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\vets", nomeFicheiro);
                    //atribuir o nome do ficheiro ao Veterinário
                    veterinario.Foto = nomeFicheiro;
                    //marcar que existe uma fotografia
                    haFicheiro = true;
                }
                else
                {
                    //o ficheiro não é válido
                    veterinario.Foto= "avatar.jpg";
                }
            }


          
            try
            {
                {   // adiciona o novo veterinário à BD, mas na memória do servidor ASP .NET
                    db.Add(veterinario);

                    // consolida os dados no Servidor BD (commit)
                    await db.SaveChangesAsync();
                    //será que há foto para gravar?
                    if (haFicheiro)
                    {//ponteiro para espaço de alojamento no disco
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await fotoVet.CopyToAsync(stream);
                    }

                    //redireciona a acção para a View do Index
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                throw;
            }
            //ModelState - objeto interno do ASP.NET que avalia se os dados que vêm do browser estão corretos ou não
            if (ModelState.IsValid)


            // quando ocorre um erro, reenvio os dados do veterinário para a view de criação
            return View(veterinario);
        }



        // GET: Veterinarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {   // se o ID é null, é porque o meu utilizador está a testar a minha aplicação
                //return NotFound();
                //redireciono então para o método INDEX, deste mesmo controller
                return RedirectToAction("Index");
            }
            
            var veterinario = await db.Veterinarios.FindAsync(id);
            if (veterinario == null)
            {
                return RedirectToAction("Index");
            }
            return View(veterinario);
        }

        // POST: Veterinarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,NumCedulaProf,Foto")] Veterinarios veterinario)
        {
            if (id != veterinario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(veterinario);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinariosExists(veterinario.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        // GET: Veterinarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var veterinario = await db.Veterinarios
                .FirstOrDefaultAsync(v => v.ID == id);
            if (veterinario == null)
            {
                return RedirectToAction("Index");
            }

            return View(veterinario);
        }

        // POST: Veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinario = await db.Veterinarios.FindAsync(id);
            db.Veterinarios.Remove(veterinario);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // dado um certo ID pergunta se existe algum registo com esse ID dentro da BD
        private bool VeterinariosExists(int id)
        {
            return db.Veterinarios.Any(v => v.ID == id);
        }
    }
}
