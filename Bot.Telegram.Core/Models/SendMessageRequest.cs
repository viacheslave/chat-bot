using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Entities;

namespace Bot.Telegram.Core.Models
{
	public class SendMessageRequest : IRequest
	{
		public long ChatId { get; set; }
		public string Text { get; set; }
		public string ParseMode { get; set; }
		public bool DisableWebPagePreview { get; set; }
		public bool DisableNotification { get; set; }
		public long ReplyToMessageId { get; set; }
	}

	public class SendMessageRequest<T> : SendMessageRequest where T: IInlineMarkup
	{
		public T ReplyMarkup { get; set; }
	}
}
