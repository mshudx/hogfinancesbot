using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogFinances.Bot.Models
{
    [Serializable]
    public class SendMoneyParameters
    {
        public string TargetPerson;
        public int Amount;
        public string Currency;

        public static IForm<SendMoneyParameters> BuildForm()
        {
            return new FormBuilder<SendMoneyParameters>().Build();
        }
    }
}