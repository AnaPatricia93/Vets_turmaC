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

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")] // not null
        [StringLength(40, ErrorMessage = "O {0} só pode ter, no máximo, {1} caracteres.")]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        // o primeiro digito não pode ser 0
        // se fosse [0-9]{9} estariamos a admitir '000000000'
        [RegularExpression("[1-9][0-9]{8}", ErrorMessage = "O número de contribuinte deve ter 9 dígitos.")]
        [Display(Name = "Nº da Identificação Fiscal")]
        public string NIF { get; set; }

        //especificar que o Dono também tem VÁRIOS animais, para pudermos navegar depois em C# (vai-nos simplificar a vida posteriormente
        //lista dos animais que o Dono tem
        public ICollection<Animais> ListaDeAnimais { get; set; } //Através do Dono, obter lista dos Animais (para não termos de efetuar continuamente pesquisas à BD)

    }
}
