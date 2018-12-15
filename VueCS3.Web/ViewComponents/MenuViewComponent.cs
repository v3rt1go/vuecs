using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueCS3.Web.Services;

namespace VueCS3.Web.ViewComponents
{
	public class MenuViewComponent : ViewComponent
	{
		private readonly MenuService _service;

		public MenuViewComponent(MenuService service)
		{
			_service = service;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menu = _service.GetMenuItems();
			return View(menu);
		}
	}
}
