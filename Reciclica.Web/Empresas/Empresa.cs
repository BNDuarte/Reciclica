namespace Reciclica.Web.Empresas
{
    public class Empresa
    {
        public int Id { get;  set; }
        public string Cnpj { get;  set; }
        public string Nome { get;  set; }
        public string Telefone { get;  set; }
        public string Telefone2 { get;  set; }
        public string Endereco { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public int Numero { get;  set; }
        public string Cep { get;  set; }
        public Empresa(){}
    }
}