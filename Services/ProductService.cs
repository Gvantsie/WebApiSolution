using Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<decimal> GetTotalPriceByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(p => p.CategoryId == categoryId).SumAsync(p => p.Price);
    }

    public async Task<Dictionary<string, decimal>> GetTotalPricePerCategoryAsync()
    {
        return await _context.Products
            .GroupBy(p => p.Category.Name)
            .Select(g => new { CategoryName = g.Key, TotalPrice = g.Sum(p => p.Price) })
            .ToDictionaryAsync(x => x.CategoryName, x => x.TotalPrice);
    }
}