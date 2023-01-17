using FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		
		[HttpGet]
		public IActionResult FBPage()
		{
			FizzBuzz model = new();
			model.FizzValue = 3;
			model.BuzzValue = 5;

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult FBPage(FizzBuzz fizzBuzz)
		{
			List<string> fbItems = new();
			bool fizz;
			bool buzz;

			for(int i = 1; i <= 100; i++)
			{
				fizz = (i % fizzBuzz.FizzValue == 0);
				buzz = (i % fizzBuzz.BuzzValue == 0);

				if (fizz && buzz)
				{
					fbItems.Add("FizzBuzz");
				}
				else if (fizz)
				{
					fbItems.Add("Fizz");
				}

				else if (buzz)
				{
					fbItems.Add("Buzz");
				}
				else
				{
					fbItems.Add(i.ToString());
				}
			}

			fizzBuzz.Result = fbItems;

			return View(fizzBuzz);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
