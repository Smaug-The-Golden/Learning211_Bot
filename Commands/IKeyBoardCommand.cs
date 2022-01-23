using System;
using Telegram.Bot.Types.ReplyMarkups;


namespace Learning211_Bot.Commands
{
    /// <summary>
    /// Интерфейс кнопок
    /// </summary>
    interface IKeyBoardCommand
    {
        InlineKeyboardMarkup ReturnKeyBoard();

        void AddCallBack(Conversation chat);

        string InformationalMessage();
    }
}
