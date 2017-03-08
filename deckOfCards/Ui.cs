using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Ui
    {
        Deck myDeck = new Deck();
        Looks typing = new Looks(60);
        BlackJack logic = new BlackJack();
        Player myPlayer;

        List<Player> playerList = new List<Player>();
        Player myDealer = new Player("The Dealer");
        string move;
        string returner;

        public Ui()
        {
            resetScreen();
        }

        public void resetScreen()
        {
            typing.TopLine();
            typing.BlankLine();
            typing.CenterLine("Welcome to Black Jack!");
            typing.BlankLine(2);
            typing.CenterLine("Please enter your name below:");
            typing.BlankLine();
            typing.BottomLine();
            myPlayer = new Player(typing.User_Input("Name"));
            playerList.Add(myDealer);
            playerList.Add(myPlayer);

            if (logic.startGame(myPlayer, myDealer, myDeck) == "playerWin")
            {
                winScreen("playerWin");
            }
            else
            {
                playScreen("start");
            }
        }

        public void winScreen(string winCondition)
        {
            typing.TopLine();
            typing.BlankLine();
            if (winCondition == "playerWin")
            {
                typing.CenterLine("Congratulations!");
                typing.BlankLine(2);
                typing.CenterLine("You won!");
            }
            else
            {
                typing.CenterLine("The game has ended.");
                typing.BlankLine(2);
                typing.CenterLine("...and we don't know why...");
            }
            typing.BlankLine();
            typing.BottomLine();
        }

        public void playScreen(string isStart = "not")
        {

            if (isStart == "start")
            {
                typing.TopLine();
                typing.BlankLine();
                typing.CenterLine("Let's Play!");
                typing.CenterLine("-- The Dealer has dealt. --");
                typing.BlankLine(2);
            }
            foreach (Player player in playerList)
            {
                if (player.name != "The Dealer")
                {
                    typing.TopLine();
                    typing.BlankLine();
                    typing.CenterLine("Your Turn:");
                    typing.BlankLine();
                    typing.CreateLine("Your Cards:");
                    foreach (Card card in player.hand)
                    {
                        typing.CreateLine(" - " + card.ToString());
                    }
                    typing.BlankLine();
                    typing.CreateLine("Do you want to 'hit' or 'stay' ?");
                    typing.BottomLine();
                    move = typing.User_Input("Input");
                    while (move != "hit" || move != "stay")
                    {
                        typing.TopLine();
                        typing.CenterLine("Sorry, I didn't understand that. Please type it again.");
                        typing.BottomLine();
                        move = typing.User_Input("Input");
                    }
                    if (move == "hit")
                    {
                        returner = logic.hit(player);
                    }
                    else if (move == "stay")
                    {
                        returner = logic.stay();

                    }
                }
            }
        }

    }
}