using System;

namespace DeckOfCards {
    public class Ui {
        Deck myDeck = new Deck();
        Looks typing = new Looks(60);
        Player myPlayer;
        
        public Ui(){
            startScreen();
        }

        public void startScreen(){
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