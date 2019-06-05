using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        public UsersController(IUsersService usersServices, IMapper mapper)
        {
            _usersService = usersServices;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        // GET: api/Users
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("La petición es incorrecta");
                }
                var users = _usersService.GetUsers();
                return _mapper.Map<IEnumerable<UserModel>>(users);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
        }
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Users/5
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "Get")]
        public UserModel Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("La petición es incorrecta");
                }
                var user = _usersService.GetUser(id);
                return _mapper.Map<UserModel>(user);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST: api/Users
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<UserModel> PostAsync([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("La petición es incorrecta");
                }
                var userModel = await _usersService.UpdateUser(user);
                return _mapper.Map<UserModel>(userModel);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Uodate user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // PUT: api/Users/5
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        [HttpPut]
        public async Task<UserModel> PutAsync([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("La petición es incorrecta");
                }
                var userModel = await _usersService.UpdateUser(user);
                return _mapper.Map<UserModel>(userModel);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [ProducesResponseType(typeof(Boolean), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("La petición es incorrecta");
                }
                var delete = await _usersService.DeleteUser(id);
                return delete;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
