namespace DeckOfCards
{
    public class BlackJack {

        public int deckCount = 0;
        Player myPlayer;
        Player myDealer;
        Deck myDeck;

        public BlackJack(Player player,Player dealer,Deck deck) {
            myPlayer = player;
            myDealer = dealer;
            myDeck = deck;
        }

        public string startGame(Player player,Player dealer,Deck deck){

            for (int i = 0; i < 2; i++)
            {
                player.DrawFrom(deck);
                dealer.DrawFrom(deck);
            }
            if (player.handValue() == 21){
                return "playerWin";
            }
            // if (dealer.upcard == "Ace"){
            //     return "aceUp";
            // }
            return "continue";
        }
        public string hit(Player player){
            player.DrawFrom(myDeck);
            if (player.handValue() == 21){
                return "playerWin";
            }
            if (player.handValue() > 21){
                return "playerBust";
            }
            return "continue";
        }

        public string stay(){
            myDealer.dealerLogic(myDeck);
            myDeck.Reset();
            myDeck.Shuffle();
            if (myDealer.handValue() > 21){
                return "dealerBust";
            }
            else if (myDealer.handValue() == 21 || (myDealer.handValue() > myPlayer.handValue())){
                return "dealerWin";
            }
            return "playerWin";
            }
        }
    }
