using SQLite;

namespace Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }
        [MaxLength(150)]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
