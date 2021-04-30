using ApiCatalogoJogos.Businnes.Entities;
using ApiCatalogoJogos.Businnes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InfraStructure.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("ddf38827-74ed-4d19-809f-862495157349"), new Jogo{Id=Guid.Parse("ddf38827-74ed-4d19-809f-862495157349"), Nome="Fifa 18", Produtora="EA", Preco=170.0 } },
            {Guid.Parse("efaee6ce-975f-44af-a773-f6f5b3d583cd"), new Jogo{Id=Guid.Parse("efaee6ce-975f-44af-a773-f6f5b3d583cd"), Nome="Fifa 19", Produtora="EA", Preco=180.0 } },
            {Guid.Parse("319fee53-4c3c-4038-bb77-a1e3287bf2d0"), new Jogo{Id=Guid.Parse("319fee53-4c3c-4038-bb77-a1e3287bf2d0"), Nome="Fifa 20", Produtora="EA", Preco=190.0 } },
            {Guid.Parse("5ecc7ee8-0bb9-4666-8c13-414a08679a53"), new Jogo{Id=Guid.Parse("5ecc7ee8-0bb9-4666-8c13-414a08679a53"), Nome="Fifa 21", Produtora="EA", Preco=200.0 } },
            {Guid.Parse("c3ba93ce-5116-4655-9551-fb38e56899ce"), new Jogo{Id=Guid.Parse("c3ba93ce-5116-4655-9551-fb38e56899ce"), Nome="Street Fighter V", Produtora="Capcom", Preco=80.0 } },
            {Guid.Parse("0d012814-ca08-4972-823c-36a608a73b22"), new Jogo{Id=Guid.Parse("0d012814-ca08-4972-823c-36a608a73b22"), Nome="Grand Theft Auto V", Produtora="Rockstar", Preco=90.0 } }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar com o banco
        }
    }
}
