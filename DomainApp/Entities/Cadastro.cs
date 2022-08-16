using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.Entities
{
    [Table("Cadastro")]
    [Serializable]
    public class Cadastro
    {
        public Cadastro()
        {
            Cnpj = String.Empty;
            RazaoSocial = String.Empty;
            NomeFantasia = String.Empty;
            Email = String.Empty;
            Telefone = String.Empty;
            TelefoneComercial = String.Empty;
            Celular = String.Empty;
            Logradouro = String.Empty;
            Num = String.Empty;
            Complemento = String.Empty;
            Bairro = String.Empty;
            Cidade = String.Empty;
            Estado = String.Empty;
            Cep = String.Empty;
            NomeContato = String.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(14)")]
        public string Cnpj { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string RazaoSocial { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NomeFantasia { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Telefone { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? TelefoneComercial { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Celular { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Logradouro { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? Num { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Complemento { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Bairro { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Cidade { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Estado { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? Cep { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeContato { get; set; }
    }
}
