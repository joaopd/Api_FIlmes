using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Api.Service.Services
{
  public class LoginService : ILoginService
  {
    private IUserRepository _repository;
    public SigningConfigurations _signingConfigurations;
    public TokenConfigurations _tokenConfigurations;
    public IConfiguration _iConfiguration;

    public LoginService(IUserRepository repository,
                        SigningConfigurations signingConfigurations,
                        TokenConfigurations tokenConfigurations,
                        IConfiguration iConfiguration)
    {
      _repository = repository;
      _signingConfigurations = signingConfigurations;
      _tokenConfigurations = tokenConfigurations;
      _iConfiguration = iConfiguration;
    }


    public async Task<object> FindByLogin(LoginDto user)
    {
      var baseUser = new UserEntity();


      if (user != null && !string.IsNullOrWhiteSpace(user.Email))
      {

        baseUser = await _repository.FindByLogin(user.Email);
        

        if (baseUser == null || baseUser.Senha != user.Password)
        {
          return new
          {
            autenticated = false,
            message = "Nao foi possivel efetuar login, Usuario ou senha incorreto"
          };

        }
        else
        {
          ClaimsIdentity identity = new ClaimsIdentity(
            new GenericIdentity(baseUser.Email),
            new Claim[]
            {
              new Claim(ClaimTypes.Name, user.Email.ToString()),
              new Claim(ClaimTypes.Role, user.Role.ToString())

            }
          );

          DateTime createDate = DateTime.Now;
          DateTime expirionDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

          var handler = new JwtSecurityTokenHandler();

          string token = CreateToken(identity, createDate, expirionDate, handler);
          return SuccesObject(createDate, expirionDate, token, user);
        }
      }
      else
        return new
        {
          autenticated = false,
          message = "Falha ao autenticar"
        };
    }

    private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirionDate, JwtSecurityTokenHandler handler)
    {
      var securityToken = handler.CreateToken(new SecurityTokenDescriptor
      {
        Issuer = _tokenConfigurations.Issuer,
        Audience = _tokenConfigurations.Audience,
        SigningCredentials = _signingConfigurations.SigningCredentials,
        Subject = identity,
        NotBefore = createDate,
        Expires = expirionDate,
      });

      var token = handler.WriteToken(securityToken);
      return token;
    }
    private object SuccesObject(DateTime createDate, DateTime expirionDate, string token, LoginDto user)
    {
      return new
      {
        authenticated = true,
        created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
        expiration = expirionDate.ToString("yyyy-MM-dd HH:mm:ss"),
        acessToken = token,
        userName = user.Email,
        Roles = user.Role,
        messege = "Usuario logado com Sucesso"
      };
    }
  }
}
