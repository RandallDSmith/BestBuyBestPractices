
using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("Randy's new department");

var departments = departmentRepo.GetAllDepartments();



foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();    
}

var productRepo = new DapperProductRepository(conn);

//productRepo.CreateProduct("JoyStick", 20, 1);

//var products = productRepo.GetAllProducts();

var productToUpdate = productRepo.GetProduct(943);

productToUpdate.Name = "Randy's old product";
productToUpdate.OnSale = 1;
productToUpdate.StockLevel = "20";
productToUpdate.Price = 12.99;
productRepo.UpdateProduct(productToUpdate);

//productRepo.DeleteProduct(944);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID} {product.Name} {product.Price} {product.CategoryID} {product.OnSale}");
}

