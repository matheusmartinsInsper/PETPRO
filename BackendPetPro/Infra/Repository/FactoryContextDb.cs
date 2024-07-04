using BackendPetPro.Application.IRepository;

namespace BackendPetPro.Infra.Repository
{
    public class FactoryContextDb : IFactoryContextDb
    {
        public IDbContext psqlContext()
        {
            return new PGSQLContext();
        }
    }
}
