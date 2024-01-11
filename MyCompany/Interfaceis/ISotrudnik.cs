using MyCompany.Models;

namespace MyCompany.Interfaceis
{
    public interface ISotrudnik
    {
        void Add(Sotrudnik sotrudnik);
        List<Sotrudnik> GetAll();
        Sotrudnik GetById(Guid id);
        void Remove(Guid sotrudnikId);
        void Update(Sotrudnik sotrudnik);

    }
}
