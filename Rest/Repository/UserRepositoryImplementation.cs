using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Rest.Data.VO;
using Rest.models;
using Rest.Models.Context;

namespace Rest.Repository
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }
        
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return result;
        }

        public User ValidateCredentials(UserVO user)
        {
            var password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            Console.WriteLine(user.UserName+" "+password);
            
            var newPassword  = _context.Users.SingleOrDefault(p => p.UserName.Equals(user.UserName));
            Console.WriteLine(newPassword.UserName+" "+newPassword.Password);

            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == password));
        }

        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}