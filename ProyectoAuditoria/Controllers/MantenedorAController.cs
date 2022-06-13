using Microsoft.AspNetCore.Mvc;
using ProyectoAuditoria.Datos;
using ProyectoAuditoria.Models;

namespace ProyectoAuditoria.Controllers
{
    public class MantenedorAController : Controller
    {
        AuditoriaDatos _AuditoriaDatos = new AuditoriaDatos();
        public IActionResult Listar()
        {
            //Mostrar Lista de Activos
            var oLista = _AuditoriaDatos.Listar();

            return View(oLista);

        }

        public IActionResult Guardar()
        {
            //Devolver la Vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AuditoriaModel oAuditoria)
        {
            //Recibir objetos y guardarlo

            //if (!ModelState.IsValid)
            //  return View();

            var respuesta = _AuditoriaDatos.Guardar(oAuditoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(string IdAuditoria)
        {
            //Devolver la Vista
            var oaudit = _AuditoriaDatos.Obtener(IdAuditoria);
            return View(oaudit);
        }

        [HttpPost]
        public IActionResult Editar(AuditoriaModel oAuditoria)
        {
            //Devolver la Vista
            var respuesta = _AuditoriaDatos.Editar(oAuditoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(string IdAuditoria)
        {
            //Devolver la Vista
            var oaudit = _AuditoriaDatos.Obtener(IdAuditoria);
            return View(oaudit);
        }

        [HttpPost]
        public IActionResult Eliminar(AuditoriaModel oAuditoria)
        {
            //Devolver la Vista
            var respuesta = _AuditoriaDatos.Eliminar(oAuditoria.IdAuditoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
