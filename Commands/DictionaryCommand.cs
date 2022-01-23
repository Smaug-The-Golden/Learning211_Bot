using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Learning211_Bot.Commands
{
    /// <summary>
    /// Класс для вывода всех сохраненных слов 
    /// </summary>
    public class DictionaryCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;
        public DictionaryCommand(ITelegramBotClient botClient)
        {
            CommandText = "/dictionary";
            this.botClient = botClient;
        }
        public async void DictionaryText(Conversation chat)
        {
            var delimiter = ",";
            var text = string.Join(delimiter, chat.GetDictionaryMessages().ToArray());
            await SendCommandText(text, chat.GetId());
        }
        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
