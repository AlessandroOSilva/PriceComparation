using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricesComparation.Models;
using PricesComparation.Models.Context;
using PricesComparation.Repositories.Generics;

namespace PricesComparation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericRepository<Brand> _brandRepository;

        public BrandsController(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrand()
        {
            return await _brandRepository.FindAll();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(long id)
        {
            return await _brandRepository.FindById(id);

        }

    }
}
