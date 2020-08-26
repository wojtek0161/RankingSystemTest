using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace TestSubChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[] { 100, 100 ,50 ,40 ,40, 20, 10 }; // scores 
                                         //1      2     3     4   5  
            int[] myScore = new int[] { 5 , 25, 50,120 }; // my scores 


            int[] myPosInRanking = new int[myScore.Length];

            List<int> denseRanking = new List<int>();

            //separate duplicates 
            for (int i = 0; i < scores.Length; i++)
            {
                if (!denseRanking.Contains(scores[i]))
                {
                    denseRanking.Add(scores[i]);
                }
            }

            // estimate in-ranking position 
            for (int i = 0; i < myScore.Length; i++)
            {
                for (int j = 0; j < denseRanking.Count; j++)
                {
                    //check if her score exists 
                    if (denseRanking[j] == myScore[i])
                    {
                        myPosInRanking[i] = j+1;
                        break;
                    }
                    //check if her score is higher  

                    else if (  myScore[i] > denseRanking[j]  )
                    {
                        myPosInRanking[i] = j + 1;
                        break;
                    }     
                    else 
                    {
                        //continue if is lower  

                        continue;
                    }


                }
                //if unallocated add new position at the end 
                if (myPosInRanking[i] == 0)
                {
                    myPosInRanking[i] = denseRanking.Count+1;
                }

            }

            for (int i = 0; i < myPosInRanking.Length; i++)
            {
                     Console.WriteLine( myPosInRanking[i]);
            }


         
        }



    }
}
