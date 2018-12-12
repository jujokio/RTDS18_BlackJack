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
        public Guid GameGuid = new Guid();


        public void waitForPlayers()
        {
            if (players.Count == 1)
            {
                System.Threading.Thread.Sleep(10);
                waitForPlayers();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Number of players: " + players.Count);
            }
            //PlayerApiModel p1 = new PlayerApiModel("tester1");
            //PlayerApiModel p2 = new PlayerApiModel("tester2");
            //PlayerApiModel p3 = new PlayerApiModel("tester3");
            //players.Add(p1);
            //players.Add(p2);
            //players.Add(p3);

        }

        public void JoinGame(string playername)
        {
            if (players.Count > 3)
            {
                PlayerApiModel p = new PlayerApiModel(playername);
                players.Add(p);
            }else
            {
                throw new Exception("Too many men!");
            }
        }

        public List<PlayerApiModel> getPlayers(bool addDealer = false)
        {
            if (addDealer)
            {
                List<PlayerApiModel> temp = new List<PlayerApiModel>();
                temp.Add(dealer);
                foreach (PlayerApiModel p in players)
                {
                    temp.Add(p);
                }
                return temp;
            }
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

        private bool ScorePlayerHand(PlayerApiModel player)
        {
            if (player.PlayerHand.TotalValue <= 21)
            {
                return true;
            }
            //busted
            System.Diagnostics.Debug.WriteLine(player.PlayerName + "busted with total value of "+player.PlayerHand.TotalValue);
            return false;
        }

        public void main()
        {
            Playing = false;
            waitForPlayers();
            playdeck.Restart();
            System.Diagnostics.Debug.WriteLine(this.playdeck.DeckToString());
        }

        public void runGame()
        {
            System.Diagnostics.Debug.WriteLine("start game");
            Playing = true;
            //init the single players command
            int playerChoise = -1;
            // give dealer 2 cards
            dealCards(dealer, 2);
            // deal cards to everyone
            System.Diagnostics.Debug.WriteLine("dealer's hand");
            System.Diagnostics.Debug.WriteLine(dealer.PlayerHand.HandToDisplay());

            foreach (PlayerApiModel player in players)
            {
                dealCards(player, 2);
                System.Diagnostics.Debug.WriteLine("hand of "+ player.PlayerName);
                System.Diagnostics.Debug.WriteLine(player.PlayerHand.HandToDisplay());
            }

            // players turn
            foreach (PlayerApiModel player in players)
            {
                if (player.PlayerHand.Hand.Count >= 2)
                {
                    player.CurrentlyPlaying = true;
                    GameMessageApiModel ykok = new GameMessageApiModel(player);
                    ykok.Message = "Your turn.";
                    ykok.Status = 200;
                    playerChoise = SendMessageToPlayer(ykok, player);
                    while (player.CurrentlyPlaying && !player.QuitGame && ScorePlayerHand(player))
                    {
                        GameMessageApiModel status = new GameMessageApiModel(player)
                        {
                            Message = "Your turn.",
                            HandList = getFinalHands(),
                            Status = 200,
                        };

                        playerChoise = SendMessageToPlayer(status, player);
                        // player play
                        System.Diagnostics.Debug.WriteLine(player.PlayerName + " playing");
                        switch (playerChoise) {
                            case 0: // hit 
                                dealCards(player, 1);
                                if (!ScorePlayerHand(player)) // busted
                                {
                                    player.Busted = true;
                                    player.CurrentlyPlaying = false;
                                }
                                break;
                            case 1: // stand
                                player.CurrentlyPlaying = false;
                                break;

                            default: // timeout or quit
                                player.CurrentlyPlaying = false;
                                player.QuitGame = true;
                                break;
                        }
                        if (!ScorePlayerHand(player)) // busted
                        {
                            player.Busted = true;
                            player.CurrentlyPlaying = false;
                        }
                    }
                }// not enough cards
            }// one player's turn
            // dealer's turn
            while (dealer.PlayerHand.TotalValue < 17)
            {
                dealCards(dealer, 1);
                if (!ScorePlayerHand(dealer)) // busted
                {
                    dealer.Busted = true;
                }
            }
            // send end game results
            GameMessageApiModel endgame = new GameMessageApiModel
            {
                Message = "Game ended",
                PlayerList = getPlayers(true),
                HandList = getFinalHands(),
                Status = 200
            };
            
            foreach (PlayerApiModel plr in players)
            {
                SendMessageToPlayer(endgame,plr);
            }
            // start to wait a new game
            Playing = false;
            ResetPlayerHands();
        





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

        private void ResetPlayerHands()
        {
            foreach (PlayerApiModel p in players)
            {
                p.PlayerHand.Discard();
            }
            dealer.PlayerHand.Discard();
        }

        private int SendMessageToPlayer(GameMessageApiModel message, PlayerApiModel player)
        {
            System.Diagnostics.Debug.WriteLine(message.ToDisplay());
            int result = player.SendMessageAsync(message);
            return result;
        }
    }
}