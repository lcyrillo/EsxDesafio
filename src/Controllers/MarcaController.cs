using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESX.DesafioSimplificado.DAO;
using ESX.DesafioSimplificado.Infra;
using ESX.DesafioSimplificado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESX.DesafioSimplificado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaDao _dao;
        private readonly ApiContext _context;

        public MarcaController(MarcaDao dao, ApiContext context)
        {
            _dao = dao;
            _context = context;
        }

        // GET: api/Marca
        [HttpGet]
        public IList<Marca> Get()
        {
            return _dao.GetAll();
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        public Marca Get(int id)
        {
            return _dao.GetById(id);
        }

        [HttpGet]
        [Route("{id}/patrimonios")]
        public IList<Patrimonio> GetPatrimonios(int id)
        {
            return _dao.GetPatrimoniosMarca(id);
        }

        // POST: api/Marca
        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca)
        {
            try
            {
                //verifica nome da marca existente
                if (_dao.GetByName(marca.Nome))
                    return NotFound("Não foi possivel cadastrar. Er: Nome de marca já existe");

                _dao.AddMarca(marca);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = marca.MarcaId }, marca);
            } 
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: api/Marca/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Marca marca)
        {
            try
            {
                Marca marcaDb = _dao.GetById(id);

                if (marca == null)
                    return NotFound();

                marcaDb.Nome = marca.Nome;

                _dao.UpdateMarca(marcaDb);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Marca marca = _context.Marca.Find(id);

                if(marca != null)
                {
                    _dao.DeleteMarca(marca);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
