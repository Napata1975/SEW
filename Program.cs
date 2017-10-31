using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.DoWork();
        }

        public void DoWork()
        {

            string path = "test.txt";
            string path1 = "testOutput2.txt";
            string path2 = "testInputSorted.txt";
            int iCounter = 0;
           
            string longestwanted = string.Empty;
            List<string> matchedList = new List<string>();
            List<string> wordslist = new List<string>();
            List<string> wordslistorig = new List<string>();
            List<string> wordsSorted = new List<string>();
            List<string> wordsSortedAscending = new List<string>();
          
            wordslistorig = Readdata(path);
            wordslist = wordslistorig.OrderByDescending(s => s.Length).ToList();
            wordsSorted = wordslist.OrderByDescending(s => s.Length).ToList();
            wordsSortedAscending = wordsSorted.OrderBy(x => x).ToList();
            string longest = wordsSorted.First();
            
            string longest2 = wordsSorted.Skip(1).First();

            string text = longest;
            string wanted = string.Empty;
            string outPut = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < wordsSorted.Count; i++)
            {

                longest = wordsSorted[i];
                text = longest;
                

                for (int j = 0; j < wordsSortedAscending.Count; j++)
                {
                    bool isWord = false;

                    string wd = wordsSortedAscending[j];
                    if (longest != wd)
                    {
                        string plural = wd + "s";
                        string edEnd = wd + "ed";
                        string esEnd = wd + "es";
                        if (text.Contains(edEnd) && wordsSortedAscending.Contains(edEnd) && wordsSortedAscending[j]!=edEnd)
                        {

                            int startIndex = text.IndexOf(edEnd);
                            while (startIndex > -1)
                            {
                                wanted = string.Empty;
                                wanted = text.Replace(edEnd, string.Empty);
                                text = string.Empty;
                                text = wanted;
                                startIndex = text.IndexOf(edEnd);
                            }
                        }

                        if (text.Contains(esEnd) && wordsSortedAscending.Contains(esEnd) && wordsSortedAscending[j] != esEnd)
                        {

                            int startIndex = text.IndexOf(esEnd);
                            while (startIndex > -1)
                            {
                                wanted = string.Empty;
                                wanted = text.Replace(esEnd, string.Empty);
                                text = string.Empty;
                                text = wanted;
                                startIndex = text.IndexOf(esEnd);
                            }
                        }
                        //if (text.Contains(plural) && wordsSortedAscending.Contains(plural) && !wordsSortedAscending.Equals(plural))
                        //if (text.Contains(plural) && wordsSortedAscending.Contains(plural))
                        //{

                        //    int startIndex = text.IndexOf(plural);
                        //    while (startIndex > -1)
                        //    {
                        //        wanted = string.Empty;
                        //        wanted = text.Replace(plural, string.Empty);
                        //        text = string.Empty;
                        //        text = wanted;
                        //        startIndex = text.IndexOf(plural);
                        //    }
                        //}
                        if (text.Contains(wd) && wordsSortedAscending.Contains(wd) )
                        {

                            int startIndex = text.IndexOf(wd);
                            while (startIndex > -1)
                            {
                                wanted = string.Empty;
                                wanted = text.Replace(wd, string.Empty);
                                text = string.Empty;
                                text = wanted;
                                startIndex = text.IndexOf(wd);
                            }
                        }
                    }
                }
                if (text.Length == 0)
                {

                    if (wordsSorted[i].Length > 10)
                    {
                        outPut = wordsSorted[i];
                        if (matchedList.Contains(outPut) == false)
                        {

                            iCounter++;
                            sb.AppendLine(outPut);
                            matchedList.Add(outPut);
                        }
                    }

                }
            }

            sb.AppendLine(System.Environment.NewLine);
            sb.AppendLine("Number of words:" + iCounter.ToString());


            File.WriteAllText(path1, sb.ToString());
          
            Console.WriteLine("DONE");


        }

        public List<string> Readdata(string path)
        {
            List<string> abcd = new List<string>();
            abcd = File.ReadAllLines(path).ToList();
            return abcd;
        }
    }
}
