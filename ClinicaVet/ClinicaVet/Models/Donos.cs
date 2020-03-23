using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Donos' na base de dados
    /// </summary>
    public class Donos
    {   /// <summary>
        /// PK da tabela
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome do Dono
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Numero de Identificação fiscal em string pois não vamos efetuar operacoes com este numero
        /// </summary>
        public string NIF { get; set; }
    }
}
