using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Animais' na base de dados
    /// Quando terminar fazer 'Add-Migration inicialCommit' - os nomes devem ser sempre diferentes
    /// Verificar se a pasta 'Migrations foi criada' e ver ficheiro criado com atenção
    /// </summary>
    public class Animais
    {
        public Animais()
        {
            ListaDeConsultas = new HashSet<Consultas>();
        }
        /// <summary>
        /// Pk da tabela 
        /// </summary>
        [Key]
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

        /// <summary>
        /// FK para a tabela Donos
        /// </summary>
        [ForeignKey(nameof(Dono))] // Ligar Animais ao Dono
        public int DonoPK { get; set; }
        public Donos Dono { get; set; }

        //lista de consultas 
        public ICollection<Consultas> ListaDeConsultas { get; set; }
    }

   
}
