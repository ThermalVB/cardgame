using System.Collections.Generic;

namespace DeckOfCards {
    public class Player {
        public string name;
        public List<Card> hand;
        public BlackJack dealer  = new BlackJack();

        public int chipTotal;

        public Player(string n = "Player") {
            chipTotal = 250;
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
        // this method will make sure score will greater than 16,
        public void dealerLogic(Deck currentDeck){
                int value = this.handValue();
                
                while(value < 16){
                    
                    dealer.hit(this);
                    value = this.handValue();
                }
        }
          public int handValue(){
            int value =0;
             foreach(Card val in hand){
                 if(val.val > 10 ){
                    value += 10;
                 }
                 else{
                     value += val.val;
                 }
           }
            return (int)value;
        }//end of handValue
        public void discardAll(){      
           while(this.hand.Count > 0){
               Discard(0);
           }
        }
    }//end of player class
}