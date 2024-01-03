using System.Linq;
using Agenda.Models;
using Agenda.Persistence;
using System;
using System.Collections.Generic;

namespace Agenda.Services
{
    public class ContatoService : IContatoService
    {
        private readonly InMemoryContatoContext _context;

        public ContatoService(InMemoryContatoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public IEnumerable<Contato> ListarContatos()
        {
            return _context.Contatos;
        }

        public Contato ObterContatoPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(c => c.Id == id) ?? throw new Exception("Contato não encontrado.");
        }

        public Contato AdicionarContato(Contato novoContato)
        {
            novoContato.Id = _context.Contatos.Count + 1;
            _context.Contatos.Add(novoContato);
            return novoContato;
        }

        public void AtualizarContato(Contato contatoAtualizado)
        {
            var contatoExistente = _context.Contatos.FirstOrDefault(c => c.Id == contatoAtualizado.Id);
            if (contatoExistente != null)
            {
                contatoExistente.Nome = contatoAtualizado.Nome;
                contatoExistente.Telefone = contatoAtualizado.Telefone;
            }
        }

        public void RemoverContato(int id)
        {
            var contatoExistente = _context.Contatos.FirstOrDefault(c => c.Id == id);
            if (contatoExistente != null)
            {
                _context.Contatos.Remove(contatoExistente);
            }
        }
    }
}