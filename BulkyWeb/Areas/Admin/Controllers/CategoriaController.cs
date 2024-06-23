using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Mostrar categorias
        public IActionResult Index()
        {
            List<Categoria> objListaCategoria = _unitOfWork.Categoria.GetAll().ToList();
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
                _unitOfWork.Categoria.Add(obj);
                _unitOfWork.Save();
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
            Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
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
                _unitOfWork.Categoria.Update(obj);
                _unitOfWork.Save();
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
            Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
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
            Categoria? obj = _unitOfWork.Categoria.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Categoria.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Categoria borrada correctamente";
            return RedirectToAction("Index");
        }
    }
}
