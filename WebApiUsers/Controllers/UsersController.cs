using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUsers.Interface;
using WebApiUsers.Models;
namespace WebApiUsers.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _IUser;

        public UsersController(IUsers IUser)
        {
            _IUser = IUser;
        }

        // GET: api/users> Todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await Task.FromResult(_IUser.GetUsersDetails());
        }

        // GET api/users/id Obterner un usuario por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var usuario = await Task.FromResult(_IUser.GetUserDetails(id));
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        // POST api/users Agregar un usuario
        [HttpPost]
        public async Task<ActionResult<Users>> Post(Users usuario)
        {
            _IUser.AddUser(usuario);
            return await Task.FromResult(usuario);
        }

        // PUT api/users/id Modificar un usuario por id
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> Put(int id, Users usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            try
            {
                _IUser.UpdateUser(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(usuario);
        }


        // DELETE api/users/id Eliminar un usuario por id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> Delete(int id)
        {
            var usuario = _IUser.DeleteUser(id);
            return await Task.FromResult(usuario);
        }

        //Chequear si el id del usuario existe.
        private bool UserExists(int id)
        {
            return _IUser.CheckUser(id);
        }


    } //fin clase
} //fin namespace
