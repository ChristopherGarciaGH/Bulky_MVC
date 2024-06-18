using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoriaController : Controller
	{
		private readonly ICategoriaRepository _categoriaRepo;
        public CategoriaController(ICategoriaRepository db)
        {
            _categoriaRepo = db;
        }

		//Mostrar categorias
        public IActionResult Index()
		{
			List<Categoria> objListaCategoria = _categoriaRepo.GetAll().ToList();
			return View(objListaCategoria);
		}

		//Mostrar el formulario de creación (GET)
		public IActionResult Create()
		{
			return View();
		}

		//Procesa los datos enviados a traves del formulario anterior (POST)
		[HttpPost]
        public IActionResult Create(Categoria obj)
        {
            if (obj.Nombre == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Nombre", "El Display Order no puede coincidir exactamente con el Nombre.");
            }

            if (ModelState.IsValid)
			{
				_categoriaRepo.Add(obj);
                _categoriaRepo.Save();
                TempData["success"] = "Categoria creada correctamente";
                return RedirectToAction("Index");
            }
			return View();
        }

        //Metodo (GET) traemos lo que vamos a editar
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categoria? categoriaFromDb = _categoriaRepo.Get(u => u.Id == id);
            //Varias formas de traernos las categorias
            //Categoria? categoriaFromDb2 = _db.Categorias.FirstOrDefault(u => u.Id == id);
            //Categoria? categoriaFromDb3 = _db.Categorias.Where(u => u.Id == id).FirstOrDefault();
            if (categoriaFromDb == null)
            {
                return NotFound();
            }
            return View(categoriaFromDb);
        }

        //Procesa los datos enviados a traves del formulario anterior (POST)
        [HttpPost]
        public IActionResult Edit(Categoria obj)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepo.Update(obj);
                _categoriaRepo.Save();
                TempData["success"] = "Categoria editada correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Metodo (GET) traemos lo que vamos a editar
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categoria? categoriaFromDb = _categoriaRepo.Get(u => u.Id ==id);
            if (categoriaFromDb == null)
            {
                return NotFound();
            }
            return View(categoriaFromDb);
        }

        //Procesa los datos enviados a traves del formulario anterior (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categoria? obj = _categoriaRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _categoriaRepo.Remove(obj);
            _categoriaRepo.Save();
            TempData["success"] = "Categoria borrada correctamente";
            return RedirectToAction("Index");
        }
    }
}
