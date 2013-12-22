using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XBMCRemoteWP.Helpers
{
    public enum InputCommands { Home, Back, Select, Left, Up, Right, Down, ShowOSD, ShowCodec, Info, ContextMenu};
    public class InputControls
    {
        public static async void ExecuteAction(InputCommands command)
        {
            JObject requestObject = JObject.FromObject(new
                {
                    jsonrpc = "2.0",
                    id = 234,
                    method = "Input." + command.ToString()
                });
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
        }

        public static async void ExecuteAction(string action)
        {
            JObject requestObject = new JObject(
                new JProperty("jsonrpc", "2.0"),
                new JProperty("id", 234),
                new JProperty("method", "Input.ExecuteAction"),
                new JProperty("params",
                    new JObject(
                        new JProperty("action", action))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
        }
    }
}
