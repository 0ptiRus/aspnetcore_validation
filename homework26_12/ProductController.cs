using homework26_12.Entity;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.WebRequestMethods;

//отказался от использования контроллера потому что MVC контроллер не супер дружит с Razor Pages
//я просто не смог бы нормально выводить сообщения о валидации

namespace homework26_12
{
    [Obsolete("Этот контроллел переехал - не смотрите сюда, смотрите в модель формы!")]
    [Controller]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IAntiforgery antiforgery;
        private readonly ProductDbContext context;

        public ProductController(IAntiforgery antiforgery, ProductDbContext context)
        {
            this.antiforgery = antiforgery;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] Product data)
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }
            AntiforgeryTokenSet tokens = antiforgery.GetAndStoreTokens(HttpContext);
            context.Products.Add(data);
            await context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Продукт успешно добавлен!";
            return RedirectToPage("/Form");
        }
    }
}
