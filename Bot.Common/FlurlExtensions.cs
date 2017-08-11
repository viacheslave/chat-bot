using Flurl;
using Flurl.Http;
using Flurl.Http.Content;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bot.Common
{
	public static class FlurlExtensions
	{
		public static Task<HttpResponseMessage> PostJsonStringAsync(this Url url, string jsonContent)
		{
			return url.SendAsync(HttpMethod.Post, new CapturedJsonContent(jsonContent));
		}
	}
}
