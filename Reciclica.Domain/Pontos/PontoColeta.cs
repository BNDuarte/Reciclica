using Reciclica.Domain.Exceptions;
using Reciclica.Domain.Empresas;
using Reciclica.Domain.Materiais;

namespace Reciclica.Domain.Pontos
{
    public class PontoColeta
    {
        public int Id { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual Material Material { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }

        public PontoColeta(Empresa empresa, Material material, string logradouro, string bairro, string cidade)
        {
            ValidarValores(empresa, material);
            GravarPropriedades(empresa, material, logradouro, bairro, cidade);
        }

        public void Update(Empresa empresa, Material material, string logradouro, string bairro, string cidade)
        {
            ValidarValores(empresa, material);
            GravarPropriedades(empresa, material, logradouro, bairro, cidade);
        }

        private void GravarPropriedades(Empresa empresa, Material material, string logradouro, string bairro, string cidade)
        {
            Empresa = empresa;
            Material = material;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
        }

        private static void ValidarValores(Empresa empresa, Material material)
        {
            DomainException.When(empresa == null, "Empresa é obrigatório");
            DomainException.When(material == null, "Material é obrigatório");
        }
    }
}