using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using System.Threading;

namespace HogFinances.Bot.Models
{
    [Serializable]
    public class WelcomeDialog : IDialog<object>
    {
        private bool hasUserSaidHi = false;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            if (!hasUserSaidHi)
            {
                await context.PostAsync("Hi! Welcome to Hog Finances, the Bank that Runs on Trust. I'll be your concierge today. How can I assist you?");
                hasUserSaidHi = true;
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                // Forward the message to LUIS which will determine intent and spawn
                // the appropriate FormFlow dialog to handle it.
                var message = await result;
                await context.Forward(new MainIntentDialog(), MainIntentCompleted, message, new CancellationToken());
            }
        }

        private async Task MainIntentCompleted(IDialogContext context, IAwaitable<object> result)
        {
            // We get back here when LUIS has determined the user's intent and
            // the requisite FormFlow dialog has completed.
            var outcome = await result;
            if (outcome.ToString() != Common.GoodbyeResult)
            {
                await context.PostAsync(Common.GetRandomLine(Common.WhatNextLines));
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Thank you for contacting Hog Finances! Message me any time if you need something else!");
                hasUserSaidHi = false;
                context.Done(new object());
            }
        }
    }
}