using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtliKarinca
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("enter R (kaç tur çalışacak?): ");
            int R = Convert.ToInt16(Console.ReadLine());

            Console.Write("enter K (Atlı karıncaya kaç kişi binebilir?): ");
            int K = Convert.ToInt16(Console.ReadLine());

            Console.Write("enter N (Grup Sayısı?): ");
            int N = Convert.ToInt16(Console.ReadLine());

            List<int> people = new List<int>();

            for (int n = 0; n < N; ++n)
            {

                Console.Write("{0}.Gruptaki kişi sayısı : ", n + 1);
                int kisiSayisi = Convert.ToInt16(Console.ReadLine());
                if (kisiSayisi < K || kisiSayisi == K)
                {
                    people.Add(kisiSayisi);
                }
                else
                {
                    Console.WriteLine("K'ya eşit veya küçük sayı giriniz.");
                    n--;
                    continue;
                }
            }


            Console.WriteLine("Toplam Para = "+calculateAtliKarinca(people, R, K)+" TL");

            Console.ReadLine();

        }

        private static int calculateAtliKarinca(List<int> people, int R, int K)
        {
            int j = 0;
            int allSum = 0;
            List<int> peopleQueue = new List<int>(); 

            while (j < R)
            {
                int sum = 0;
                for (int i = 0; i < people.Count; ++i)
                {
                    sum += Convert.ToInt32(people[i]);
                    if (sum > K)
                    {
                        allSum = allSum + sum -Convert.ToInt32(people[i]);
                        for (int i_ = i; i_ < people.Count; ++i_)
                        {
                            peopleQueue.Add(Convert.ToInt32(people[i_]));
                        }
                        for (int i_ = 0; i_ < i; ++i_)
                        {
                            peopleQueue.Add(Convert.ToInt32(people[i_]));
                        }
                        people.Clear();
                        for (int k = 0; k < peopleQueue.Count; ++k)
                        {
                            people.Add(Convert.ToInt32(peopleQueue[k]));
                        }
                        peopleQueue.Clear();
                        break;
                    }
                    else if (sum == K)
                    {
                        allSum = allSum + sum;
                        ++i;
                        for (int i_ = i; i_ < people.Count; ++i_)
                        {
                            peopleQueue.Add(Convert.ToInt32(people[i_]));
                        }
                        for (int i_ = 0; i_ < i; ++i_)
                        {
                            peopleQueue.Add(Convert.ToInt32(people[i_]));
                        }
                        people.Clear();
                        for (int k = 0; k < peopleQueue.Count; ++k)
                        {
                            people.Add(Convert.ToInt32(peopleQueue[k]));
                        }
                        peopleQueue.Clear();
                        break;
                    }
                }
                ++j;
            }
            return allSum;

        }

    }
}
