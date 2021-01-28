using System.Collections.Generic;
using Api.Domain.Dto;
using Api.Domain.Dto.User;

namespace Api.Service.Test.Filmes
{
  public class FilmesTeste
  {
    public static int IdFilmes { get; set; }
    public static string NomeFilmes { get; set; }
    public static string GeneroFilmes { get; set; }
    public static string DiretorFilmes { get; set; }
    public static string ImagemFIlmes { get; set; }
    public static string NomeFilmesAlterado { get; set; }
    public static string GeneroFilmesAlterado { get; set; }
    public static string DiretorFilmesAlterado { get; set; }
    public static string ImagemFIlmesAlterado { get; set; }

    public List<FilmesDto> listaFilmesDto = new List<FilmesDto>();

    public FilmesDto filmesDto;
    public FilmesDtoCreate filmesDtoCreate;
    public FilmesDtoCreateReult filmesDtoCreateReult;
    public FilmesDtoUpdate filmesDtoUpdate;
    public FilmesDtoUpdateReult filmesDtoUpdateReult;

    public FilmesTeste()
    {
      IdFilmes = Faker.RandomNumber.Next();
      NomeFilmes = Faker.Name.Last();
      GeneroFilmes = Faker.Name.Prefix();
      DiretorFilmes = Faker.Name.FullName();
      ImagemFIlmes = Faker.Internet.FreeEmail();
      NomeFilmesAlterado = Faker.Name.Last();
      GeneroFilmesAlterado = Faker.Name.Prefix();
      DiretorFilmesAlterado = Faker.Name.FullName();
      ImagemFIlmesAlterado = Faker.Internet.FreeEmail();

      for (int i = 0; i < 10; i++)
      {
        var filme = new FilmesDto()
        {
          Id = Faker.RandomNumber.Next(),
          Name = Faker.Name.First(),
          Genero = Faker.Name.First(),
          Diretor = Faker.Name.FullName()
        };
        listaFilmesDto.Add(filme);
      }
      filmesDto = new FilmesDto
      {
        Id = IdFilmes,
        Name = NomeFilmes,
        Genero = GeneroFilmes,
        Diretor = DiretorFilmes,
        Imagem = ImagemFIlmes
      };
      filmesDtoCreate = new FilmesDtoCreate
      {
        Name = NomeFilmes,
        Genero = GeneroFilmes,
        Diretor = DiretorFilmes,
        Imagem = ImagemFIlmes
      };
      filmesDtoCreateReult = new FilmesDtoCreateReult
      {
        Name = NomeFilmes,
        Genero = GeneroFilmes,
        Diretor = DiretorFilmes,
        Imagem = ImagemFIlmes
      };
      filmesDtoUpdate = new FilmesDtoUpdate
      {
        Name = NomeFilmes,
        Genero = GeneroFilmes,
        Diretor = DiretorFilmes,
        Imagem = ImagemFIlmes
      };
      filmesDtoUpdateReult = new FilmesDtoUpdateReult
      {
        Name = NomeFilmes,
        Genero = GeneroFilmes,
        Diretor = DiretorFilmes,
        Imagem = ImagemFIlmes
      };
    }
  }
}
