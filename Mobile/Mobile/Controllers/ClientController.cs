using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Mvc;
using Vst.Network;

namespace Mobile.Controllers
{
    class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }
    }

    class ClientController : Controller
    {
        AsyncClient _client;
        public AsyncClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new AsyncClient();
                }
                return _client;
            }
        }

        public void Send(SocketMessage msg)
        {
            Client.Request("192.168.4.2", msg.ToJson(), () => {

                try
                {
                    var message = Vst.Json.GetObject<SocketMessage>(_client.GetString());
                    var response = Vst.Json.GetObject<Response>(message.Message);

                    if (response.Code < 0)
                    {
                        return;
                    }

                    var context = new System.Mvc.RequestContext(message.Topic);
                    var controller = MyApp.GetController<Controller>(context.ControllerName);
                    controller.RequestContext = context;
                    controller.MessageContext = message;

                    var aname = context.ActionName ?? "default";
                    var method = controller.GetMethod(aname);
                    var res = method?.Invoke(controller, new object[] { });

                    if (res != null)
                    {
                       // MyApp.ResponseProcessedEngine.ResponseProcessed(res);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        // Main Method 
        //public ActionResult start()
        //{
        //    SocketMvc.Register(new ClientController(), r => { });
        //    //Console.Title = "CLIENT";
        //    var client = new AsyncClient { };
        //    string[] topics = new string[] {
        //        "mathang/find",

        //    };

        //    int index = 0;
        //    while (true)
        //    {
        //        var topic = Console.ReadLine();

        //        var msg = new SocketMessage(topic, new { Id = 1 });
        //        client.Request("192.168.4.2", msg.ToJson(), () => {

        //            var message = Vst.Json.GetObject<SocketMessage>(client.GetString());
        //            var response = Vst.Json.GetObject<Response>(message.Message);

        //            if (response.Code >= 0)
        //            {
        //                SocketMvc.ProcessRequest(message);
        //            }
        //        });
        //        System.Threading.Thread.Sleep(1000);

        //        if (++index == topics.Length)
        //            index = 0;
        //    }
        //}
    }
}
