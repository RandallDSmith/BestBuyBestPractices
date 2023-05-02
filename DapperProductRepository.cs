using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection connection)
        {
            _conn = connection;
        }

        public void CreateProduct(string Name, double Price, int CategoryID)
        {
            _conn.Execute("INSERT INTO products(Name, Price, CategoryID) VALUES(@name, @price, @categoryID)",
                new { name = Name, price = Price, categoryID = CategoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }
    }
}
