using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ApiModels;

namespace WebApplication1.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<List<ChatApiModel>> Get()
        {
            return Program.Chat;
        }

        // GET api/values/5
        [HttpGet("{PlayerId}")]
        public ActionResult<List<ChatApiModel>> Get(Guid PlayerId)
        {
            List<ChatApiModel> playerMessages = new List<ChatApiModel>();
            foreach(ChatApiModel message in Program.Chat)
            {
                if(message.PlayerId == PlayerId)
                {
                    playerMessages.Add(message);
                }
            }
            return playerMessages;
        }

        // POST api/playerGuid
        [HttpPost("{playerId}")]
        public void Post(Guid playerId, [FromBody] string value)
        {
            ChatApiModel cam = new ChatApiModel(playerId, value);
            Program.Chat.Add(cam);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
