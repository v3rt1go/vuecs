using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueCS3.Web.Services
{
	public class MenuService
	{
		public List<MenuItem> GetMenuItems()
		{
			return new List<MenuItem> {
				new MenuItem {Name = "Home", Page = "/Index", Slug = "/"},
				new MenuItem {Name = "About", Page = "/About", Slug = "/about"},
				new MenuItem {Name = "Contact", Page = "/Contact", Slug = "/contact"},
				new MenuItem {Name = "Privacy", Page = "/Privacy", Slug = "/privacy"},
			};
		}
	}

	public class MenuItem
	{
		public string Name { get; set; }

		public string Page { get; set; }

		public string Slug { get; set; }
	}
}
