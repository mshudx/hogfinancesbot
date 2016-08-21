using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogFinances.Bot.Models
{
    public static class Common
    {
        private static Random random = new Random();

        public static readonly List<string> WhatNextLines = new List<string>
        {
            "What else can I do for you today?",
            "Can I do something else for you?",
            "Is there something else I can help with?"
        };

        public static readonly List<string> DidNotUnderstandLines = new List<string>()
        {
            "I'm terribly sorry, I did not understand that. Could you rephrase?",
            "Sorry, couldn't catch that. Could you please repeat with a different wording?",
            "I beg your pardon, I didn't get that. Can you please ask in a different way?"
        };

        public static string GetRandomLine(List<string> lines)
        {
            if (lines == null || lines.Count == 0)
            {
                return "";
            }
            else
            {
                return lines[random.Next(0, lines.Count)];
            }
        }
    }
}