﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace pmcenter.Commands
{
    internal class RestartCommand : ICommand
    {
        public bool OwnerOnly => true;

        public string Prefix => "restart";

        public async Task<bool> ExecuteAsync(TelegramBotClient botClient, Update update)
        {
            await botClient.SendTextMessageAsync(
                update.Message.From.Id,
                Vars.CurrentLang.Message_Restarting,
                ParseMode.Markdown,
                false,
                Vars.CurrentConf.DisableNotifications,
                update.Message.MessageId);
            Thread.Sleep(5000);
            Environment.Exit(0);
            return true;
        }
    }
}
