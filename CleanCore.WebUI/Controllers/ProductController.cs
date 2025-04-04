using CleanCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanCore.WebUI.Controllers; 
public class ProductController : Controller {
    private readonly IProductService _service;

    public ProductController(IProductService service) {
        this._service = service;
    }

    [HttpGet]
    public async Task<ActionResult> Index() {
        var result = await _service.GetProducts();
        return View(result);
    }
}
