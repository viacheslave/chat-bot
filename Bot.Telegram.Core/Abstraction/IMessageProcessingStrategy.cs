using Bot.Telegram.Core.Models;
using Bot.Telegram.Entities;
using System.Threading.Tasks;

namespace Bot.Telegram.Core.Abstraction
{
	public interface IMessageProcessingStrategy
	{
		IRequest Process(Message message);
		Task<IRequest> ProcessAsync(Message message);
	}
}
