using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLotteryu
{
    class LotteryManager
    {
        public Hashtable Cards = new Hashtable();
         

        public static void LoadFromFile()
        {
            byte maxNumber = 0;
            //Loads data from file into the hashtable.
            string[] LotteryFile = File.ReadAllLines(@"c:\Lotto.csv");

            Hashtable LotteryTable = new Hashtable();
            for (int i = 0; i < LotteryFile.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                string lotteryData = LotteryFile[i];
                string[] LineData = lotteryData.Split(',');
                Card p = new Card();
                p.IdentityNum = int.Parse(LineData[0]);
                for (int r = 0; r < 6; r++)
                {
                    p.Numbers[r] = byte.Parse(LineData[r + 2]);
                    if (maxNumber < byte.Parse(LineData[r + 2]))
                    {
                        maxNumber = byte.Parse(LineData[r + 2]);
                    }
                }
                p.AddedNum = byte.Parse(LineData[8]);
                LotteryTable.Add(p.IdentityNum, p);
            }
            Console.WriteLine(maxNumber);
        }
    }
}
