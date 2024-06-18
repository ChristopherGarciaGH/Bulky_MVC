using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Categoria> ListaCategorias { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ListaCategorias = _db.Categorias.ToList();
        }
    }
}
