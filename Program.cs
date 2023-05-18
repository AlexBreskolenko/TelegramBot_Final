using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkillFactory_TelegramBot.Configuration;
using SkillFactory_TelegramBot.Controllers;
using SkillFactory_TelegramBot.Services;
using System;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SkillFactory_TelegramBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6129188867:AAHXAHYyP8ddhBqu4ivwHVlWiyPfuSFs_TU"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
            services.AddSingleton<IStorage, MemoryStorage>();
            services.AddSingleton<IFileHandler, TextFileHandler>();
        }
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "6129188867:AAHXAHYyP8ddhBqu4ivwHVlWiyPfuSFs_TU"
            };
        }
    }
}
