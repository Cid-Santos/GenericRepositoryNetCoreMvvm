using DataAcess.Interfaces;
using Models;
using SQLite;

namespace DataAcess.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(SQLiteAsyncConnection connection) : base(connection) { }
    }

    public class ProdutoRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProdutoRepository(SQLiteAsyncConnection connection) : base(connection) { }
    }

}
