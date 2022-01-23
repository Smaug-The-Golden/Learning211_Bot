using System;

namespace Learning211_Bot.Commands
{
    public class StopTrainingCommand : AbstractCommand, IChatTextCommandWithAction
    {
        public StopTrainingCommand()
        {
            CommandText = "/stop";
        }

        public bool DoAction(Conversation chat)
        {
            chat.IsTraningInProcess = false;
            return !chat.IsTraningInProcess;
        }

        public string ReturnText()
        {
            return "Тренировка остановлена!";
        }
    }
}
