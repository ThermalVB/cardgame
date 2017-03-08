namespace DeckOfCards
{
    public class BlackJack {
        
        public Player myPlayer { get; set; }
        public Player myDealer { get; set; }
        public Deck myDeck { get; set; }

        public int deckCount = 0;

        public string startGame(Player player,Player dealer,Deck deck){

            
            myPlayer = player; 
            myDealer = dealer; 
            myDeck = deck;

            for (int i = 0; i < 2; i++)
            {
                myPlayer.DrawFrom(deck);
                myDealer.DrawFrom(deck);
            }
            if (myPlayer.handValue() == 21){
                return "playerWin";
            }
            // if (dealer.upcard == "Ace"){
            //     return "aceUp";
            // }
            return "continue";
        }
        public string hit(Player playerTemp){
            playerTemp.DrawFrom(myDeck);
            if (playerTemp.handValue() == 21){
                return "playerWin";
            }
            if (playerTemp.handValue() > 21){
                return "playerBust";
            }
            return "continue";
        }
<<<<<<< HEAD
        public string stay(Player dealer,Player player,Deck deck){
            dealer.dealerLogic(deck);
            deck.Reset();
            deck.Shuffle();
            if (dealer.handValue() == 21 || (dealer.handValue() > player.handValue())){
=======
        public string stay(){
            myDealer.dealerLogic(myDeck);
            myDeck.Reset();
            myDeck.Shuffle();
            if (myDealer.handValue() == 21 || (myDealer.handValue() > myPlayer.handValue())){
>>>>>>> 8ffb5d2250819275361038f05734bced72613588
                return "dealerWin";
            }
            if (myDealer.handValue() > 21){
                return "dealerBust";
            }
            return "playerWin";
            }
        }
    }
