using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Interfaceis;
using MyCompany.Models;
using System.Globalization;
using System.Text;

namespace MyCompany.Controllers
{
	public class SotrudnikController : Controller
	{
		private readonly ISotrudnik sotrudnik;
		private readonly DatabaseContext dbcontext;
		private readonly IWebHostEnvironment webHostEnvironment;
		public SotrudnikController(ISotrudnik sotrudnik, DatabaseContext dbcontext, IWebHostEnvironment webHostEnvironment)
		{
			this.sotrudnik = sotrudnik;
			this.dbcontext = dbcontext;
			this.webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			var s = sotrudnik.GetAll();
			return View(s);
		}

		public IActionResult Create()
		{
			return View();
		}

		// Метод действия для обработки добавления сотрудника
		[HttpPost]
		public IActionResult Create(Sotrudnik sotrudnik)
		{
			this.sotrudnik.Add(sotrudnik);
			return RedirectToAction("Index", "Sotrudnik");

		}

		public IActionResult Edit(Guid productId)
		{
			var product = sotrudnik.GetById(productId);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Sotrudnik product)
		{
			if (!ModelState.IsValid)
			{

				return View(product);
			}

			sotrudnik.Update(product);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(Guid productId)
		{
			sotrudnik.Remove(productId);
			return RedirectToAction(nameof(Index));
		}




		public async Task<IActionResult> ExportCSV()
		{
			var sotrudniks = await dbcontext.Sotrudniks.ToListAsync();

			var builder = new StringBuilder();
			var stringWriter = new StringWriter(builder);

			using (var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(sotrudniks);
			}

			return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Sotrudniks.csv");
		}

		public ActionResult Import()
		{

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Import(IFormFile file)
		{
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				HeaderValidated = null,
				MissingFieldFound = null
			};
			using var streamReader = new StreamReader(file.OpenReadStream());
			using (var csv = new CsvReader(streamReader, config))
			{
				var records = csv.GetRecords<EmployeeDto>();

				//var records = csvReader.GetRecords<EmployeeDto>().ToList();

				foreach (var record in records)
				{
					var employee = new Sotrudnik
					{
						Id = Guid.NewGuid(),
						FirstName = record.FirstName,
						LastName = record.LastName,
						MiddleName = record.MiddleName,
						DateOfBirth = DateTime.Parse(record.DateOfBirth),
						PassportSeries = record.PassportSeries,
						PassportNumber = record.PassportNumber
					};

					dbcontext.Sotrudniks.Add(employee);
				}
			}

			await dbcontext.SaveChangesAsync();

			return RedirectToAction("Index");


		}
	}
}




