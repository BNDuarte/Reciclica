using Reciclica.Domain.Exceptions;

namespace Reciclica.Domain.Materiais
{
    public class Material 
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public Material(string descricao, string observacao)
        {
            GravarPropriedades(descricao, observacao);
        }

        protected Material() { }

        public void GravarPropriedades(string descricao, string observacao)
        {
            DomainException.When(string.IsNullOrEmpty(descricao), "Descrição é obrigatória");
            Descricao = descricao;
            Observacao = observacao;
        }

        public void Update(string descricao, string observacao)
        {
            GravarPropriedades(descricao, observacao);
        }
    }
}
