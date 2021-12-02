using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SamRab
{

    public class ThreadPrioritet
    {
       Random r = new Random();

       public int Prioritet = 0;
       public Thread th = null;

       public ThreadPrioritet()//Пункт 2. Рандомно задаем приоритет 
       {
         Prioritet = r.Next(1, 10);
       }

        public List<ThreadPrioritet> tmp = new List<ThreadPrioritet>();

        public void Init(int count, Action<object> act)//создание списка с заданным количеством 
        {
            tmp = new List<ThreadPrioritet>(count);
            for(int i = 0; i < count; ++i)
            {
                th = new Thread(new ParameterizedThreadStart(act));
                tmp.Add(new ThreadPrioritet() { th = th });
            }
        }

        public List<ThreadPrioritet> GetThread(int p) //получение всех объектов с заданным приоритетом p
        {
            List<ThreadPrioritet> res = new List<ThreadPrioritet>();

            for(int i = 0; i < tmp.Count; ++i)
            {
                if(tmp[i].Prioritet == p)
                {
                    res.Add(tmp[i]);
                }
            }

            return res;
        }

        public List<IGrouping<int, ThreadPrioritet>> Group() //группировка по приоритетности 
        {
            tmp = (from el in tmp
                  orderby el.Prioritet
                  select el).ToList();
           return tmp.GroupBy(x => x.Prioritet).ToList();
        }


        public void print(object path) //метод, которые будут выполнять потоки
        {

            using (StreamWriter file = new StreamWriter(path.ToString()))
            {

                for (int i = 0; i <= 100; i++)
                {
                    file.WriteLine("Запись:" + i);

                }
            };
        }
    }

    class Class1
    {
        Random random = new Random();

        public void Start()
        {
           // var t = new Thread(new ParameterizedThreadStart(print));
           // t.Start(@"test_2.txt");

            List<ThreadPrioritet> threads = new List<ThreadPrioritet>(10);

            for(int i = 1; i <= 10; i++)
            {
               
              
            }
        }



        public void print(object path)
        {
            
            using (StreamWriter file = new StreamWriter(path.ToString()))
            {
               
                for (int i = 0; i <= 100; i++)
                {
                    file.WriteLine("Запись:" + i);
                    
                }
            };
            

        }

    }
}
