using E_commAPI.Database.Context;
using E_commAPI.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commAPI.Controllers;

[Route("api/products")] // does not have an attribute route exception 
[ApiController]
public class ProductRestController
{
    private DataContext _dataContext { get; set; }

    public ProductRestController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<Product> getAll()
    {
        return _dataContext.Products.Include(p => p.Category);
    }

    // CRUD Operations 
    
    [HttpGet("{Id}")]
    public Product read(int Id)
    {
        return _dataContext.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductId == Id);
    }

    [HttpPut("{Id}")]
    public Product update([FromBody] Product product, int Id)
    {
        product.ProductId = Id;
        _dataContext.Products.Update(product);
        _dataContext.SaveChanges();
        return product;
    }

    [HttpPost]
    public Product create([FromBody] Product product)
    {
        _dataContext.Products.Add(product);
        _dataContext.SaveChanges();
        return product;
    }

    [HttpDelete("{Id}")]
    public void delete(int Id)
    {
        Product product = _dataContext.Products.FirstOrDefault(p => p.ProductId == Id);
        _dataContext.Products.Remove(product);
        _dataContext.SaveChanges();
    }
}