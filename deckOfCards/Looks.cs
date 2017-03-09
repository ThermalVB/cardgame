using System;

namespace DeckOfCards {
    public class Looks {
        int width;
        public Looks(int w = 60) {
            // Change width to what you want.
            width = w;
        }

        public void TopLine(){
            Console.WriteLine("┏".PadRight(width+7, '━') + "┓");
        }
        public void BottomLine(){
            Console.WriteLine("┗".PadRight(width+7, '━') + "┛");
        }
        public void BlankLine(int repeat = 1){
            for(int i = 0; i < repeat; i++){
                Console.WriteLine("┃".PadRight(width+7, ' ') + "┃");
            }
        }
        public string User_Input(string input){
            Console.Write("{0}: ", input);
            return Console.ReadLine();
        }

        public void CreateLine(string myLine) {            
            string tempLine = myLine;
            while(myLine.Length > width){
                Console.WriteLine("┃   "+myLine.Substring(0, width)+"   ┃");
                myLine = myLine.Substring(myLine.Length-(myLine.Length-width));
            }
            Console.WriteLine("┃   "+myLine.PadRight(width, ' ')+"   ┃");
            
        }

        public void CenterLine(string myLine) {
            int padLeft = (width - myLine.Length)/2 + myLine.Length;
            Console.WriteLine("┃   "+myLine.PadLeft(padLeft, ' ').PadRight(width, ' ')+"   ┃");
        }


    }
}