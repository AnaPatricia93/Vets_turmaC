using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Veterinaros' na base de dados
    /// </summary>
    public class Veterinarios
    {
        /// <summary>
        /// PK da tabela
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome do veterinário
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Numero da cédula profissional em string
        /// </summary>
        public string NumCedulaProf { get; set; }
        /// <summary>
        /// Nome do ficheiro com foto
        /// </summary>
        public string Foto { get; set; }
    }
}
