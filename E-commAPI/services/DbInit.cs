using E_commAPI.Database.Context;
using E_commAPI.models;

namespace E_commAPI.services;

public static class DbInit
{
    public static void initData(DataContext dataContext)
    {
        dataContext.Categories.Add(new Category { NameCategory = "computers" });
        dataContext.Categories.Add(new Category { NameCategory = "printers" });
        
        for (int i = 1; i <= 10; i++)
        {
            dataContext.Products.Add(new Product { ProductId = i, Designation = "HP 800", Price = new Random().NextInt64(100,1000000), CategoryID = 1 });
        }
        dataContext.SaveChanges();
    }
}