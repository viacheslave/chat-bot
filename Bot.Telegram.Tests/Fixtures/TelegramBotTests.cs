using Bot.Telegram.Core;
using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Core.Models;
using Bot.Telegram.CoreAbstraction;
using Bot.Telegram.Entities;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Bot.Telegram.Tests.Fixtures
{
	[Collection("TelegramBot")]
	public class TelegramBotTests
	{
		private readonly IApiProvider _apiProvider;
		private readonly TelegramBot _bot;

		public TelegramBotTests()
		{
			_apiProvider = Substitute.For<IApiProvider>();
			_bot = new TelegramBot(_apiProvider);
		}
		
		[Fact]
		public async void ProcessData_Skipped_If_Data_Empty()
		{
			await _bot.ProcessData(new List<Update>());
			await _apiProvider.DidNotReceiveWithAnyArgs().SendMessageAsync(Arg.Any<IRequest>());
		}

		[Fact]
		public async void ProcessData_Skipped_If_ProcessorsCollection_Empty()
		{
			await _bot.ProcessData(new List<Update>() { new Update() });
			await _apiProvider.DidNotReceiveWithAnyArgs().SendMessageAsync(Arg.Any<IRequest>());
		}

		[Fact]
		public async void ProcessData_Skipped_If_ProcessingResults_Empty()
		{
			var processor = Substitute.For<IUpdateProcessor>();
			processor.ProcessAsync(Arg.Any<Update>()).ReturnsForAnyArgs(Task.FromResult((IRequest)null));

			_bot.AddModule(processor);

			await _bot.ProcessData(new List<Update>() { new Update() });
			await _apiProvider.DidNotReceiveWithAnyArgs().SendMessageAsync(Arg.Any<IRequest>());
		}

		[Fact]
		public async void ProcessData_Sends_Response_If_ProcessingResults_NonEmpty()
		{
			var processor = Substitute.For<IUpdateProcessor>();
			var request = new EditMessageTextRequest();

			processor.ProcessAsync(Arg.Any<Update>())
				.ReturnsForAnyArgs(Task.FromResult((IRequest)request));

			_bot.AddModule(processor);

			await _bot.ProcessData(new List<Update>() { new Update() });
			await _apiProvider.ReceivedWithAnyArgs(1).SendMessageAsync(request);
		}
	}
}
