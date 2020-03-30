using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Veterinaros' na base de dados
    /// </summary>
    public class Veterinarios
    {
        //inicializar a lista de consultas
        public Veterinarios()
        {
            ListaDeConsultas = new HashSet<Consultas>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")] // not null
        [StringLength(40,ErrorMessage ="O {0} só pode ter´, no máximo, {1} caracteres.")] // 0 é sempre nome do atributo     1 é sempre parametro
        public string Nome { get; set; }
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        public string NumCedulaProf { get; set; }
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório")]
        public string Foto { get; set; }

        //lista de 'consultas' que o Veterinário está associado
        public ICollection<Consultas> ListaDeConsultas { get; set; }
    }

    
}
