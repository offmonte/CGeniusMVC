namespace CGenius.DTOs
{
    public class AtualizacaoDTO
    {
      
        public required string CpfAtendente { get; set; }
        public required string CpfCliente { get; set; }
        public required string IdScript { get; set; }
        public required string IdPlano { get; set; }
        public required string IdEspecificacao { get; set; }
        public required string DataAtualizacao { get; set; }
    }