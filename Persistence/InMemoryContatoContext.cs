using System.Collections.Generic;
using Agenda.Models;

namespace Agenda.Persistence
{
    public class InMemoryContatoContext
    {
        public List<Contato> Contatos { get; set; }

        public InMemoryContatoContext()
        {
            Contatos = new List<Contato>
            {
                new Contato { Id = 1, Nome = "João", Telefone = "1234567890" },
                new Contato { Id = 2, Nome = "Maria", Telefone = "0987654321" },
                new Contato { Id = 3, Nome = "Ivanete", Telefone = "8832145676"}
            };
        }
    }
}