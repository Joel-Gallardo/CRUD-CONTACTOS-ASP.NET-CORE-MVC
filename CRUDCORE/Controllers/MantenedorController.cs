using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //La vista mostrara una lista de contactos
            var objetoLista = contactoDatos.listarContactos();
            return View(objetoLista);
        }

        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel objetoContacto)
        {
            //metodo recibe el objeto para guardarlo en la BD
            var respuesta = contactoDatos.gardarContacto(objetoContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
