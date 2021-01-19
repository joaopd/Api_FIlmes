using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implemetations
{
  public class AvaliarImplemetation : BaseRepository<AvaliacaoEntity>, IAvaliarRepository
  {
    private DbSet<AvaliacaoEntity> _dataSet;

    public AvaliarImplemetation(MyContext context) : base(context)
    {
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
