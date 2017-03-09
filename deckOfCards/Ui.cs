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

        Pot thisPot = new Pot();
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
            // Clear console from compliation data
            Console.Clear();
            // Top Display Box
            typing.TopLine();
            typing.BlankLine();
            typing.CenterLine("Welcome to Black Jack!");
            typing.BlankLine(2);
            typing.CenterLine("Please enter your name below:");
            typing.BlankLine();
            typing.BottomLine();
            // Add player logic
            myPlayer = new Player(typing.User_Input("Name"));
            playerList.Add(myPlayer);
            do
            {
                // Shuffle deck
                myDeck.Shuffle();
                // clear Console
                Console.Clear();
                // Prompt for bet Amount
                typing.TopLine();
                typing.BlankLine();
                typing.CreateLine("Enter how much you would like to bet: ");
                typing.BlankLine();
                typing.CenterLine(String.Format("(You have {0} chips.)", myPlayer.chipTotal));
                typing.BlankLine();
                typing.BottomLine();
                // Declare Bet objects that manage bets
                Bet play1Bet = new Bet(myPlayer, thisPot);
                Bet dealerBet = new Bet(myDealer, thisPot);
                // Recieve bet amount and verify it is an integer
                int betAmt = 0;
                Console.Write("Please enter the number of chips you'd like to bet: ");
                while (!int.TryParse(Console.ReadLine(), out betAmt))
                {
                    Console.WriteLine("\t Input must be a valid integer");
                    Console.Write("Please enter the number of chips you'd like to bet: ");
                }
                // Clear Console
                Console.Clear();
                //Display Information and pause, continuing when user presses any key
                typing.TopLine();
                typing.BlankLine();
                typing.CenterLine(play1Bet.wager(betAmt));
                typing.BlankLine();
                typing.BottomLine();
                typing.TopLine();
                typing.BlankLine();
                typing.CenterLine(dealerBet.wager(betAmt));
                typing.BlankLine();
                typing.BottomLine();
                Console.Write("\t\tPress any key to continue: ");
                Console.ReadLine();
                Console.Clear();
                // Commence game
                logic = new BlackJack(myPlayer, myDealer, myDeck);
                if (logic.startGame(myPlayer, myDealer, myDeck) == "playerWin")
                {
                    endScreen("playerWin");
                }
                else
                {
                    playScreen("start");
                }
                // End multiple hands logic
            } while (playAgain());
            
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
                typing.CenterLine(thisPot.credit(playerList[0]));
                typing.BlankLine();
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
                typing.CenterLine(thisPot.credit(playerList[0]));
            }
            else
            {
                typing.CenterLine("The game has ended.");
                typing.BlankLine(2);
                typing.CenterLine("...and we don't know why...");
            }
            typing.CreateLine(myPlayer.name + "'s Hand:");
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
                    typing.CreateLine(player.name + "'s Cards:");
                    foreach (Card card in player.hand)
                    {
                        typing.CreateLine(" - " + card.ToString());
                    }
                    typing.BlankLine();
                    typing.CreateLine("Do you want to 'hit' or 'stay' ?");
                    typing.BottomLine();
                    move = typing.User_Input("Input");
                    // Action validation block
                    while (move.ToLower() != "hit" && move.ToLower() != "stay")
                    {
                        typing.TopLine();
                        typing.CenterLine("Sorry, I didn't understand that. Please type it again.");
                        typing.BottomLine();
                        move = typing.User_Input("Input");
                        Console.WriteLine(move);
                    }
                    Console.Clear();
                    // 'Hit' logic
                    if (move.ToLower() == "hit")
                    {
                        returner = logic.hit(player);
                        if (returner == "playerWin" || returner == "playerBust")
                        {
                            endScreen(returner);
                        }
                    }
                    // 'Stay' logic
                    else if (move.ToLower() == "stay")
                    {
                        returner = logic.stay();
                        endScreen(returner);
                    }
                } while (returner == "continue");
            }
        }

        public Boolean playAgain()
        {
            // Local variable
            String playAgainStr = "";
            // Repeat until input is valid option
            do
            {
                Console.Write("Would you like to play again? (y/n):");
                playAgainStr = Console.ReadLine();
                // If player wants to play again
                if (playAgainStr.ToLower() == "y" || playAgainStr.ToLower() == "yes")
                {
                    // Clear console
                    Console.Clear();
                    // Discard cards from each player
                    foreach (Player current in playerList) {
                        current.discardAll();
                    }
                    myDealer.discardAll();
                    // Empty Pot
                    thisPot.emptyPot();
                    // Return true to play again
                    return true;
                }
                // If player wnats to end program
                else
                {
                    // Return false to end program
                    return false;
                }
            } while (playAgainStr.ToLower() != "y" && playAgainStr.ToLower() != "yes" && playAgainStr.ToLower() != "n" && playAgainStr.ToLower() != "no");
        }

    }
}