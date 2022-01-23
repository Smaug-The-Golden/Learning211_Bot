using System;

namespace Learning211_Bot.Commands
{
    /// <summary>
    /// 
    /// </summary>
    interface IChatTextCommandWithAction : IChatTextCommand
    {
        bool DoAction(Conversation chat);
    }
}
