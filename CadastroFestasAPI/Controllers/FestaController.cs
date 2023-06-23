using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroFestasAPI.Models;
using CadastroFestasAPI.DAOs;
using CadastroFestasAPI.Controllers.Extensoes;
using CadastroFestaDll.DOs;

namespace CadastroFestasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestaController : ControllerBase
    {
        // GET: api/Festa
        [HttpGet]
        public async Task<ActionResult<IList<FestaDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/Festa/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<FestaDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/Festa
        [HttpPost]
        public async Task<ActionResult<FestaDO>> Post(FestaDO objDO)
        {
            if (objDO == null)
                return Problem("Não é possível inserir uma festa Nula.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Festa/Id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, FestaDO novoFestaDO)
        {
            if (id != novoFestaDO.Id)
                return Problem("O id da rota não confere com o Id do objeto");
            
            try
            {
                await dao.AlterarAsync(await novoFestaDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Festa/Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private FestaDAO dao = new FestaDAO();
    }
}