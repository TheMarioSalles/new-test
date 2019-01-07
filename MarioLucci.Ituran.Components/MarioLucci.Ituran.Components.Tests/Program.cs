using Sow.Components.Databases.Settings;
using Sow.Components.Tests.Models.Entities;
using Sow.Components.Tests.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sow.Components.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //MongoDbSettings settings = new MongoDbSettings("mongodb://localhost:27017", "TestUser");

            try
            {
                //    UserRepository userRepository = new UserRepository(settings);
                //    User user = new User();
                //    user.Name = Console.ReadLine();
                //    userRepository.Add(user);
                //    Console.WriteLine(String.Format("Usuário {0} adicionado com sucesso!", user.Name));

                //    Task<ICollection<User>> UserList = userRepository.GetAll();
                //    //foreach (var item in UserList)
                //    //    Console.WriteLine(String.Format("ID do Usuário: {0}. Nome do Usuário: {1}", item.Id, item.Name));
                //    Console.Write("Pressione para sair!");
                //    Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
