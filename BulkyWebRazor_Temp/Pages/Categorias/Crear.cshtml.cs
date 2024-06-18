using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categorias
{
    //Vincula la propiedades del modelo ya que si no, estaremos añadiendo un null
    [BindProperties]
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Categoria Categoria { get; set; }
        public CrearModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Categoria obj)
        {
            _db.Categorias.Add(Categoria);
            _db.SaveChanges();
            TempData["success"] = "Categoria creada correctamente";
            return RedirectToPage("Index");
        }
    }
}
