using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fnol.Dialog
{
    public class FnolDialog
    {
        public static readonly IDialog<string> dialog = Chain.PostToChain()
           .Select(msg => msg.Text)
           .Switch(
           //new RegexCase<IDialog<string>>(new Regex("^hi", RegexOptions.IgnoreCase), (context, text) =>
           //{
           //    return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);
           //}),
           new DefaultCase<string, IDialog<string>>((context, text) =>
           {
               return Chain.ContinueWith(FormDialog.FromForm(Model.Claim.BuildForm, FormOptions.PromptInStart), AfterGreetingContinuation);
           }))
           .Unwrap()
           .PostToUser();

        private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "user";
            context.UserData.TryGetValue("Name", out name);
            var refNumber = "005-01-123456";
            return Chain.Return($"Thanks for using FNOL Bot, Your Claim reference number is {refNumber}");
        }
    }
}