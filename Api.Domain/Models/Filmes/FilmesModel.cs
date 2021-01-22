namespace Api.Domain.Models.Filmes
{
  public class FilmesModel
  {
    private int _Id;
    public int Id
    {
      get { return _Id; }
      set { _Id = value; }
    }

    private string _name;
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    private string _diretor;
    public string Diretor
    {
      get { return _diretor; }
      set { _diretor = value; }
    }
    private string _imagem;
    public string Imagem
    {
      get { return _imagem; }
      set { _imagem = value; }
    }
    private string _nomesAtores;
    public string NomesAtores
    {
      get { return _nomesAtores; }
      set { _nomesAtores = value; }
    }

    private string _avaliacao;
    public string Avaliacao
    {
      get { return _avaliacao; }
      set { _avaliacao = value; }
    }

  }
}
