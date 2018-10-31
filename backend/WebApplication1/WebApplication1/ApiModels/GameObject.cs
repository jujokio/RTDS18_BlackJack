using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Helpers;

namespace WebApplication1.ApiModels
{
    public class GameObject
    {

        private DeckApiModel playdeck = new DeckApiModel();
        private List<PlayerApiModel> players = new List<PlayerApiModel>();
        private DealerApiModel dealer = new DealerApiModel();
        public bool Playing { get; set; }


        public void waitForPlayers()
        {
            throw new NotImplementedException();
        }

        public List<PlayerApiModel> getPlayers()
        {
            return players;
        }


        public List<HandApiModel> getPlayerHands()
        {
            List<HandApiModel> playerHands = new List<HandApiModel>();
            foreach (PlayerApiModel p in players)
            {
                HandApiModel h = p.PlayerHand;
                playerHands.Add(h);
            }

            return playerHands;
        }

        public List<HandApiModel> getFinalHands()
        {
            List<HandApiModel> playerHands = new List<HandApiModel>();
            foreach (PlayerApiModel p in this.players)
            {
                HandApiModel h = p.PlayerHand;
                playerHands.Add(h);
            }
            playerHands.Add(dealer.PlayerHand);
            return playerHands;
        }

        private void dealCards(PlayerApiModel player, int numberOfCards)
        {
            List<CardApiModel> c = playdeck.Draw(numberOfCards);
            player.giveCards(c);
        }

        public void main()
        {
            waitForPlayers();
            playdeck.Restart();
            System.Diagnostics.Debug.Write(this.playdeck.DeckToString());


        }

        public void runGame()
        {
            //init the single players command
            int playerChoise = -1;
            // give dealer 2 cards
            dealCards(dealer, 2);
            // deal cards to everyone
            foreach(PlayerApiModel player in players)
            {
                dealCards(player, 2);
            }

            // players turn
            foreach (PlayerApiModel player in players)
            {
                player.CurrentlyPlaying = true;
                GameMessageApiModel ykok = new GameMessageApiModel(player);
                ykok.Message = "Your turn.";
                ykok.Status = 200;
                SendMessageToPlayer(ykok, player);

            }





            //	#lähetä your turn
            //	message = "The dealer is showing a " + str(self.dealer.getHand()[0]) + " \n\nYou have a " + str(player.getHand()) + " for a total of " + str(self.total(player.getHand()))


            //          response ={ "id" : 6, "message" : message, "status" : "success", "state" : "yourturn"}
            //          s = json.dumps(response).encode()
            //	#send status
            //	sendMessageAndReceiveResponse(self.sock, player.getIP(), player.getPort(), s)


            //          while player.isPlaying and not player.getQuit():
            //		print("The dealer is showing a " + str(self.dealer.getHand()[0]))

            //              print("\n\nYou have a " + str(player.getHand()) + " for a total of " + str(self.total(player.getHand())))


            //              if not self.blackjack(self.dealer.getHand(), player.getHand()):

            //			#create status message
            //			message = "The dealer is showing a " + str(self.dealer.getHand()[0]) + " \n\nYou have a " + str(player.getHand()) + " for a total of " + str(self.total(player.getHand()))


            //                  response ={ "id" : 5, "message":message}
            //          s = json.dumps(response).encode()
            //			#send status
            //			try:
            //				responseJson = sendMessageAndReceiveResponse(self.sock, player.getIP(), player.getPort(), s)

            //                      choice = responseJson.get("id")

            //                  except socket.timeout:
            //          print("player timeout")

            //                      choice = 3

            //                  choice = int(choice)

            //                  self.clear()

            //                  if choice == 1:
            //				self.hit(player.getHand())

            //                      if self.scoreOneHand(player.getHand()):
            //					player.setPlaying()

            //                  elif choice == 2:
            //				player.setPlaying()

            //                      # self.play_again()
            //          elif choice == 3:
            //				print("Bye!")

            //                      player.setPlaying()

            //                      player.setQuit()

            //                      print(player)

            //                      print(self.playerList)
            //		else:
            //			#player or delare black jack!
            //			player.setPlaying()

            //                  print("BLACK JACK idk?")


            //          # player ends their turn
            //          message = "The dealer is showing a " + str(self.dealer.getHand()[0]) + " \n\nYou have a " + str(player.getHand()) + " for a total of " + str(self.total(player.getHand()))


            //          response ={ "id" : 6, "message" : message, "status" : "success", "state" : "endOfTurn"}
            //          s = json.dumps(response).encode()
            //	#send status
            //	sendMessageAndReceiveResponse(self.sock, player.getIP(), player.getPort(), s)

            //      # dealer plays his hand
            //          while self.total(self.dealer.getHand()) < 17:
            //	self.hit(self.dealer.getHand())
            //#send results to all players
            //for player in self.playerList:

            //          message = self.score(self.dealer.getHand(), player.getHand())

            //          # message = "The dealer is showing a " + str(self.dealer.getHand()[0]) + " \n\nYou have a " + str(player.getHand()) + " for a total of " + str(self.total(player.getHand()))

            //          response ={ "id" : 6, "message" : message, "status" : "success", "state" : "endOfGame"}
            //          s = json.dumps(response).encode()
            //	#send status
            //	responseJson = sendMessageAndReceiveResponse(self.sock, player.getIP(), player.getPort(), s)

            //          player.setPlaying()


            //      for player in self.playerList:

            //          if player.getQuit():
            //		self.playerList.remove(player)


            //      self.deck = self.createDeck()
            //#self.sock.close()



        }

        private void SendMessageToPlayer(GameMessageApiModel message, PlayerApiModel player)
        {
            int result = player.SendMessageAsync(message);
        }
    }
}