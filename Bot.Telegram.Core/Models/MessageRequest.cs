using Bot.Telegram.Core.Abstraction;

namespace Bot.Telegram.Core.Models
{
	public class MessageRequest : IRequest
	{
		public long ChatId { get; set; }
		public string Text { get; set; }
		public string ParseMode { get; set; }
	}
}
