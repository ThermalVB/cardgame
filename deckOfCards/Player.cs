using System.Collections.Generic;

namespace DeckOfCards {
    public class Player {
        public string name;
        private List<Card> hand;
        public int chiptotal;
        public Player(string n) {
            hand = new List<Card>();
            name = n;
        }

        public void DrawFrom(Deck currentDeck) {
            hand.Add(currentDeck.Deal());
        }
        
        public Card Discard(int idx) {
            Card temp = hand[idx];
            hand.RemoveAt(idx);
            return temp;
        }

        public void dealerLogic(List<Card> dealercard){

                int value = HandValue(dealercard);

                if(value < 16){
                    
                      BlackJack.hit();
                }
        }

          public int HandValue(List<Card> card){
            
            int value =0;
             foreach(Card val in card){
                 if(val.val > 10 ){
                    value += 10;
                 }
                 else{
                     value += val.val;
                 }
           }
            return (int)value;
        }
        

          
    }
}