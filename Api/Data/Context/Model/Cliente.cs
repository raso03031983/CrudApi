using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("Cliente")]
    public class Cliente : DefaultValues
    {
        [Key]
        public int idCliente { get; set; }
        [Required]
        [MaxLength(100)]
        public string nome { get; set; }
        [Required]
        public DateTime dataNascimento { get; set; }
        [Required]
        [MaxLength(11)]
        public string cpf { get; set; }
        [Required]
        [MaxLength(20)]
        public string rg { get; set; }
    }
}
