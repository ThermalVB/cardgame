using System.Collections.Generic;

namespace DeckOfCards {
    public class Player {
        public string name;
<<<<<<< HEAD
        public List<Card> hand;
=======
        private List<Card> hand;
        public BlackJack dealer  = new BlackJack();
>>>>>>> 4d3da4bec1a680bca8ebe0537bfd024b8072710a

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
<<<<<<< HEAD

        public void dealerLogic(){

                int value = HandValue();

                if(value < 16){
                    
                    //   BlackJack.hit();
                }
        }

          public int HandValue(){
            
=======
        // this method will make sure score will greater than 16,
        public void dealerLogic(Deck currentDeck){
                int value = this.handValue();
                
                while(value < 16){
                    
                    dealer.hit(this, currentDeck);
                    value = this.handValue();
                }
        }
          public int handValue(){
>>>>>>> 4d3da4bec1a680bca8ebe0537bfd024b8072710a
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