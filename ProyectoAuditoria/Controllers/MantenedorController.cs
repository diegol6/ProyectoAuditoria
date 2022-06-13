using Microsoft.AspNetCore.Mvc;
using ProyectoAuditoria.Datos;
using ProyectoAuditoria.Models;

namespace ProyectoAuditoria.Controllers
{
    public class MantenedorController : Controller
    {
        ActivoDatos _ActivoDatos = new ActivoDatos();
        public IActionResult Listar()
        {
            //Mostrar Lista de Activos
            var oLista = _ActivoDatos.Listar();

            return View(oLista);
            
        }

        public IActionResult Guardar()
        {
            //Devolver la Vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ActivoModel oActivo)
        {
            //Recibir objetos y guardarlo

            //if (!ModelState.IsValid)
              //  return View();

            var respuesta = _ActivoDatos.Guardar(oActivo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(string IdActivo)
        {
            //Devolver la Vista
            var oactivo = _ActivoDatos.Obtener(IdActivo);
            return View(oactivo);
        }

        [HttpPost]
        public IActionResult Editar(ActivoModel oActivo)
        {
            //Devolver la Vista
            var respuesta = _ActivoDatos.Editar(oActivo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(string IdActivo)
        {
            //Devolver la Vista
            var oactivo = _ActivoDatos.Obtener(IdActivo);
            return View(oactivo);
        }

        [HttpPost]
        public IActionResult Eliminar(ActivoModel oActivo)
        {
            //Devolver la Vista
            var respuesta = _ActivoDatos.Eliminar(oActivo.IdActivo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
