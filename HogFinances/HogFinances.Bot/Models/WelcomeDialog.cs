using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

namespace HogFinances.Bot.Models
{
    [Serializable]
    public class WelcomeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi! Welcome to Hog Finances, the Bank that Runs on Trust. I'll be your concierge today. How can I assist you?");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            // Forward the message to LUIS which will determine intent and spawn
            // the appropriate FormFlow dialog to handle it.
            context.Call(new MainIntentDialog(), MainIntentCompleted);
        }

        private async Task MainIntentCompleted(IDialogContext context, IAwaitable<object> result)
        {
            // We get back here when LUIS has determined the user's intent and
            // the requisite FormFlow dialog has completed.
            await context.PostAsync(Common.GetRandomLine(Common.WhatNextLines));
            context.Wait(MessageReceivedAsync);
        }
    }
}