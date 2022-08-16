using BusinessService.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_app.teste.claranet.Models
{
    public class CadastroViewModel
    {
        public CadastroViewModel()
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
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido!", AllowEmptyStrings = false)]
        [CnpjValidation]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido!", AllowEmptyStrings = false)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido!", AllowEmptyStrings = false)]
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Entre com um email válido!")]
        [MaxLength(256, ErrorMessage = "Email muito longo, máx. de 256 caracteres.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Display(Name = "Telefone comercial")]
        public string? TelefoneComercial { get; set; }

        [Display(Name = "Celular")]
        public string? Celular { get; set; }

        [Display(Name = "Logradouro")]
        public string? Logradouro { get; set; }

        [Display(Name = "Nº")]
        public string? Num { get; set; }

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string? Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Display(Name = "UF")]
        public string? Estado { get; set; }

        [Display(Name = "CEP")]
        public string? Cep { get; set; }

        [Display(Name = "Nome contato")]
        public string? NomeContato { get; set; }
    }
}
