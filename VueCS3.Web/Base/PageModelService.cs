using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueCS3.Web.Services;

namespace VueCS3.Web.Base
{
	public class PageModelService
	{
		public PageModelService()
		{
			Menu = new MenuService().GetMenuItems();
		}

		public List<MenuItem> Menu { get; }

		protected string ModuleName { get; }
	}
}
