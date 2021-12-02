using System;
using System.IO;
using System.Linq;

namespace SamRab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1 cl1 = new Class1();
            //cl1.Start();


            ThreadPrioritet tp = new ThreadPrioritet();
            tp.Init(10, start);

            var gr = tp.Group();

            for(int i = 0; i < gr.Count; ++i)
            {
                var tmp = gr[i].ToList();

                for(int j = 0; j < tmp.Count; ++j)
                {
                    tmp[j].th.Start("");
                     var end_g = gr[gr.Count - 1].ToList();  // пункт 5, меняем приоритет
                    tmp[j].Prioritet = end_g[0].Prioritet;   //  
                }
            }
        }

        private static void start(object obj)
        {
            
        }
    }
}
