using Reciclica.Web.Empresas;
using Reciclica.Web.Materiais;

namespace Reciclica.Web.Pontos
{
    public class Ponto
    {
        public int Id { get;  set; }

        public int EmpresaId{get;set;}
        public int MaterialId{get;set;}
        public  Empresa Empresa { get;  set; }
        public  Material Material { get;  set; }
        public string Logradouro { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }

        public Ponto(){}
    }
}