using MyCompany.Interfaceis;
using MyCompany.Models;

namespace MyCompany
{
    public class SotrudnikRepository : ISotrudnik
    {
        private readonly DatabaseContext databaseContext;

        public SotrudnikRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Sotrudnik sotrudnik)
        {

            databaseContext.Sotrudniks.Add(sotrudnik);
            databaseContext.SaveChanges();
        }

        public List<Sotrudnik> GetAll()
        {
            return databaseContext.Sotrudniks.ToList();
        }

        public Sotrudnik GetById(Guid id)
        {
            return databaseContext.Sotrudniks.FirstOrDefault(x => x.Id == id);
        }



        public void Remove(Guid sotrudnikId)
        {
            var products = databaseContext.Sotrudniks.FirstOrDefault(x => x.Id == sotrudnikId);
            databaseContext.Sotrudniks.Remove(products);
            databaseContext.SaveChanges();
        }

        public void Update(Sotrudnik sotrudnik)
        {
            databaseContext.Sotrudniks.Update(sotrudnik);

            databaseContext.SaveChanges();
        }
    }
}
