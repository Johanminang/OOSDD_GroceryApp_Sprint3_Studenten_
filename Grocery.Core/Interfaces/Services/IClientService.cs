﻿using Grocery.Core.Models;
using System.Globalization;

namespace Grocery.Core.Interfaces.Services
{
    public interface IClientService
    {
        public Client? Get(string email);

        public Client? Get(int id);


        public List<Client> GetAll();

        public Client Register(string name, string email, string password);
    }
}
