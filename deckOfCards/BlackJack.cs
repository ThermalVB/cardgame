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
<<<<<<< HEAD
            if (player.HandValue() == 21){
=======
            if (player.handValue() == 21){
>>>>>>> 4d3da4bec1a680bca8ebe0537bfd024b8072710a
                return "playerWin";
            }
            // if (dealer.upcard == "Ace"){
            //     return "aceUp";
            // }
            return "continue";
        }
        public string hit(Player player,Deck deck){
            player.DrawFrom(deck);
<<<<<<< HEAD
            if (player.HandValue() == 21){
                return "playerWin";
            }
            if (player.HandValue() > 21){
=======
            if (player.handValue() == 21){
                return "playerWin";
            }
            if (player.handValue() > 21){
>>>>>>> 4d3da4bec1a680bca8ebe0537bfd024b8072710a
                return "playerBust";
            }
            return "continue";
        }
        public string stay(Player dealer,Player player,Deck deck){
            dealer.dealerLogic();
            deck.Reset();
            deck.Shuffle();
<<<<<<< HEAD
            if (dealer.HandValue() == 21 || (dealer.HandValue() > player.HandValue())){
                return "dealerWin";
            }
            if (dealer.HandValue() > 21){
=======
            if (dealer.handValue() == 21 || (dealer.handValue > player.handvalue())){
                return "dealerWin";
            }
            if (dealer.handValue() > 21){
>>>>>>> 4d3da4bec1a680bca8ebe0537bfd024b8072710a
                return "dealerBust";
            }
            return "playerWin";
            }
        }
    }
