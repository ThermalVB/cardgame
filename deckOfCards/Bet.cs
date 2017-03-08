using System;

namespace DeckOfCards {
    public class Bet {
        private object player, currentPot;
        private int betAmt;
    
        public Bet(object player, int betAmt, object currentPot) {
            this.player = player;
            this.currentPot = currentPot;
            this.betAmt = betAmt;
        } 
        public void wager(object player, int betAmt, object currentPot) {
            if (player is Player)
                ((player)player).chipTotal -= betAmt;
            if (currentPot is Pot)
                ((Pot)currentPot).add(betAmt);    
        }       
    }

    public class Pot {
        public int total;

        public Pot() {
            this.total = 0;
        }

        public void add(int bet) {
            total += bet;
        }

        public void credit(object player) {
            if (player is Player) { 
                player.chipTotal += total;
                total = 0;
            }
            else 
                Console.WriteLine("Invalid player, pot will be held!");
        }
    }
}