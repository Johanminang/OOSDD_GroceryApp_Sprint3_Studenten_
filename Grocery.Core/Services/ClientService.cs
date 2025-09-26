using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public Client? Get(string email)
        {
            return _clientRepository.Get(email);
        }

        public Client? Get(int id)
        {
            return _clientRepository.Get(id);
        }

        public List<Client> GetAll()
        {
            List<Client> clients = _clientRepository.GetAll();
            return clients;
        }

        public Client Register(string name, string email, string password)
        {
            // Controleer of email al bestaat
            if (_clientRepository.Get(email) != null)
                throw new Exception("Dit e-mailadres is al geregistreerd.");

            // Hash het wachtwoord - dit retourneert al de volledige hash string
            string hashedPassword = PasswordHelper.HashPassword(password);

            // Genereer nieuw ID
            var all = _clientRepository.GetAll();
            int newId = all.Count == 0 ? 1 : all.Max(c => c.Id) + 1;

            // Gebruik de gehashte wachtwoord direct
            var newClient = new Client(newId, name, email, hashedPassword);

            // Opslaan in repository
            _clientRepository.Add(newClient);
            return newClient;
        }
    }
}
