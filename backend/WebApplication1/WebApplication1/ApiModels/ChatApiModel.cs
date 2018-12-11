using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiModels
{
    public class ChatApiModel 
    {
        public Guid PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public ChatApiModel()
        {
            PlayerId = new Guid();
            Timestamp = new DateTime();
        }

        public ChatApiModel(Guid playerId, string message)
        {
            PlayerId = playerId;
            Timestamp = new DateTime();
            Message = message;
        }
    }
}