using System;

namespace Learning211_Bot.Commands
{
    public class SayHiCommand : AbstractCommand, IChatTextCommand
    {
        public SayHiCommand()
        {
            CommandText = "/saymehi";
        }

        public string ReturnText()
        {
            return "привет";
        }

    }
}
