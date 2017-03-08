using System;

namespace DeckOfCards {
    public class Bet {
        private Player player;
        private Pot currentPot;
    
        public Bet(Player player, Pot currentPot) {
            this.player = player;
            this.currentPot = currentPot;
        } 

        public string wager(int betAmt) {
            string thisWager = "";
            player.chipTotal -= betAmt;
            thisWager += String.Format("Player {0}: Wagered {1} chips.\n", player.name, betAmt);
            currentPot.add(betAmt);
            thisWager += String.Format("Pot total: {0}", currentPot.total);
            return thisWager;
        
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

        public String credit(Player player) { 
            player.chipTotal += total;
            string retString = String.Format("Crediting {0} {1} chips!", player.name, total);
            total = 0;
            return retString;
        }
            

        public String getTotal() {
            return Convert.ToString(this.total);
        }
    }
}