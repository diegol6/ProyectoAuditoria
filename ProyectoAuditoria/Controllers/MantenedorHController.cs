
using Microsoft.AspNetCore.Mvc;
using ProyectoAuditoria.Datos;
using ProyectoAuditoria.Models;


namespace ProyectoAuditoria.Controllers
{
    public class MantenedorHController : Controller
    {
        HallazgoDatos _HallazgoDatos = new HallazgoDatos();
        public IActionResult Listar()
        {
            //Mostrar Lista de Activos
            var oLista = _HallazgoDatos.Listar();

            return View(oLista);

        }

        public IActionResult Guardar()
        {
            //Devolver la Vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(HallazgoModel oHallazgo)
        {
            //Recibir objetos y guardarlo

            //if (!ModelState.IsValid)
            //  return View();

            var respuesta = _HallazgoDatos.Guardar(oHallazgo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(string IdHallazgo)
        {
            //Devolver la Vista
            var ohallazgo = _HallazgoDatos.Obtener(IdHallazgo);
            return View(ohallazgo);
        }

        [HttpPost]
        public IActionResult Editar(HallazgoModel oHallazgo)
        {
            //Devolver la Vista
            var respuesta = _HallazgoDatos.Editar(oHallazgo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(string IdHallazgo)
        {
            //Devolver la Vista
            var ohallazgo = _HallazgoDatos.Obtener(IdHallazgo);
            return View(ohallazgo);
        }

        [HttpPost]
        public IActionResult Eliminar(HallazgoModel oHallazgo)
        {
            //Devolver la Vista
            var respuesta = _HallazgoDatos.Eliminar(oHallazgo.IdHallazgo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
