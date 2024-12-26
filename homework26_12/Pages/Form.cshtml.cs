using homework26_12.Entity;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace homework26_12.Pages
{
    public class FormModel : PageModel
    {
        //не нужно - Razor Pages сам все провер€ет без нашего вмешательства!
        //private readonly IAntiforgery antiforgery;
        private readonly ProductDbContext context;

        [BindProperty]
        public Product Product { get; set; }

        public FormModel(ProductDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //не нужно - Razor Pages сам все провер€ет без нашего вмешательства!
            //AntiforgeryTokenSet tokens = antiforgery.GetAndStoreTokens(HttpContext);

            context.Products.Add(Product);
            await context.SaveChangesAsync();

            TempData["SuccessMessage"] = "ѕродукт успешно добавлен!";
            return RedirectToPage("/Form");
        }
    }
}
