//using Microsoft.Extensions.Options;
//using Sow.Components.Databases.Settings;
//using MarioLucci.Ituran.Api.Infra.Repositories.Entities;
//using MarioLucci.Ituran.Api.Models.Entities;
//using MarioLucci.Ituran.Api.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MarioLucci.Ituran.Api.Services.Entities
//{
//    public class ClientService : IClientService
//    {
//        private ClientRepository _clientRepository;

//        public ClientService(IOptions<MongoDbSettings> mongoDbSettings)
//        {
//            _clientRepository = new ClientRepository(mongoDbSettings);
//        }

//        public async Task<Client> Add(Client client)
//        {
//            if (await _clientRepository.GetByDocument(client.Document) != null)
//                throw new Exception(String.Format("O documento {0} já está em uso!", client.Document));

//            await _clientRepository.Add(client);

//            return client;
//        }

//        public async Task<ICollection<Client>> GetAll()
//        {
//            return await _clientRepository.GetAll();
//        }

//        public async Task<Client> GetById(string id)
//        {
//            return await _clientRepository.GetById(id);
//        }

//        public async Task<bool> Update(Client clientParam)
//        {
//            var client = await _clientRepository.GetById(clientParam.Id);

//            if (client == null)
//                throw new Exception("Cliente não encontrado!");

//            if (clientParam.Document != client.Document)
//            {
//                if (await _clientRepository.GetByDocument(clientParam.Document) != null)
//                    throw new Exception(String.Format("O Documento {0} já está em uso!", clientParam.Document));
//            }

//            client.Name = clientParam.Name;
//            client.Document = clientParam.Document;
//            client.AgentsQuantity = clientParam.AgentsQuantity;
//            client.Accounts = clientParam.Accounts;
//            // client.Image = clientParam.Image;
//            client.Status = clientParam.Status;

//            return await _clientRepository.Update(client);
//        }

//        #region Account

//        public async Task AddAccount(Client client, Account account)
//        {
//            if (client.Accounts.Where(x => x.Document == account.Document).FirstOrDefault() != null)
//                throw new Exception(String.Format("Já existe uma conta com o documento {0}!", account.Document));
//            else
//            {
//                account.Id = Guid.NewGuid();
//                client.Accounts.Add(account);
//            }
//        }

//        public async Task UpdateAccount(Client client, Account accountParam)
//        {
//            var account = client.Accounts.Where(x => x.Id == accountParam.Id).FirstOrDefault();

//            if (account == null)
//                throw new Exception(String.Format("Conta {0} não encontrada!", account.Name));
//            else
//            {
//                if (accountParam.Document != account.Document)
//                {
//                    if (client.Accounts.Where(x => x.Document == accountParam.Document).FirstOrDefault() != null)
//                        throw new Exception(String.Format("Já existe uma conta com o documento {0}!", accountParam.Document));
//                }
//                account.Name = accountParam.Name;
//                account.Document = accountParam.Document;
//                account.Agents = accountParam.Agents;
//                account.EndPoints = accountParam.EndPoints;
//                account.Status = accountParam.Status;
//            }
//        }

//        #endregion
//    }
//}
