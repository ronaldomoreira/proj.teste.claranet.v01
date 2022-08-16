using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessService.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CnpjValidation : ValidationAttribute
    {
        private string SomenteNumeros(string str)
        {
            int i;
            string rt = "";
            for (i = 0; i < str.Length; i++)
                if (Char.IsDigit(str[i]))
                    rt += str[i];
            return rt;
        }

        private bool ValidaCnpj (string? Cnpj)
        {
            if (String.IsNullOrWhiteSpace(Cnpj))
                return false;

            string CNPJ = Cnpj.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }

        public CnpjValidation() : base("{0} está inválido!")  
        {
            //
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;

            if ((value != null) && (!String.IsNullOrWhiteSpace(value.ToString()))) 
            {
                #pragma warning disable CS8604 // Possible null reference argument.
                string strVal = SomenteNumeros(value.ToString());
                #pragma warning restore CS8604 // Possible null reference argument.
                isValid = ValidaCnpj(strVal); ;
            }

            return isValid;
        }
    }
}
