using System;

namespace Learning211_Bot.Commands
{
    /// <summary>
    /// Интерфейс базовой команды чата
    /// </summary>
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}