using Microsoft.EntityFrameworkCore;
using WebApiUsers.Context;
using WebApiUsers.Interface;
using WebApiUsers.Models;

namespace WebApiUsers.Repository
{
    public class UsersRepository : IUsers
    {
        readonly DatabaseContext _dbContext = new();

        public UsersRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Users> GetUsersDetails()
        {
            try
            {
                return _dbContext.usuarios.ToList();
            }
            catch { 

                throw ;
            }
        }

        public Users GetUserDetails(int id)
        {
            try
            {
                Users? usuario = _dbContext.usuarios.Find(id);
                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }

        }

        public void AddUser(Users usuario)
        {
            try
            {
                _dbContext.usuarios.Add(usuario);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(Users usuario)
        {
            try
            {
                _dbContext.Entry(usuario).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public Users DeleteUser(int id)
        {
            try
            {
                Users? usuario = _dbContext.usuarios.Find(id);

                if(usuario != null)
                {
                    _dbContext.usuarios.Remove(usuario);
                    _dbContext.SaveChanges();
                    return usuario;
                }
                else
                {
                    throw new ArgumentNullException("Error", "Usuario No encotrado");
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int id)
        {
            return _dbContext.usuarios.Any(e => e.Id == id);
        }


    }//fin de clase
} //fin  namespace
