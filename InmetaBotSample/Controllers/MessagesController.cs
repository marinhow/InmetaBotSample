using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using System.Web.Services.Description;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System.Web.Http.Description;
using System.Net.Http;
using System.Diagnostics;
using System;
using System.Configuration;

namespace InmetaBotSample
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

            internal static IDialog<SandwichOrder> MakeRootDialog()
            {
                return Chain.From(() => FormDialog.FromForm(SandwichOrder.BuildForm));
            }


        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            ConfigurationManager.AppSettings["BotId"] = "test";
            try
            {
                if (activity != null)
                {
                    // one of these will have an interface and process it
                    switch (activity.GetActivityType())
                    {
                        case ActivityTypes.Message:
                            await Conversation.SendAsync(activity, MakeRootDialog);
                            break;

                        case ActivityTypes.ConversationUpdate:
                        case ActivityTypes.ContactRelationUpdate:
                        case ActivityTypes.Typing:
                        case ActivityTypes.DeleteUserData:
                        default:
                            Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
                            break;
                    }
                }
                return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);

            }
            catch (Exception exp)
            {
                var error = exp.Message;
                return null;
            }
        }
    }
}