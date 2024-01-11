using MyCompany.Interfaceis;
using MyCompany.Models;

namespace MyCompany
{
	public class OrganizationRepository : IOrganization
	{
		private readonly DatabaseContext databaseContext;


		public OrganizationRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;

		}

		public void Add(Organization organization)
		{
			databaseContext.Organizations.Add(organization);
			databaseContext.SaveChanges();
		}

		public List<Organization> GetAll()
		{
			return databaseContext.Organizations.ToList();

		}

		public Organization GetById(Guid id)
		{
			return databaseContext.Organizations.FirstOrDefault(x => x.Id == id);
		}

		public void Remove(Guid organizationId)
		{
			var products = databaseContext.Organizations.FirstOrDefault(x => x.Id == organizationId);
			databaseContext.Organizations.Remove(products);

			databaseContext.SaveChanges();
		}

		public void Update(Organization organization)
		{

			databaseContext.Organizations.Update(organization);

			databaseContext.SaveChanges();
		}

		public List<Organization> GetCategory()
		{
			var products = databaseContext.Organizations.ToList();

			return products;
		}


	}
}
