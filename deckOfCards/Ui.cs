using System;

namespace DeckOfCards {
    public class Ui {
        Deck myDeck = new Deck();
        Looks typing = new Looks(60);
        BlackJack logic = new BlackJack();
        Player myPlayer;
        Player myDealer = new Player("The Dealer");
        
        public Ui(){
            resetScreen();
        }

        public void resetScreen(){
            typing.TopLine();
            typing.BlankLine();
            typing.CenterLine("Welcome to Black Jack!");
            typing.BlankLine(2);
            typing.CenterLine("Please enter your name below:");
            typing.BlankLine();
            typing.BottomLine();
            myPlayer = new Player(typing.User_Input("Name"));
            if(logic.startGame(myPlayer, myDealer, myDeck) == "playerWin") {
                winScreen("playerWin");
            } else {
                playScreen("start");
            }
        }

        public void winScreen(string winCondition){
            typing.TopLine();
            typing.BlankLine();
            if(winCondition == "playerWin"){
                typing.CenterLine("Congratulations!");
                typing.BlankLine(2);
                typing.CenterLine("You won!");
            } else {
                typing.CenterLine("The game has ended.");
                typing.BlankLine(2);
                typing.CenterLine("...and we don't know why...");
            }
            typing.BlankLine();
            typing.BottomLine();
        }

        public void playScreen(string isStart = "not"){
            typing.TopLine();
            typing.BlankLine();
            if(isStart == "start"){
                typing.CenterLine("Let's Play!");
                typing.CenterLine("-- The Dealer has dealt. --");
                typing.BlankLine(2);
            }
            typing.CenterLine("Your Turn:");
            typing.BlankLine();
            typing.CreateLine("Your Cards:");
            foreach(Card card in myPlayer.hand){
                typing.CreateLine(" - " + card.ToString());
            }
            typing.BlankLine();
            typing.CreateLine("Do you want to 'hit' or 'stay' ?");
            typing.BottomLine();
        }

    }
}