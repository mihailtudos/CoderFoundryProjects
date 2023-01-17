using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzMVC.Models
{
	public class FizzBuzz
	{
		public int FizzValue { get; set; }
		public int BuzzValue { get; set; }
		public List<string> Result { get; set; } = new();
	}
}
