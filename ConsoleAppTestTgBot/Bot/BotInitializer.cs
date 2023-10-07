using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace ConsoleAppTestTgBot.Bot;

public class BotInitializer
{
    private TelegramBotClient _botClient;
    private CancellationTokenSource _cancellationTokenSource;

    public BotInitializer()
    {
        _botClient = new TelegramBotClient("6627062484:AAF91PeY-5zpFlaCqxsWUVJNOilJVXjh97I");
        _cancellationTokenSource = new CancellationTokenSource();
        
        Console.WriteLine("Выполнена инициализация Бота");
    }
    
    public void Start()
    {
        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        BotRequestHandlers botRequestHandlers = new BotRequestHandlers();

        _botClient.StartReceiving(
            botRequestHandlers.HandleUpdateAsync,
            botRequestHandlers.HandlePollingErrorAsync,
            receiverOptions,
            _cancellationTokenSource.Token
        );
        
        Console.WriteLine("Бот запущен");
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
        
        Console.WriteLine("Бот остановлен");
    }
}