using SQLite;

namespace Models
{
    public class Product
    {
        #region Atributos da classe product
        private int prodId;
        private string prodDescricao;
        private decimal prodPreco;
        #endregion

        #region Métodos da classe product 
        public int ProdId
        {
            get { return prodId; }
            set { prodId = value; }
        }

        public string ProdDescricao
        {
            get { return prodDescricao; }
            set { prodDescricao = value; }
        }

        public decimal ProdPreco
        {
            get { return prodPreco; }
            set { prodPreco = value; }
        }
        #endregion
    }
}
