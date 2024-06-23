using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //IWebHostEnvironment lo utilizamos para capturar archivos como las imagenes
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductoController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        //Mostrar categorias
        public IActionResult Index()
        {
            List<Producto> objListaProducto = _unitOfWork.Producto.GetAll(includeProperties:"Categoria").ToList();
            return View(objListaProducto);
        }

        //Mostrar el formulario de creación (GET)
        //Update + Insert = Upsert
        public IActionResult Upsert(int? id)
        {
            //Crear desplegable de categorias
            //IEnumerable<SelectListItem> ListaCategorias = _unitOfWork.Categoria.GetAll().Select(
            //    u => new SelectListItem
            //    {
            //        Text = u.Nombre,
            //        Value = u.Id.ToString()
            //    });
            //Almacenamos en un ViewBag (Transfiere datos desde el controlador a la vista NO VICEVERSA
            //ViewBag.ListaCategorias = ListaCategorias;
            //Crear el desplegable utilizando ViewData (Funciona como un diccionario)
            //ViewData["ListaCategorias"] = ListaCategorias;
            //Crear desplegable con View Models (Esta es la forma mas correcta)
            ProductoVM productoVM = new()
            {
                ListaCategorias = _unitOfWork.Categoria.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Nombre,
                    Value = u.Id.ToString()
                }),
                Producto = new Producto()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(productoVM);
            }
            else
            {
                //Update
                productoVM.Producto = _unitOfWork.Producto.Get(u => u.Id == id);
                return View(productoVM);
            }
        }

        //Procesa los datos enviados a traves del formulario anterior (POST)
        [HttpPost]
        public IActionResult Upsert(ProductoVM productoVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productoVM.Producto.ImageURL))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productoVM.Producto.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productoVM.Producto.ImageURL = @"\images\product\" + fileName;
                }

                if (productoVM.Producto.Id == 0)
                {
                    _unitOfWork.Producto.Add(productoVM.Producto);
                }
                else
                {
                    _unitOfWork.Producto.Update(productoVM.Producto);
                }

                _unitOfWork.Save();
                TempData["success"] = "Producto creado correctamente";
                return RedirectToAction("Index");
            }
            else
            {
                productoVM.ListaCategorias = _unitOfWork.Categoria.GetAll().Select(
                    u => new SelectListItem
                        {
                            Text = u.Nombre,
                            Value = u.Id.ToString()
                        });
                return View(productoVM);
            }
        }

        //Metodo (GET) traemos lo que vamos a editar
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Producto? ProductoFromDb = _unitOfWork.Producto.Get(u => u.Id == id);
            if (ProductoFromDb == null)
            {
                return NotFound();
            }
            return View(ProductoFromDb);
        }

        //Procesa los datos enviados a traves del formulario anterior (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Producto? obj = _unitOfWork.Producto.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Producto.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Producto borrado correctamente";
            return RedirectToAction("Index");
        }

        //Llamada a API DataTables
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Producto> objListaProducto = _unitOfWork.Producto.GetAll(includeProperties: "Categoria").ToList();
            return Json(new {data = objListaProducto});
        }
        #endregion
    }
}
