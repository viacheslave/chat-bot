using Bot.Telegram.Core.Models;
using Bot.Telegram.Entities;
using System.Threading.Tasks;

namespace Bot.Telegram.Core.Abstraction
{
	public interface IUpdateProcessor
	{
		IRequest Process(Update update);
		Task<IRequest> ProcessAsync(Update update);
	}
}
