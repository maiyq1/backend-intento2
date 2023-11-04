using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Request;
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
    public class UserController : ControllerBase
    {
        private IUserDomain _userDomain;
        private IUserData _userData;
        private IMapper _mapper;

        public UserController(IUserDomain userDomain, IUserData userData, IMapper mapper)
        {
            _userDomain = userDomain;
            _userData = userData;
            _mapper = mapper;
        }
        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            return _userData.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public string Post([FromBody] UserRequest userRequest)
        {
            var user = _mapper.Map<UserRequest, User>(userRequest);
            if (!(_userDomain.create(user)))
            {
                return "Corrige los datos de usuario";
            }
            else
            {
                return "El usuario se ha creado correctamente.";
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public string Put([FromBody] UserRequest userRequest, int id)
        {
            var user = _mapper.Map<UserRequest, User>(userRequest);
            if (_userDomain.update(user, id))
            {
                return "Los datos se actualizaron correctamente.";
            }
            else
            {
                return "No se pudo actualizar los datos del usuario.";
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userDomain.delete(id);
        }
    }
}
