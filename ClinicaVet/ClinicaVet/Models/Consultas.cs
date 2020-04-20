using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Consultas' na base de dados
    /// </summary>
    public class Consultas
    {
        [Key] // força o atributo a ser PK. Mas, não seria necessário porque o atributo se chama 'ID'
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }

        //criar as chaves estrangeiras/forasteiras FK
        [ForeignKey(nameof(Veterinario))]
        public int VeterinarioFK { get; set; }
        public virtual Veterinarios Veterinario { get; set; }

        [ForeignKey(nameof(Animal))]
        public int AnimalFK { get; set; }
        public virtual Animais Animal { get; set; }

    }
}
