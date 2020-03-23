using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Consultas' na base de dados
    /// </summary>
    public class Consultas
    {
        /// <summary>
        /// PK da tabela
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// representa o horário da consulta
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// varchar com dimensao máxima (SQL)
        /// </summary>
        public string Observacoes { get; set; }
    }
}
