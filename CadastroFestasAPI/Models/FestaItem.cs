namespace CadastroFestasAPI.Models
{
    public class FestaItem : BaseModel
    {
        public FestaItem() { }

        public FestaItem(Festa festa) 
        {
            this.festa = festa;
        }

        public string? IdFesta
        {
            get => festa == null ? idFesta : festa.Id;
            set => idFesta = value;
        }

        public string Nome { get; set; } = "";

        public int Quantidade { get; set; }

        private string? idFesta = null;
        private Festa? festa;
    }
}
