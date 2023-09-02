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

            if (!ModelState.IsValid)
                return View();
            
            var respuesta = contactoDatos.gardarContacto(objetoContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            //metodo solo devuelve la vista
            var objetoContacto = contactoDatos.obtenerContactoById(IdContacto);
            return View(objetoContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel objetoContacto)
        {
            //metodo solo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = contactoDatos.editarContacto(objetoContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var objetoContacto = contactoDatos.obtenerContactoById(IdContacto);
            return View(objetoContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel objetoContacto)
        {

            var respuesta = contactoDatos.eliminarContacto(objetoContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }

}

