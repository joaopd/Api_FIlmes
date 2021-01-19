using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Filmes;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
  public class AvaliarService : IAvaliarService
  {
    protected readonly MyContext _context;
    private DbSet<AvaliacaoEntity> _dataSet;
    private IRepository<AvaliacaoEntity> _repository;

    public AvaliarService(IRepository<AvaliacaoEntity> repository, MyContext context)
    {
      _repository = repository;
      _context = context;
      _dataSet = context.Set<AvaliacaoEntity>();
    }

    public async Task<AvaliacaoEntity> Avaliar(AvaliacaoEntity item)
    {
      try
      {

        _dataSet.Add(item);

        await _context.SaveChangesAsync();

      }
      catch (Exception ex)
      {

        throw ex;
      }
      return item;
    }
  }
}
