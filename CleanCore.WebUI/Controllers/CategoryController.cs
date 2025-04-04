using CleanCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanCore.WebUI.Controllers; 
public class CategoryController : Controller {
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) {
        this._service = service; 
    }

    [HttpGet]
    public async Task<ActionResult> Index() {
        var result = await _service.GetCategories();
        return View(result);
    }
}
