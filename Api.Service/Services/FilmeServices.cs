using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Filmes;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
  public class FilmeServices : IFilmeServices
  {
    protected readonly MyContext _context;
    private DbSet<FilmeEntity> _dataSet;
    private IRepository<FilmeEntity> _repository;
    private IRepository<UserEntity> _Acesso;


    public FilmeServices(IRepository<FilmeEntity> repository, IRepository<UserEntity> Acesso, MyContext context)
    {
      _Acesso = Acesso;
      _repository = repository;
      _context = context;
      _dataSet = context.Set<FilmeEntity>();
    }


    public async Task<bool> Delete(int id)
    {

      return await _repository.DeleteAsync(id);
    }

    public async Task<FilmeEntity> Get(int id)
    {

      return await _repository.SelectAsync(id);
    }

    public Task<IEnumerable<FilmeEntity>> GetAll()
    {
      throw new NotImplementedException();
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

    public async Task<IEnumerable<FilmeEntity>> GetGenero(string Gernero)
    {
      try
      {
        var genero = Gernero;
        var atores = _context.Filmes
              .Where(g => g.Gernero == genero)
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
        return await atores.ToListAsync();
      }
      catch (Exception ex)
      {

        throw ex;
      }
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

    public Task<IEnumerable<FilmeEntity>> GetMaisVotado()
    {
      throw new NotImplementedException();
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

    public async Task<FilmeEntity> Post(FilmeEntity filme)
    {

      return await _repository.InsertAsync(filme);
    }

    public async Task<FilmeEntity> Put(FilmeEntity filme)
    {
      return await _repository.UpdateAsync(filme);
    }
  }
}
