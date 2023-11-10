namespace teste_version.Entities
{
    public class VersionEntity
    {
        public int Id { get; set; }
        public string Projeto { get; set; }    
        public string Versao { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
