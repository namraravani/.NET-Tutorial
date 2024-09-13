using CachingImplementation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Text;

namespace CachingImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ProductController> _logger;
        private readonly IDistributedCache _distributedCache;


        public ProductController(AppDbContext dbContext, IMemoryCache memoryCache, ILogger<ProductController> logger, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;

            // Use this to use the In-Memeory Cache implementation
            _memoryCache = memoryCache;
            _logger = logger;

            // Use this for the Distributed Redis Cache Implementation
            _distributedCache = distributedCache;
        }




        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> MemoryCache()
        //{
        //    var cacheData = _memoryCache.Get<IEnumerable<Product>>("products");
        //    if (cacheData != null)
        //    {

        //        return Json(cacheData);
        //    }


        //    var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
        //    cacheData = await _dbContext.Products.ToListAsync();
        //    _memoryCache.Set("products", cacheData, expirationTime);

        //    return Json(cacheData);
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetCachedProducts()
        //{

        //    var cacheKey = "products";


        //    if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<Product> cachedProducts))
        //    {

        //        return Json("We have Found The data");
        //    }
        //    else
        //    {

        //        return NotFound("No cached data found.");
        //    }
        //}

        [HttpGet]
        public async Task<List<Product>> GetProductsAsync()
        {
            HttpContext.Response.Headers.Add("x-my-custom-header", "Custom Header");
            var productsByteArray = await _distributedCache.GetAsync("Product");
            if (productsByteArray != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(productsByteArray);
                var productList = JsonConvert.DeserializeObject<List<Product>>(cachedDataString);
                return productList;
            }
            else
            {
                var products = await _dbContext.Products.ToListAsync();
                string serializedProductsLists = JsonConvert.SerializeObject(products);
                await _distributedCache.SetAsync("Product", Encoding.UTF8.GetBytes(serializedProductsLists));
                return products;
            }
        }

        [HttpPost]
        public async Task<Product> AddProductAsync(Product product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
            await _distributedCache.RemoveAsync("Product");
            return product;
        }
        public IActionResult Index()
        {
            return View();
        }
    }

}

