using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueCS3.Web.Base
{
	public class PageModelBase<T> : PageModel where T : PageModelService
	{
		public readonly T Service;

		public PageModelBase(T service)
		{
			Service = service;
		}

		[BindProperty]
		public ViewModelBase ViewModel { get; set; }

		public class ViewModelBase
		{
			public string CurrentLocation { get; set; }

			public string PageTitle { get; set; }

			public string MetaDescription { get; set; }

			public string MetaKeywords { get; set; }
		}
	}
}
