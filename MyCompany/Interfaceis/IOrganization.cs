using MyCompany.Models;

namespace MyCompany.Interfaceis
{
    public interface IOrganization
    {
        void Add(Organization organization);
        List<Organization> GetAll();
        Organization GetById(Guid id);
        void Remove(Guid organizationId);
        void Update(Organization organization);
        List<Organization> GetCategory();

    }
}
