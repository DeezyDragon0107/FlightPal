using FlightPal.Models.Entities;
using FlightPal.Models.ViewModels;
using FlightPal.Data;
using FirebirdSql.Data.FirebirdClient;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BCrypt.Net;
using System.Reflection.Metadata.Ecma335;

namespace FlightPal.Services
{
    public interface IAuthService
    {
        public Task<Users> ValidateUser(string username, string password);
        public Task<bool> VerifyIfUserExists(string dni);
    }

    public class AuthService : IAuthService
    {
        private readonly IDatabaseConnection _context;
       
        public AuthService(IDatabaseConnection context)
        {
            _context = context;
        

        }
 
        public async Task<Users> ValidateUser(string email, string password)
        {
           FbConnection conn = await _context.GetConnectionAsync();
            var sql = "SELECT * FROM USERS WHERE EMAIL = @Email";
            try
            {

                Users user = await conn.QueryFirstOrDefaultAsync<Users>(sql, new { Email = email.ToUpper()});
                if(user == null)
                {
                    return null;
                }
                if(BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
                {
                    return user;
                }
                else
                {
                    return null;
                }
               
            }
            catch(Exception ex)
            {
                return null;
            }
            
            

           
        }

        public async Task<bool> VerifyIfUserExists(string dni)
        {
            FbConnection connection = await _context.GetConnectionAsync();
            var sql = "SELECT COUNT(*) FROM USERS WHERE EMAIL = @Email OR DNI = @Dni";
            try
            {
               
               int resultado = await connection.QueryFirstOrDefaultAsync<int>(sql, new { Email = dni, Dni = dni });
                if (resultado > 0)
                {
                    return true;
                }
               
                
            }
            catch (Exception ex) { 
                Console.WriteLine("Excepcion: "+ex.Message);
            }

            return false;
        }
    }
}
