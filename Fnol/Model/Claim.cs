using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fnol.Model
{
    [Serializable]
    public class Claim
    {

        public string FulName { get; set; }
        public string ClaimantName { get; set; }
        public string ClaimantAddress { get; set; }
        public string ClaimantContactDetails { get; set; }
        public string PolicyNumber { get; set; }

        public static IForm<Claim> BuildForm()
        {
            return new FormBuilder<Claim>()
                .Message("Welcome to Claim Bot")
                .Build();
        }
    }
}