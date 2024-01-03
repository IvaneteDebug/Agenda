using Agenda.Services;
using Agenda.Models;
using Agenda.Persistence;
using System;

namespace Agenda
{
    public static class Program
    {
        private static readonly IContatoService _service;

        static Program()
        {
            var context = new InMemoryContatoContext(); 
            _service = new ContatoService(context);
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                MostrarOpcoes();
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarContatos();
                        break;

                    case "2":
                        AdicionarContato();
                        break;

                    case "3":
                        AtualizarContato();
                        break;

                    case "4":
                        RemoverContato();
                        break;

                    case "5":
                        Console.WriteLine("Saindo da Agenda. Até mais!");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente Novamente.");
                        break;
                }
            }
        }

        public static void MostrarOpcoes()
        {
            Console.WriteLine("\n### Agenda de Contatos ###");
            Console.WriteLine("1- Listar Contatos");
            Console.WriteLine("2- Adicionar Contato");
            Console.WriteLine("3- Atualizar Contato");
            Console.WriteLine("4- Remover Contato");
            Console.WriteLine("5- Sair");
            Console.Write("Escolha uma Opção: ");
        }

        public static void ListarContatos()
        {
            var contatos = _service.ListarContatos();
            Console.WriteLine("\n### Lista de Contatos ###");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"ID: {contato.Id} - Nome: {contato.Nome} - Telefone: {contato.Telefone}");
            }
        }

        public static void AdicionarContato()
        {
            Console.Write("Digite o nome do contato: ");
            var nome = Console.ReadLine();

            Console.Write("Digite o telefone do contato: ");
            var telefone = Console.ReadLine();

            var novoContato = new Contato { Nome = nome, Telefone = telefone };
            _service.AdicionarContato(novoContato);
            Console.WriteLine("Contato adicionado com sucesso!");
        }

        public static void AtualizarContato()
        {
             Console.Write("Digite o Id do contato que deseja atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contatoExistente = _service.ObterContatoPorId(id);
                if (contatoExistente != null)
                {
                    Console.Write("Digite o novo nome do contato: ");
                    contatoExistente.Nome = Console.ReadLine();

                    Console.Write("Digite o novo telefone do contato: ");
                    contatoExistente.Telefone = Console.ReadLine();

                    _service.AtualizarContato(contatoExistente);
                    Console.WriteLine("Contato atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Contato não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
        }

        public static void RemoverContato()
        {
             Console.Write("Digite o Id do contato que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contatoExistente = _service.ObterContatoPorId(id);
                if (contatoExistente != null)
                {
                    _service.RemoverContato(id);
                    Console.WriteLine("Contato removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Contato não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Id inválido.");
            }
        }
    }
}