using Microsoft.AspNetCore.SignalR;
using ChatDB;
using System.Reflection;
using System;

namespace WhatsAppClone
{
    public class Chathubs:Hub
    {
        private readonly ChatDB.AppContext appContext;
        public Chathubs(ChatDB.AppContext _appContext)
        {
            appContext = _appContext;
        }
        public async Task SendMessage(String Sender, String Recever,String Message)
        {
            Console.WriteLine(Sender);
            Console.WriteLine(Recever);
            var sender = appContext.user.Where(s => s.Id ==  Sender).FirstOrDefault();
            var recever = appContext.user.Where(s => s.Id ==  Recever).FirstOrDefault();
            var newMessage = new Message { SenderId = sender.Id, ReceverId = recever.Id, Content = Message};
  

            await appContext.message.AddAsync(newMessage);
            await appContext.SaveChangesAsync();

            string senderConnectionId = Context.ConnectionId;
            await Clients.Caller.SendAsync("SendMessage",  Message);

            await Clients.User(Recever).SendAsync("ReceiveMessage",  Message);

          }


    }
}
