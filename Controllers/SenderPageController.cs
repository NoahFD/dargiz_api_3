using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace WebApplication_4.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class SenderPageController : Controller
{
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
            
            return Content("Form saved!");
        }
        Console.WriteLine("HI");
        // If the form doesn't contain "save", return the same view.
        return View("Index");
    }
}