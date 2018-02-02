using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Cognitive.LUIS.ActionBinding.Bot;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisActionDialog<object>
    {
        public BasicLuisDialog() : base(
            new Assembly[] { typeof(SoftwareInstallAction).Assembly },
            (action, context) =>
            {
            },
            new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("Software Installation")]
        public async Task IntentActionResultHandlerAsync(IDialogContext context, object actionResult)
        {
            // we know these actions return a string for their related intents,
            // although you could have individual handlers for each intent
            var message = context.MakeMessage();

            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";

            await context.PostAsync(message);
        }
    }
}