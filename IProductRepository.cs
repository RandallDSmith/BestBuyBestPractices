using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string Name, double Price, int CategoryID);

        public Product GetProduct(int id);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);


    }
}
