using homework26_12.Entity;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace homework26_12.Pages
{
    public class FormModel : PageModel
    {
        //�� ����� - Razor Pages ��� ��� ��������� ��� ������ �������������!
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

            //�� ����� - Razor Pages ��� ��� ��������� ��� ������ �������������!
            //AntiforgeryTokenSet tokens = antiforgery.GetAndStoreTokens(HttpContext);

            context.Products.Add(Product);
            await context.SaveChangesAsync();

            TempData["SuccessMessage"] = "������� ������� ��������!";
            return RedirectToPage("/Form");
        }
    }
}
