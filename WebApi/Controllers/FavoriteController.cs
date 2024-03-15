using Domain.Interfaces.IFavorite;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly InterfaceFavorite _interfaceFavorite;

        public FavoriteController(InterfaceFavorite interfaceFavorite)
        {
            _interfaceFavorite = interfaceFavorite;
        }

        // Método para criar um novo registro de Favorite
        [HttpPost("/api/Favorite/CreateFavorite/")]

        [Produces("application/json")]
        public async Task<IActionResult> CreateFavorite(Favorite favorite)
        {
            await _interfaceFavorite.Add(favorite);
            return Ok("Criado");
        }

        // Método para buscar todos os registros de Favorite
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _interfaceFavorite.List();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByRepoName")]
        public async Task<IActionResult> GetByRepoName(string repoName)
        {
            var result = await _interfaceFavorite.List();
            var resultFinal = result.FirstOrDefault(x => x.RepoName.Equals(repoName));

            if (resultFinal == null)
            {
                return NotFound();
            }

            return Ok(resultFinal);
        }



        [HttpGet]
        [Route("GetEntityById")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            var existingFavorite = await _interfaceFavorite.GetEntityById(id);
            if (existingFavorite == null)
            {
                return NotFound();
            }

            
            await _interfaceFavorite.GetEntityById(id);
            return Ok();
        }

       



        //// Método para deletar um registro pelo ID
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //   
        //    var existingFavorite = await _interfaceFavorite.GetEntityById(id);
        //    if (existingFavorite == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    // Se o registro existe, então o excluímos
        //    await _interfaceFavorite.Delete(existingFavorite);
        //    return Ok();     
        //}
        //
        [HttpDelete("DeleteByRepoName")]
       
        public async Task<IActionResult> DeleteByRepoName(string repoName)
        {
            // Busca o registro do favorito pelo nome do repositório
            var result = await _interfaceFavorite.List();
            var resultFinal = result.FirstOrDefault(x => x.RepoName.Equals(repoName));
            if (resultFinal == null)
            {
                return NotFound();
            }

            // Se o registro existe, então o excluímos
            await _interfaceFavorite.Delete(resultFinal);
            return Ok();
        }



    }
}
