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
            var oLista = ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista
            return View();
        }

        public IActionResult Guardar()
        {
            //metodo recibe el objeto para guardarlo en la BD
            return View();
        }
    }
}
