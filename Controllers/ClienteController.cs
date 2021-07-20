using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentas_3.Models;
using WSVentas_3.Models.Response;
using WSVentas_3.Models.Request;

namespace WSVentas_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    var lst = db.Clientes.OrderByDescending(d => d.CreatedAt).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);

        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = new Cliente(); //esto crea un nuevo objeto Cliente que es lo que quiere este POST, crear u nuevo cliente
                    oCliente.Nombre = oModel.Nombre; //nombre será lo que recibo de mi ClienteRequest, oModel
                    db.Clientes.Add(oCliente); //agregamos instruccion de meter un nuevo Cliente en la tabla
                    db.SaveChanges(); //se agrega realmente
                    oRespuesta.Exito = 1;
                }
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id); //busca el id del que queremos editar
                    oCliente.Nombre = oModel.Nombre; //nombre será lo que recibo de mi ClienteRequest, oModel
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //indica al Entityframework que este registro pasa a modificado y cuando hace el savechange se edita 
                    db.SaveChanges(); //fija lo hecho
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id); //busca el id del que queremos editar
                    db.Remove(oCliente);
                    db.SaveChanges(); //fija lo hecho
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
