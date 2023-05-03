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

        public void DeleteProduct(int id)
        {
            _conn.Execute("DELETE FROM Sales WHERE productID = @id", new {id = id});
            _conn.Execute("DELETE FROM reviews WHERE productID = @id", new { id = id});
            _conn.Execute("DELETE FROM products WHERE productID = @id", new {id = id});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE productID = @id", new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products " +
                          "SET Name = @name, " +
                          "Price = @price, " +
                          "CategoryID = @cateID, " +
                          "OnSale = @onSale, " +
                          "StockLevel = @stock " +
                          "WHERE ProductID = @id;",
                          new
                          {
                              id = product.ProductID,
                              name = product.Name,
                              price = product.Price,
                              cateID = product.CategoryID,
                              onSale = product.OnSale,
                              stock = product.StockLevel

                          });
        }
    }
}
