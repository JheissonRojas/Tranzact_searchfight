using System;
using System.Xml.XPath;
using System.Xml.Xsl;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;

/// **********************************************************************************//////
/// IMPORTANT NOTES
///  * The data is taken from the file WordsToSearch.txt allowing any number of words 
///    in vertical direction.
///  * For google search was used the Google Custom Search tool because of the Google restriction 
///    on divs id to get the total search when download the page and the the tool Google Custom Search
///    have a limit of searchs by day 
/// 
/// *************************************************************************************//////


namespace c__search_engine{
    
    class Program{
        private const int numberToSearchEngines = 2;
        private const int engine1 = 0;
        private  const int engine2 = 1;
        static void Main(String[] args){

            ini__searchFigth();
        }
        
        public static void ini__searchFigth(){
            string data; 
            ControlerGetData newdata = new ControlerGetData();
            data = newdata.getDataToSearch();
            string[] words = data.Split(Environment.NewLine);
            double amount;
            double[] amountsToCompare = new double[numberToSearchEngines];
            string[] namesEngine = new string[numberToSearchEngines];
            int[] winnerIndexes = new int[words.Length];
            double[] totals = new double[words.Length]; 
            int counter =0; 
            foreach(string word in words){
                totals[counter]=0;
                string cadToPrint = "";
                cadToPrint = word; 
                for(int i=0 ; i< numberToSearchEngines ; i++){
                    if(i == engine1){
                        searchEngine searchEngine1 = StartSearch.creatorSearchEngine(StartSearch.SearchEngine1);
                        amount = searchEngine1.getAmountOfResults(word);
                        amountsToCompare[i] = amount;
                        totals[counter] = totals[counter] + amount;
                        namesEngine[i] = StartSearch.SearchEngine1;
                        cadToPrint = cadToPrint + ": " + StartSearch.SearchEngine1 + ": " + amount;
                          
                    }
                    if(i == engine2){
                        searchEngine searchEngine2 = StartSearch.creatorSearchEngine(StartSearch.SearchEngine2);
                        amount = searchEngine2.getAmountOfResults(word);
                        amountsToCompare[i] = amount;
                        totals[counter] = totals[counter] + amount;
                        namesEngine[i] = StartSearch.SearchEngine2;
                        cadToPrint = cadToPrint + ", " + StartSearch.SearchEngine2 + ": " + amount;
                                 
                    }
                }

                Console.WriteLine(cadToPrint);
                winnerIndexes[counter] = getWinner(amountsToCompare);
                counter ++;
                
            }         
            string cadwinner = "";
            counter = 0;
            foreach(int index in winnerIndexes){
                cadwinner = namesEngine[index] + " winner: " + words[counter];    
                Console.WriteLine(cadwinner);
                counter++;
            }
            int totalindexwinner =getWinner(totals);
            Console.WriteLine("Total winner " + words[totalindexwinner]);
            
        }
        private static int getWinner(double[] numbers){    
            int index=0;
            double maxvalue =0; 
            for(int i =0; i<numbers.Length; i++ ){
                if(numbers[i]>=maxvalue){
                    maxvalue=numbers[i];
                    index = i;     
                }

            }    
            return index;
        }

    }
}
