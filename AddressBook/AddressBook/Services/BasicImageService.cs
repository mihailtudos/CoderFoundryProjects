using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Services.Interfaces
{
	public class BasicImageService : IImageService
	{
		public string ConvertByteArrayToFile(byte[] fileData, string extension)
		{
			if (fileData is null) return string.Empty;
			string imageBase64Data = Convert.ToBase64String(fileData);
			return $"data:{extension};base64,{imageBase64Data}";
			throw new NotImplementedException();
		}

		public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
		{
			using MemoryStream memoryStrem = new();
			await file.CopyToAsync(memoryStrem);
			byte[] byteFile = memoryStrem.ToArray();
			return byteFile;
		}
	}
}
