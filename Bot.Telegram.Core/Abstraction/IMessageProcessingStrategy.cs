using Bot.Telegram.Core.Models;
using Bot.Telegram.Entities;
using System.Threading.Tasks;

namespace Bot.Telegram.Core.Abstraction
{
	public interface IMessageProcessingStrategy
	{
		MessageRequest Process(Message message);
		Task<MessageRequest> ProcessAsync(Message message);
		bool CanProcess(Message message);
	}
}
