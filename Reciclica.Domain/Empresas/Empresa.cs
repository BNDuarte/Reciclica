using Reciclica.Domain.Exceptions;

namespace Reciclica.Domain.Empresas
{
    public class Empresa
    {
        public int Id { get; private set; }
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string Telefonne { get; private set; }
        public string Telefone2 { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public int Numero { get; private set; }
        public string Cep { get; private set; }


        public Empresa(string cnpj, string nome, string telefone, string telefone2, string endereco, string bairro, string cidade, int numero, string cep)
        {
            ValidarValores(cnpj, nome, telefone, endereco, bairro, cidade, cep);
            GravarPropriedades(cnpj, nome, telefone, telefone2, endereco, bairro, cidade, numero, cep);
        }

        public void Update(string cnpj, string nome, string telefone, string telefone2, string endereco, string bairro, string cidade, int numero, string cep)
        {
            ValidarValores(cnpj, nome, telefone, endereco, bairro, cidade, cep);
            GravarPropriedades(cnpj, nome, telefone, telefone2, endereco, bairro, cidade, numero, cep);
        }

        private void GravarPropriedades(string cnpj, string nome, string telefone, string telefone2, string endereco, string bairro, string cidade, int nummero, string cep)
        {
            Cnpj = cnpj;
            Nome = nome;
            Telefonne = telefone;
            Telefone2 = telefone2;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Numero = nummero;
            Cep = cep;
        }

        private static void ValidarValores(string cnpj, string nome, string telefone, string endereco, string bairro, string cidade, string cep)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainException.When(string.IsNullOrEmpty(cnpj), "Cnpj é obrigatório");
            DomainException.When(telefone == null, "Telefone é obrigatório");
            DomainException.When(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");
            DomainException.When(string.IsNullOrEmpty(bairro), "Bairro é obrigatório");
            DomainException.When(string.IsNullOrEmpty(cidade), "Cidade é obrigatório");
            DomainException.When(string.IsNullOrEmpty(cep), "Cep é obrigatório");
        }
    }
}
