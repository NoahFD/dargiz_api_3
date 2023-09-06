using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory; // Add this using statement
using System;
using System.Threading.Tasks;


namespace WebApplication_4.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class SenderPageController : Controller
{
    
    private readonly IMemoryCache _memoryCache; // Define IMemoryCache

    public SenderPageController(IMemoryCache memoryCache) // Inject IMemoryCache through constructor
    {
        _memoryCache = memoryCache;
    }
    // GET: /SenderPage/Index
    public IActionResult Index()
    {
        return View();
    }

    // GET: /SenderPage/Welcome/ 
    [HttpPost]
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }

    [HttpPost]
    public async Task<IActionResult> ProductToSync()
    {
        if (Request.Form.ContainsKey("save"))
        {
            // Handle the logic when "save" button is pressed
            if (_memoryCache.TryGetValue("BrowserFormPostUrl", out string cachedUrl))
            {
                // Use the cached URL
                Console.WriteLine("Cached BrowserFormPost URL From My BROWSER: " + cachedUrl);
            }
            return Content(cachedUrl);
        }
        Console.WriteLine("HI");
        // If the form doesn't contain "save", return the same view.
        return View("Index");
    }
}