using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implemetations
{
  public class UserImplemetation : BaseRepository<UserEntity>, IUserRepository
  {
    private DbSet<UserEntity> _dataset;
    public UserImplemetation(MyContext context) : base(context)
    {
      _dataset = context.Set<UserEntity>();
    }
    public async Task<UserEntity> FindByLogin(string Email)
    {
      return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(Email));
    }

    public async Task<UserEntity> FindByLogin1(string senha)
    {
      return await _dataset.FirstOrDefaultAsync(u => u.Senha.Equals(senha));
    }
        public async Task<UserEntity> FindByLogin2(string role)
    {
      return await _dataset.FirstOrDefaultAsync(u => u.Role.Equals(role));
    }
  }
}
