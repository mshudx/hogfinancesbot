using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HogFinances.Bot.Models
{
    [LuisModel("0c94c090-58b0-436c-824c-355f6c7fe89f", "1eb6e206c13d4735ba42a35b5926d3e4")]
    [Serializable]
    public class MainIntentDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Common.GetRandomLine(Common.DidNotUnderstandLines));
            context.Wait(MessageReceived);
        }

        [LuisIntent("getBalance")]
        public async Task GetBalance(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Your current balance is 3215 dollars.");
            context.Done(new object());
        }
    }
}