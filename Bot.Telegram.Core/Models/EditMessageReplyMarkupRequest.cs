using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Entities;

namespace Bot.Telegram.Core.Models
{
	public class EditMessageReplyMarkupRequest : IRequest
	{
		public long ChatId { get; set; }
		public long MessageId { get; set; }
		public string InlineMessageId { get; set; }
		public InlineKeyboardMarkup ReplyMarkup { get; set; }
	}
}
