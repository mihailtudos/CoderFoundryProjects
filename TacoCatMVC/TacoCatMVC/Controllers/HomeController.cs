using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TacoCatMVC.Models;

namespace TacoCatMVC.Controllers
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
		public IActionResult Reverse()
		{
			Palindrome model = new();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Reverse(Palindrome palindrome)
		{
			string inputWord = palindrome.InputWord;
			string revWord = "";

			for(int i = inputWord.Length - 1; i >= 0; i--)
			{
				revWord += inputWord[i];
			}

			palindrome.RevWord = revWord;

			revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-z0-9]+", "");
			inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-z0-9]+", "");

			if (revWord.Equals(inputWord))
			{
				palindrome.IsPalindrome = true;
				palindrome.Message = $"Success {palindrome.InputWord} is a palindrome";
			} 
			else
			{
				palindrome.IsPalindrome = false;
				palindrome.Message = $"Sorry {palindrome.InputWord} is not a palindrome";
			}

			return View(palindrome);
		}

		//[HttpPost]
		//public IActionResult Reverse()
		//{
		//	return View();
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
