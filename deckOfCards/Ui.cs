using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Ui
    {
        Deck myDeck = new Deck();
        Looks typing = new Looks(60);
        BlackJack logic;
        Player myPlayer;

        List<Player> playerList = new List<Player>();
        Player myDealer = new Player("The Dealer");
        string move;
        string returner = "continue";

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
            playerList.Add(myPlayer);
            myDeck.Shuffle();
            logic = new BlackJack(myPlayer, myDealer, myDeck);

            if (logic.startGame(myPlayer, myDealer, myDeck) == "playerWin")
            {
                endScreen("playerWin");
            }
            else
            {
                playScreen("start");
            }
        }

        public void endScreen(string endCondition)
        {
            typing.TopLine();
            typing.BlankLine();
            if (endCondition == "playerWin")
            {
                typing.CenterLine("Congratulations!");
                typing.BlankLine(2);
                typing.CenterLine("You won!");
            }
            else if (endCondition == "playerBust")
            {
                typing.CenterLine("Dang!");
                typing.BlankLine(2);
                typing.CenterLine("You busted! Dealer wins!");
            }
            else if (endCondition == "dealerWin")
            {
                typing.CenterLine("Dang!");
                typing.BlankLine(2);
                typing.CenterLine("The Dealer wins!");
            }
            else if (endCondition == "dealerBust")
            {
                typing.CenterLine("Congratulations!");
                typing.BlankLine(2);
                typing.CenterLine("The Dealer busted! You win!");
            }
            else
            {
                typing.CenterLine("The game has ended.");
                typing.BlankLine(2);
                typing.CenterLine("...and we don't know why...");
            }
            typing.CreateLine(myPlayer.name+"'s Hand:");
            foreach (Card card in myPlayer.hand)
            {
                typing.CreateLine(" - " + card.ToString());
            }
            typing.BlankLine();
            typing.CreateLine("The Dealer's Hand:");
            foreach (Card card in myDealer.hand)
            {
                typing.CreateLine(" - " + card.ToString());
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
                typing.BottomLine();
            }
            foreach (Player player in playerList)
            {
                do
                {

                    typing.TopLine();
                    typing.BlankLine();
                    typing.CenterLine("Your Turn:");
                    typing.BlankLine();
                    typing.CreateLine(player.name+"'s Cards:");
                    foreach (Card card in player.hand)
                    {
                        typing.CreateLine(" - " + card.ToString());
                    }
                    typing.BlankLine();
                    typing.CreateLine("Do you want to 'hit' or 'stay' ?");
                    typing.BottomLine();
                    move = typing.User_Input("Input");
                    while (move != "hit" && move != "stay")
                    {
                        typing.TopLine();
                        typing.CenterLine("Sorry, I didn't understand that. Please type it again.");
                        typing.BottomLine();
                        move = typing.User_Input("Input");
                        Console.WriteLine(move);
                    }
                    if (move == "hit")
                    {
                        returner = logic.hit(player);
                        if (returner == "playerWin" || returner == "playerBust")
                        {
                            endScreen(returner);
                        }
                    }
                    else if (move == "stay")
                    {
                        returner = logic.stay();
                        endScreen(returner);
                    }

                } while (returner == "continue");

            }
        }

    }
}