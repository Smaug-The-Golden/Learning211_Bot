using System;

namespace Learning211_Bot.Commands
{
    /// <summary>
    /// абстрактная команда чата, определяет является ли сообщение командой
    /// </summary>
    public abstract class AbstractCommand : IChatCommand
    {
        public string CommandText;

        public virtual bool CheckMessage(string message)
        {
            return CommandText == message;
        }
    }
}