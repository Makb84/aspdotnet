using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// namespace MvcEcommerce.Controllers;

public class ItemController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }

    // public string AddItem(string name, int ID = 1)
    // {
    //     return HtmlEncoder.Default.Encode($"Hello {name}, Id: {ID}");
    // }

    public IActionResult AddItem()
    {
        return View();
    }


    [AllowAnonymous]
    public IActionResult ShowItems()

    {
        return View();
    }
}