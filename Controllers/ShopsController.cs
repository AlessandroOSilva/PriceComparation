using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PricesComparation.Models;
using PricesComparation.Repositories.Generics;

namespace PricesComparation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IGenericRepository<Shop> _genericRepository;

        public ShopsController(IGenericRepository<Shop> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>>GetShop()
        {
            return await _genericRepository.FindAll();

        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(long id)
        {
            var shop = await _genericRepository.FindById(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }
    }
}
