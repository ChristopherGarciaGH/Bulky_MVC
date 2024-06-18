using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categorias
{
    [BindProperties]
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Categoria Categoria { get; set; }
        public EditarModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Categoria = _db.Categorias.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categorias.Update(Categoria);
                _db.SaveChanges();
                TempData["success"] = "Categoria editada correctamente";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
