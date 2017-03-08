namespace DeckOfCards
{
    public class BlackJack {

        public int deckCount = 0;

        public string startGame(Player player,Player dealer,Deck deck){

            for (int i = 0; i < 2; i++)
            {
                player.DrawFrom(deck);
                dealer.DrawFrom(deck);
            }
            if (player.HandValue() == 21){
                return "playerWin";
            }
            // if (dealer.upcard == "Ace"){
            //     return "aceUp";
            // }
            return "continue";
        }
        public string hit(Player player,Deck deck){
            player.DrawFrom(deck);
            if (player.HandValue() == 21){
                return "playerWin";
            }
            if (player.HandValue() > 21){
                return "playerBust";
            }
            return "continue";
        }
        public string stay(Player dealer,Player player,Deck deck){
            dealer.dealerLogic();
            deck.Reset();
            deck.Shuffle();
            if (dealer.HandValue() == 21 || (dealer.HandValue() > player.HandValue())){
                return "dealerWin";
            }
            if (dealer.HandValue() > 21){
                return "dealerBust";
            }
            return "playerWin";
            }
        }
    }
