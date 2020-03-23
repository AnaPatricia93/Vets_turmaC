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
        public string Nome { get; set; }
        public string NumCedulaProf { get; set; }
        public string Foto { get; set; }

        //lista de 'consultas' que o Vsterinario está associado
        public ICollection<Consultas> ListaDeConsultas { get; set; }
    }

    
}
