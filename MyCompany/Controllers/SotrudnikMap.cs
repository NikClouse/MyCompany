using CsvHelper.Configuration;
using MyCompany.Models;

namespace MyCompany.Controllers
{
	public sealed class SotrudnikMap : ClassMap<Sotrudnik>
	{
		public SotrudnikMap()
		{
			Map(m => m.LastName).Index(0);
			Map(m => m.FirstName).Index(1);
			Map(m => m.MiddleName).Index(2);
			Map(m => m.DateOfBirth).Index(3);
			Map(m => m.PassportSeries).Index(4);
			Map(m => m.PassportNumber).Index(5);
		}
	}
}