using System;
using System.Collections.Generic;
using Learning211_Bot.EnglishTrainer;

namespace Learning211_Bot
{
        /// <summary>
        /// Класс контроля соответствия "чат- состояние"
        /// </summary>
        public class AddingController
        {
            private Dictionary<long, AddingState> ChatAdding;

            public AddingController()
            {
                ChatAdding = new Dictionary<long, AddingState>();
            }

            public void AddFirstState(Conversation chat)
            {
                ChatAdding.Add(chat.GetId(), AddingState.Russian);
            }

            public void NextStage(string message, Conversation chat)
            {
                var currentstate = ChatAdding[chat.GetId()];
                ChatAdding[chat.GetId()] = currentstate + 1;

                if (ChatAdding[chat.GetId()] == AddingState.Finish)
                {
                    chat.IsAddingInProcess = false;
                    ChatAdding.Remove(chat.GetId());
                }
            }

            public AddingState GetStage(Conversation chat)
            {
                return ChatAdding[chat.GetId()];
            }
        }
    }

