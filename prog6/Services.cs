using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prog6.Models;

namespace prog6
{
    public class Services
    {
        public async Task<Users> GetById(int userId)
        {
            using (var userRepository = new prog6Context())
            {
                return userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            using (var userRepository = new prog6Context())
            {
                return userRepository.Users.ToList();
            }
        }

        public async Task Create(Users user)
        {
            using (var userRepository = new prog6Context())
            {
                userRepository.Users.Add(user);
                userRepository.SaveChanges();
            }
        }

        public async Task Delete(Users user)
        {
            using (var userRepository = new prog6Context())
            {
                userRepository.Users.Remove(user);
                userRepository.SaveChanges();
            }
        }

        public async Task<IEnumerable<Users>> SearchByName(string name)
        {
            using (var userRepository = new prog6Context())
            {
                return userRepository.Users.Where(u => u.Name == name | u.Surname == name | u.Lastname == name).ToList();
            }
        }

        public static async Task<int> Verification(string login, string password)
        {
            using (var managerRepository = new prog6Context())
            {
                var manager = managerRepository.Managers.Where(m => m.Login == login).FirstOrDefault();
                if (manager != null)
                {
                    if (manager.Password == password) return 1;
                    else return 2;
                }
                return 0;
            }
        }
    }
}
