using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGenius.Models
{
    [Table("Atualizacao")]
    public class Atualizacao
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("cpf_atendente")]
        public required string CpfAtendente { get; set; }

        [Required]
        [Column("cpf_cliente")]
        public required string CpfCliente { get; set; }

        [Required]
        [Column("id_script")]
        public required string IdScript { get; set; }

        [Required]
        [Column("id_plano")]
        public required string IdPlano { get; set; }

        [Required]
        [Column("id_especificacao")]
        public  required string IdEspecificacao { get; set; }

        [Required]
        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
