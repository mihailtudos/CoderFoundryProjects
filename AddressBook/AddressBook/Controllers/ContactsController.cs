using AddressBook.Data;
using AddressBook.Models;
using AddressBook.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
	public class ContactsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IImageService _imageService;
		public ContactsController(ApplicationDbContext context, IImageService imageService)
		{
			_context = context;
			_imageService = imageService;
		}

		// GET: Contacts
		public async Task<IActionResult> Index()
		{
			return View(await _context.Contacts.ToListAsync());
		}

		// GET: Contacts/Details/5
		public async Task<IActionResult> Details(int id)
		{
			return View(await _context.Contacts.FindAsync(id));
		}

		// GET: Contacts/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Contacts/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("FirstName,LastName,Address1,Address2,Email,Phone,City,Zip,ImageFile")] Contact contact)
		{
			if (ModelState.IsValid)
			{
				if (contact.ImageFile != null)
				{
					contact.ImageDate = await _imageService.ConvertFileToByteArrayAsync(contact.ImageFile);
					contact.ImageType = contact.ImageFile.ContentType;
				}

				contact.Created = DateTime.Now;

				_context.Add(contact);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(contact);
		}

		// GET: Contacts/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Contacts/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Contacts/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Contacts/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
