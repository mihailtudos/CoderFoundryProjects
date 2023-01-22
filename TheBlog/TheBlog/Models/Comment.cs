﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlog.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public int PostId { get; set; }
		public string AuthorId { get; set; }
		public string ModeratorId { get; set; }
		
		[Required]
		[StringLength(500, ErrorMessage = "The {0} must be at least {2} and not longer than {1}.", MinimumLength = 2)]
		[Display(Name = "Comment")]
		public string Body { get; set; }

		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public DateTime? Moderated { get; set; }
		public DateTime? Deleted { get; set; }

		[StringLength(500, ErrorMessage = "The {0} must be at least {2} and not longer than {1}.", MinimumLength = 2)]
		[Display(Name = "Moderated Comment")]
		public string ModeratedBody { get; set; }

		//Navigation 
		public virtual Post Post { get; set; }
		public virtual IdentityUser Author { get; set; }
		public virtual IdentityUser Moderator { get; set; }
	}
}
