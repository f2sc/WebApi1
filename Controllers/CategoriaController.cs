using Microsoft.AspNetCore.Mvc;
using projectEF.Models;
using WebApi1.Service;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService service)
        {
            categoriaService = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(categoriaService.Get());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            await categoriaService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Categoria categoria)
        {
            await categoriaService.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await categoriaService.Delete(id);
            return Ok();
        }


    }
}
