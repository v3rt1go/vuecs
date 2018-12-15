using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace VueCS3.Web.Helpers
{
	public static class PageModelInjector
	{
		public static HelperResult InjectPageModelEncoded(IHtmlHelper helper, object model, string prop)
		{
			return new HelperResult(async writer =>
			{
				var json = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
				await writer.WriteAsync(
					$"<input type='hidden' id='__pageModel' v-model='{prop}' value='{json}' />"
				);
			});
		}

		public static HelperResult InjectPageModel(IHtmlHelper helper, object model, string prop)
		{
			return new HelperResult(async writer =>
			{
				var json = JsonConvert.SerializeObject(model);
				await writer.WriteAsync(
					$"<input type='hidden' id='__pageModel' v-model='{prop}' value='{json}' />"
				);
			});
		}
	}
}
