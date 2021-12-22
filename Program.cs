using System;
using System.Diagnostics;
using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;

namespace ValidadorDeDocumentos
{
    class Program
    {
        static void Main(string[] args)
        {
            string cpf1 =  "86288366757";
            string cpf2 =  "98745366797";
            string cpf3 =  "22222222222";

            ValidarCPF(cpf1);
            ValidarCPF(cpf2);
            ValidarCPF(cpf3);

            string cnpj1 = "51241758000152";
            string cnpj2 = "14128481000127";

            ValidadorCNPJ(cnpj1);
            ValidadorCNPJ(cnpj2);

            string titulo1 = "041372570132";
            string titulo2 = "774387480132";

            ValidadorTituloEleitor(titulo1);
            ValidadorTituloEleitor(titulo2);

            Debug.WriteLine(new CPFFormatter().Format(cpf1));
            Debug.WriteLine(new CPFFormatter().Format(cpf2));
            Debug.WriteLine(new CPFFormatter().Format(cpf3));
            Debug.WriteLine(new CNPJFormatter().Format(cnpj1));
            Debug.WriteLine(new CNPJFormatter().Format(cnpj2));
            Debug.WriteLine(new TituloEleitoralFormatter().Format(titulo1));
            Debug.WriteLine(new TituloEleitoralFormatter().Format(titulo2));

            string cpfFormatato = new CPFFormatter().Format(cpf1);
            Debug.WriteLine(new CPFFormatter().Unformat(cpfFormatato));
        }

        private static void ValidarCPF(string cpf)
        {
            try{
                new CPFValidator().AssertValid(cpf);
                Debug.WriteLine("CPF Valido: " + cpf);
            }catch(Exception exc){
                 Debug.WriteLine(exc.Message.ToString());
            }
        }
        private static void ValidadorCNPJ(string cnpj)
        {
            if(new CNPJValidator().IsValid(cnpj))
            {
                Debug.WriteLine("CNPJ Válido: " + cnpj);
            }else
            {
                Debug.WriteLine("O CNPJ Digitado não é válido");
            }
        }
        private static void ValidadorTituloEleitor(string titulo)
        {
            if (new TituloEleitoralValidator().IsValid(titulo))
            {
                Debug.WriteLine("Título válido: " + titulo);
            }else
            {
                Debug.WriteLine("Título inválido: " + titulo);
            } 
        }
    }
}
