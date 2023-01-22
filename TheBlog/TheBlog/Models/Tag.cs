﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlog.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public int PostId { get; set; }
		public string AuthorId { get; set; }
		[Required]
		[StringLength(25, ErrorMessage = "The {0} must be at least {2} and no longer than {1}", MinimumLength = 2)]
		public string Text { get; set; }

		public virtual Post Post { get; set; }
		public virtual IdetityUser Author { get; set; }
	}
}
