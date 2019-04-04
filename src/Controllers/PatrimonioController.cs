using ESX.DesafioSimplificado.DAO;
using ESX.DesafioSimplificado.Infra;
using ESX.DesafioSimplificado.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESX.DesafioSimplificado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        private readonly PatrimonioDao _dao;
        private readonly ApiContext _context;

        public PatrimonioController(PatrimonioDao dao, ApiContext context)
        {
            _dao = dao;
            _context = context;
        }

        // GET: api/Patrimonio
        [HttpGet]
        public IList<Patrimonio> Get()
        {
            return _dao.GetAll();
        }

        // GET: api/Patrimonio/5
        [HttpGet("{id}")]
        public Patrimonio Get(int id)
        {
           return _dao.GetById(id);
        }

        // POST: api/Patrimonio
        [HttpPost]
        public async Task<ActionResult<Patrimonio>> Post(Patrimonio patrimonio)
        {
            try
            {
                patrimonio.NumTombo = Guid.NewGuid().ToString();
                _dao.AddPatrimonio(patrimonio);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = patrimonio.PatrimonioId }, patrimonio);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
        }

        // PUT: api/Patrimonio/5
        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Patrimonio patrimonio)
        {
            try
            {
                Patrimonio patrimonioDb = _dao.GetById(id);

                if (patrimonio == null)
                    return NotFound();

                patrimonioDb.Descricao = patrimonio.Descricao;
                patrimonioDb.Nome = patrimonio.Nome;
                patrimonioDb.MarcaId = patrimonio.MarcaId;

                _dao.UpdatePatrimonio(patrimonioDb);
                return Ok();
            }
            catch (Exception)
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
                Patrimonio patrimonio = _context.Patrimonio.Find(id);

                if (patrimonio != null)
                {
                    _dao.DeletePatrimonio(patrimonio);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                   
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
