using System.Collections.Generic;

namespace Bot.Telegram.Entities
{
	public class InlineKeyboardMarkup : IInlineMarkup
	{
		public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; set; }
	}
}
