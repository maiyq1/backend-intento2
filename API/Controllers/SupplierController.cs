using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Model;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierDomain _supplierDomain;
        private ISupplierData _supplierData;
        private IMapper _mapper;

        public SupplierController(ISupplierDomain supplierDomain, ISupplierData supplierData, IMapper mapper)
        {
            _supplierDomain = supplierDomain;
            _supplierData = supplierData;
            _mapper = mapper;
        }
        
        // GET: api/Supplier
        [HttpGet]
        public List<Supplier> Get()
        {
            return _supplierData.GetAll();
        }

        // POST: api/Supplier
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Supplier/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
