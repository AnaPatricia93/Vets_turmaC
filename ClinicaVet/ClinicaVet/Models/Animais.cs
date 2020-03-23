using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Animais' na base de dados
    /// </summary>
    public class Animais
    {
        /// <summary>
        /// Pk da tabela 
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// noem do animal
        /// </summary>
        public string Nome{ get; set; }
        /// <summary>
        /// Especie do animal
        /// </summary>
        public string Especie { get; set; }
        /// <summary>
        /// Peso do animal
        /// </summary>
        public float Peso { get; set; }
        /// <summary>
        /// raça do animal
        /// </summary>
        public string Raca { get; set; }
        /// <summary>
        /// Nome do ficheiro coma  fotografia do animal
        /// </summary>
        public string Foto { get; set; }
    }
}
