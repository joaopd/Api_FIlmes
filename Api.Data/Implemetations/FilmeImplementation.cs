using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implemetations
{
  public class FilmeImplementation : BaseRepository<FilmeEntity>, IFilmesRepository
  {
    private DbSet<FilmeEntity> _dataset;
    public FilmeImplementation(MyContext context) : base(context)
    {
      _dataset = context.Set<FilmeEntity>();
    }

    public async Task<IEnumerable<FilmeEntity>> GetAtores(string Atores)
    {
      var comp = Atores;
      var diretor = _context.Filmes
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
      return await diretor.ToListAsync();
    }

    public async Task<IEnumerable<FilmeEntity>> GetDiretor(string Diretor)
    {
      var comp = Diretor;
      var diretor = _context.Filmes
              .Where(g => g.Diretor == comp)
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
      return await diretor.ToListAsync();
    }

    public async Task<IEnumerable<FilmeEntity>> GetGenero(string Genero)
    {
      var genero = Genero;
      var atores = _context.Filmes
              .Where(g => g.Genero == genero)
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
      return await atores.ToListAsync();
    }

    public async Task<IEnumerable<FilmeEntity>> GetList()
    {
      var atores = _context.Filmes
          .OrderBy(p => p.Name)
          .Include(c => c.NomesAtores)
          .Include(c => c.Avaliacao)
          .AsNoTracking();
      return await atores.ToListAsync();
    }

    public async Task<IEnumerable<FilmeEntity>> GetMaisVotado()
    {
      throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<FilmeEntity>> GetName(string Name)
    {
      var name = Name;
      var atores = _context.Filmes
              .Where(g => g.Name == name)
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
      return await atores.ToListAsync();
    }
  }
}
