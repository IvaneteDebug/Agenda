using Agenda.Models;

namespace Agenda.Services
{
    public interface IContatoService
    {
        IEnumerable<Contato> ListarContatos();
        Contato ObterContatoPorId(int id);
        Contato AdicionarContato(Contato contato);
        void AtualizarContato(Contato contato);
        void RemoverContato(int id);
    }
}