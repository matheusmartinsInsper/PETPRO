using BackendPetPro.Domain.DTO;
using System;
namespace BackendPetPro.Domain.Agregate.Entities
{
    public class User
    {
        public string email;
        public string name;
        public string password;
        public string? cpf;
        public string? cnpj;
        public string? cep;
        public string? adress;
        public string? crmv;
        private string _id;
        private string _categoryCode;
        private void constructor() { }
        public User create(UserTutor user)
        {
            User _user = new User();
            _user.email = user.email;
            _user.name = user.name==null?"erro":user.name;
            _user.password = user.password;
            _user._id = Guid.NewGuid().ToString("N");
            _user._categoryCode = "T01";
            return _user;
        }
        public User create(UserClinic user)
        {
            User _user = new User();
            _user.email = user.email;
            _user.name = user.name == null ? "erro" : user.name;
            _user.password = user.password;
            _user.cep = user.cep;
            _user.cnpj = user.cnpj;
            _user._id = Guid.NewGuid().ToString("N");
            _user._categoryCode = "B01";
            return _user;
        }
        public User restore()
        {
            return new User();
        }
        public void setPassWord(string pass)
        {
            if (pass == null || pass == password)
            {
                throw new Exception("senha invalida ou igual a anterior");
            }
            password = pass;
        }
    }
}
