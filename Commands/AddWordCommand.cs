using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Learning211_Bot.EnglishTrainer;

namespace Learning211_Bot.Commands
{
    /// <summary>
    /// Класс добавления слов в словарь
    /// </summary>
    public class AddWordCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;

        private Dictionary<long, Word> Buffer;

        public AddWordCommand(ITelegramBotClient botClient)
        {
            CommandText = "/addword";

            this.botClient = botClient;

            Buffer = new Dictionary<long, Word>();
        }

        public async void StartProcessAsync(Conversation chat)
        {
            Buffer.Add(chat.GetId(), new Word());

            var text = "Введите русское значение слова";

            await SendCommandText(text, chat.GetId());
        }

        public async void DoForStageAsync(AddingState addingState, Conversation chat, string message)
        {
            var word = Buffer[chat.GetId()];
            var text = "";

            switch (addingState)
            {
                case AddingState.Russian:
                    word.Russian = message;

                    text = "Введите английское значение слова";
                    break;

                case AddingState.English:
                    word.English = message;

                    text = "Введите тематику";
                    break;

                case AddingState.Theme:
                    word.Theme = message;

                    text = "Успешно! Слово " + word.English + " добавлено в словарь. ";

                    chat.dictionary.Add(word.Russian, word);

                    Buffer.Remove(chat.GetId());
                    break;
            }


            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }

    }
}
