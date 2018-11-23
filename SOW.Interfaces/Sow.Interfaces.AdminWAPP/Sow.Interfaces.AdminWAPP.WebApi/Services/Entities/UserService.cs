using Microsoft.Extensions.Options;
using Sow.Components.Databases.Settings;
using Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Entities;
using Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Interfaces;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using Sow.Interfaces.AdminWAPP.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Services.Entities
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _userRepository = new UserRepository(mongoDbSettings);
        }

        public async Task<User> Add(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("O campo Senha é obrigatório!");

            if (await _userRepository.GetByUsername(user.Username) != null)
                throw new Exception(String.Format("O Nome de Usu[ario {0} já está em uso!", user.Username));

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Add(user);

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("O campo Senha é obrigatório!");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("O campo Senha é obrigatório!");
            //TDB: if (password == null) throw new ArgumentNullException("password");
            //if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            //var user = _context.Users.SingleOrDefault(x => x.Username == username);
            var user = await _userRepository.GetByUsername(username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<ICollection<User>> GetAllByUsername(string username)
        {
            return await _userRepository.GetAllByUsername(username);
        }

        public async Task<User> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userRepository.GetByUsername(username);
        }

        public async Task Update(User userParam, string password = null)
        {
            var user = await _userRepository.GetById(userParam.Id);

            if (user == null)
                throw new Exception("Usuário não encontrado!");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (await _userRepository.GetByUsername(userParam.Username) != null)
                    throw new Exception(String.Format("Username {0} is already taken!", userParam.Username));
            }

            // update user properties
            user.ClientId = userParam.ClientId;
            user.Email = userParam.Email;
            user.Name = userParam.Name;
            user.Status = userParam.Status;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            await _userRepository.Update(user);
        }
    }
}
