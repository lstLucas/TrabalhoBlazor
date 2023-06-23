using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroFestasAPI.Models;
using CadastroFestasAPI.DAOs;
using CadastroFestasAPI.Controllers.Extensoes;
using CadastroFestaDll.DOs;

namespace CadastroFestaItemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestaItemController : ControllerBase
    {
        // GET: api/FestaItem
        [HttpGet]
        public async Task<ActionResult<IList<FestaItemDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/FestaItem
        [HttpGet("mestre/{idMestre}")]
        public async Task<ActionResult<IList<FestaItemDO>>> GetPorIdMestre(string idMestre)
        {
            return Ok((await dao.RetornarPorIdMestreAsync(idMestre)).ToDO());
        }

        // GET: api/FestaItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FestaItemDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/FestaItem
        [HttpPost]
        public async Task<ActionResult<FestaItemDO>> Post(FestaItemDO objDO)
        {
            if (objDO == null)
                return Problem("O item que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/FestaItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, FestaItemDO novoFestaItemDO)
        {
            if (id != novoFestaItemDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoFestaItemDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/FestaItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private FestaItemDAO dao = new FestaItemDAO();
    }
}