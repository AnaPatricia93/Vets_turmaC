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
        [StringLength(40,ErrorMessage ="O {0} só pode ter, no máximo, {1} caracteres.")] // 0 é sempre nome do atributo     1 é sempre parametro
        // [A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        //vet-xxxxxx ---> a palavra VET, um hifen, seguido de 6 digitos
        [RegularExpression("vet-[0-9]{6}", ErrorMessage ="Deve introduzir a palavra 'vet-' (em minúsculas), seguido de 6 dígitos.")]
        [StringLength(10, ErrorMessage ="O {0} só pode ter, no máximo, 10 caracteres")]
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Nº da Cédula Profissional")]
        public string NumCedulaProf { get; set; }

        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório")]
        public string Foto { get; set; }

        /// <summary>
        /// lista de 'consultas' que o Veterinário está associado
        /// </summary>
        public virtual ICollection<Consultas> ListaDeConsultas { get; set; }
    }

    
}
