using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Core.Models;
using System.Threading.Tasks;

namespace Bot.Telegram.CoreAbstraction
{
	public interface IApiProvider
	{
		Task<UpdatesResponse> GetUpdatesAsync(long offset);
		Task SendMessageAsync(IRequest messageRequest);
		Task EditMessageText(IRequest messageRequest);
		Task EditMessageReplyMarkup(IRequest messageRequest);
	}
}