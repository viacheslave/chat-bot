using Bot.Telegram.Core.Models;
using System.Threading.Tasks;

namespace Bot.Telegram.CoreAbstraction
{
	public interface IApiProvider
	{
		Task<UpdatesResponse> GetUpdatesAsync(long offset);
		Task SendMessageAsync(MessageRequest messageRequest);
	}
}