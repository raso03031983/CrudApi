using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Model
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IdConta { get; set; }
        [Required]
        [MaxLength(20)]
        public string documento_cliente { get; set; }
    }

}
