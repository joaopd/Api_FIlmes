namespace Api.Domain.Models
{
    public class UserModel
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
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        
    }
}
