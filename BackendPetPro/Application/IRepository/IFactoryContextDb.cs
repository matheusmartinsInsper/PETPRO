using System.Text.Json.Nodes;

namespace BackendPetPro.Application.IRepository
{
    public interface IFactoryContextDb
    {
        public IDbContext psqlContext();
    }
}
