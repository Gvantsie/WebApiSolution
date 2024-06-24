using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Services;

namespace WebApiApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        var newProduct = await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _productService.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
    {
        var products = await _productService.GetProductsByCategoryAsync(categoryId);
        return Ok(products);
    }

    [HttpGet("category/{categoryId}/total-price")]
    public async Task<ActionResult<decimal>> GetTotalPriceByCategory(int categoryId)
    {
        var totalPrice = await _productService.GetTotalPriceByCategoryAsync(categoryId);
        return Ok(totalPrice);
    }

    [HttpGet("total-price-per-category")]
    public async Task<ActionResult<Dictionary<string, decimal>>> GetTotalPricePerCategory()
    {
        var totalPrices = await _productService.GetTotalPricePerCategoryAsync();
        return Ok(totalPrices);
    }
}
