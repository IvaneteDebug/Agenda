using Agenda.Services;
using Agenda.Models;
using System.Collections.Generic;

namespace Agenda.Controllers
{
    public class ContatoController
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public IEnumerable<Contato> ListarContatos()
        {
            return _contatoService.ListarContatos();
        }

        public Contato ObterContatoPorId(int id)
        {
            return _contatoService.ObterContatoPorId(id);
        }

        public Contato AdicionarContato(Contato novoContato)
        {
            return _contatoService.AdicionarContato(novoContato);
        }

        public void AtualizarContato(Contato contatoAtualizado)
        {
            _contatoService.AtualizarContato(contatoAtualizado);
        }

        public void RemoverContato(int id)
        {
            _contatoService.RemoverContato(id);
        }
    }
}