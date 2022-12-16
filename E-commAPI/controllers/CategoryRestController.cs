using E_commAPI.Database.Context;
using E_commAPI.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commAPI.Controllers;

[Route("api/categories")] // does not have an attribute route exception 
[ApiController]
public class CategoryRestController
{
    private DataContext _dataContext { get; set; }

    public CategoryRestController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Category> getAll()
    {
        return _dataContext.Categories;
    }

    [HttpGet("{Id}/products")]
    public IEnumerable<Product> getAll(int Id)
    {
        Category category = _dataContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryID == Id);
        return category.Products;
    }
    
    [HttpGet("{Id}")]
    public Category read(int Id)
    {
        return _dataContext.Categories.FirstOrDefault(c => c.CategoryID == Id);
    }

    [HttpPut("{Id}")]
    public Category update([FromBody] Category category, int Id)
    {
        category.CategoryID = Id;
        _dataContext.Categories.Update(category);
        _dataContext.SaveChanges();
        return category;
    }

    [HttpPost]
    public Category create([FromBody] Category category)
    {
        _dataContext.Categories.Add(category);
        _dataContext.SaveChanges();
        return category;
    }

    [HttpDelete("{Id}")]
    public void delete(int Id)
    {
        Category category = _dataContext.Categories.FirstOrDefault(c => c.CategoryID == Id);
        _dataContext.Categories.Remove(category);
        _dataContext.SaveChanges();
    }
}