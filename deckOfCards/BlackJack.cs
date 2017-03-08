namespace DeckOfCards
{
    public class BlackJack {
        
        public Player myPlayer { get; set; }
        public Player myDealer { get; set; }
        public Deck myDeck { get; set; }

        public int deckCount = 0;

        public string startGame(Player player,Player dealer,Deck deck){

            
            Player myPlayer = player; 
            Player  myDealer = dealer; 
            Deck myDeck = deck;

            for (int i = 0; i < 2; i++)
            {
                myPlayer.DrawFrom(deck);
                myDealer.DrawFrom(deck);
            }
            if (myPlayer.handValue == 21){
                return "playerWin";
            }
            // if (dealer.upcard == "Ace"){
            //     return "aceUp";
            // }
            return "continue";
        }
        public string hit(Player playerTemp){
            playerTemp.DrawFrom(myDeck);
            if (playerTemp.handValue == 21){
                return "playerWin";
            }
            if (playerTemp.handValue > 21){
                return "playerBust";
            }
            return "continue";
        }
        public string stay(){
            myDealer.dealerLogic();
            myDeck.Reset();
            myDeck.Shuffle();
            if (myDealer.handValue == 21 || (myDealer.handValue > myPlayer.handvalue)){
                return "dealerWin";
            }
            if (myDealer.handValue > 21){
                return "dealerBust";
            }
            return "playerWin";
            }
        }
    }
