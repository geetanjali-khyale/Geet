using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Sample.LuisBot;
using Microsoft.Cognitive.LUIS.ActionBinding;

namespace LuisBot.Dialogs
{
    [Serializable]
    [LuisActionBinding("Software_Installation_ChangeSoftwar", FriendlyName = "Change the Software Name")]
    public class Software_Installation_ChangeSoftware : BaseLuisContextualAction<SoftwareInstallAction>
    {
        [Required(ErrorMessage = "Please provide a new Software Name")]
        [LuisActionBindingParam(CustomType = "software")]
        public string Software { get; set; }

        public override Task<object> FulfillAsync()
        {
            if (this.Context == null)
            {
                throw new InvalidOperationException("Action context not defined.");
            }

            // assign new location to FindHotelsAction
            this.Context.Software = this.Software;

            return Task.FromResult((object)$"Software Name changed to {this.Software}");
        }
    }
}