using System;

namespace DeckOfCards {
    public class Ui {
        Deck myDeck = new Deck();
        Looks typing = new Looks(60);
        // BlackJack logic = new BlackJack();
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
        }

    }
}