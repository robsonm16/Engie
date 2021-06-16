using System;


namespace Domain.Dto
{
    public class UsinaDto
    {
        public Guid UsinaId { get; set; }
        public string Fornecedor { get; set; }
        public string UC { get; set; }
        public bool Ativo { get; set; }
    }
}
