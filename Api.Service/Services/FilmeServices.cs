using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Filmes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
  public class FilmeServices : IFilmeServices
  {
    protected readonly MyContext _context;
    private DbSet<FilmeEntity> _dataSet;
    private IRepository<FilmeEntity> _repository;


    private readonly IMapper _mapper;
    public FilmeServices(IRepository<FilmeEntity> repository, MyContext context, IMapper mapper)
    {

      _repository = repository;
      _context = context;
      _dataSet = context.Set<FilmeEntity>();
      _mapper = mapper;
    }


    public async Task<bool> Delete(int id)
    {

      return await _repository.DeleteAsync(id);
    }

    public async Task<FilmesDto> Get(int id)
    {
      var entity = await _repository.SelectAsync(id);
      return _mapper.Map<FilmesDto>(entity);
    }

    public Task<IEnumerable<FilmesDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<FilmesDto>> GetAtores(string Atores)
    {
      var comp = Atores;
      var atores = _context.Filmes
            .OrderBy(p => p.Name)
            .Include(c => c.NomesAtores)
            .Include(c => c.Avaliacao)
            .AsNoTracking();
      var entity = await atores.ToListAsync();
      return _mapper.Map<IEnumerable<FilmesDto>>(entity);
    }

    public async Task<IEnumerable<FilmesDto>> GetDiretor(string Diretor)
    {
      var comp = Diretor;
      var diretor = _context.Filmes
            .Where(g => g.Diretor == comp)
            .OrderBy(p => p.Name)
            .Include(c => c.NomesAtores)
            .Include(c => c.Avaliacao)
            .AsNoTracking();
      var entity = await diretor.ToListAsync();
      return _mapper.Map<IEnumerable<FilmesDto>>(entity);
    }

    public async Task<IEnumerable<FilmesDto>> GetGenero(string Gernero)
    {
      try
      {
        var gen = Gernero;
        var gernero = _context.Filmes
              .Where(g => g.Gernero == gen)
              .OrderBy(p => p.Name)
              .Include(c => c.NomesAtores)
              .Include(c => c.Avaliacao)
              .AsNoTracking();
        var entity = await gernero.ToListAsync();
        return _mapper.Map<IEnumerable<FilmesDto>>(entity);
      }
      catch (Exception ex)
      {

        throw ex;
      }
    }

    public async Task<IEnumerable<FilmesDto>> GetList()
    {
      var atores = _context.Filmes
     .OrderBy(p => p.Name)
     .Include(c => c.NomesAtores)
     .Include(c => c.Avaliacao)
     .AsNoTracking();
      var entity = await atores.ToListAsync();
      return _mapper.Map<IEnumerable<FilmesDto>>(entity);
    }

    public Task<IEnumerable<FilmesDto>> GetMaisVotado()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<FilmesDto>> GetName(string Name)
    {
      var nam = Name;
      var name = _context.Filmes
            .Where(g => g.Name == nam)
            .OrderBy(p => p.Name)
            .Include(c => c.NomesAtores)
            .Include(c => c.Avaliacao)
            .AsNoTracking();
      var entity = await name.ToListAsync();
      return _mapper.Map<IEnumerable<FilmesDto>>(entity);
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
