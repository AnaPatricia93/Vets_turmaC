using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    /// <summary>
    /// Classe representa a tabela dos 'Donos' na base de dados
    /// </summary>
    public class Donos
    {   
        public Donos()
        {   //inicializar a lista de animais associados a um 'Dono'
            ListaDeAnimais = new HashSet<Animais>();
        }

        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }

        //especificar que o Dono também tem VÁRIOS animais, para pudermos navegar depois em C# (vai-nos simplificar a vida posteriormente
        //lista dos animais que o Dono tem
        public ICollection<Animais> ListaDeAnimais { get; set; } //Através do Dono, obter lista dos Animais (para não termos de efetuar continuamente pesquisas à BD)

    }
}
