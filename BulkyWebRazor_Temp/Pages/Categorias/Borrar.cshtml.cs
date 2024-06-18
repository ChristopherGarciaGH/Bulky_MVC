using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categorias
{
    [BindProperties]
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Categoria Categoria { get; set; }
        public BorrarModel(ApplicationDbContext db)
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
            Categoria? obj = _db.Categorias.Find(Categoria.Id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categorias.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoria borrada correctamente";
            return RedirectToPage("Index");
        }
    }
}
