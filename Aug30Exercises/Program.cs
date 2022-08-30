using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Aug30Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            int[] m = new int[n];
            Console.WriteLine("Enter {0} elements", n);
            for (int i = 0; i < n; i++)
            {
                m[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("1.Insertion sort\n 2.Bubblesort\n 3.Selectionsort\n 4.Quicksort");
            int k = Convert.ToInt32(Console.ReadLine());
            switch (k) {
                case 1:
                    insertion s = new insertion();
                    s.ascsort(m);
                    s.dessort(m);
                    break;
                case 2:
                    bubblesort sp = new bubblesort();
                    sp.ascsort(m);
                    sp.dessort(m);
                    break;

                case 3:
                    selection sd = new selection();
                    sd.ascsort(m);
                    sd.dessort(m);
                    break;
                case 4:
                    quicksort ds = new quicksort();
                    ds.sort(m,0,m.Length-1);
                    
                    break;
            }
            Console.ReadLine();

        }
    }
    public class insertion
    {
        public void ascsort(int[] m)
        {
            int[] g = new int[m.Length];
            int k = m.Length;
            g = m;
            for (int i = 1; i < k; i++)
            {
                int key = g[i];
                int j = i - 1;
                while (j >= 0 && g[j] > key)
                {
                    g[j + 1] = g[j];
                    j = j - 1;
                }
                g[j + 1] = key;

            }
            Console.WriteLine("Ascending sort");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }

        }
        public void dessort(int[] m)
        {
            int[] g = new int[m.Length];
            int k = m.Length;
            g = m;
            for (int i = 1; i < k; i++)
            {
                int key = g[i];
                int j = i - 1;
                while (j >= 0 && g[j] < key)
                {
                    g[j + 1] = g[j];
                    j = j - 1;
                }
                g[j + 1] = key;

            }
            Console.WriteLine("Descending sort");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }

        }
    }
    public class selection
    {
        public void ascsort(int[] m)
        {
            int[] g = new int[m.Length];
            g = m;
            int min;
            for (int i = 0; i < g.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < g.Length; j++)
                {
                    if (g[j] < g[min])
                    {
                        int temp;
                        temp = g[min];
                        g[min] = g[j];
                        g[j] = temp;
                    }
                }


            }
            Console.WriteLine("Ascending order");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }
        }
        public void dessort(int[] m)
        {
            int[] g = new int[m.Length];
            g = m;
            int max;
            for (int i = 0; i < g.Length; i++)
            {
                max = i;
                for (int j = i + 1; j < g.Length; j++)
                {
                    if (g[j] > g[max])
                    {
                        int temp;
                        temp = g[max];
                        g[max] = g[j];
                        g[j] = temp;
                    }
                }

            }
            Console.WriteLine("Descending order");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }
        }
    }
    public class bubblesort
    {
        public void ascsort(int[] m)
        {
            int[] g = new int[m.Length];
            g = m;
            for (int i = 0; i < g.Length - 1; i++)
            {
                for (int j = 0; j < g.Length - i - 1; j++)
                {
                    if (g[j + 1] < g[j])
                    {
                        int temp;
                        temp = g[j];
                        g[j] = g[j + 1];
                        g[j + 1] = temp;

                    }
                }
            }
            Console.WriteLine("Ascending order");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }

        }
        public void dessort(int[] m)
        {
            int[] g = new int[m.Length];
            g = m;
            for (int i = 0; i < g.Length - 1; i++)
            {
                for (int j = 0; j < g.Length - i - 1; j++)
                {
                    if (g[j + 1] > g[j])
                    {
                        int temp;
                        temp = g[j];
                        g[j] = g[j + 1];
                        g[j + 1] = temp;

                    }
                }
            }
            Console.WriteLine("Descending order");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }

        }


    }
    public class quicksort{
        public static void calling(int[] m)
        {
            int[] g = new int[m.Length];
            int[] k= new int[m.Length];
            g = m;
            k = m;
            Array.Sort(g);
            bool s=true;
            for(int i = 0; i < g.Length; i++)
            {
                if (g[i] != k[i])
                {
                    s = false;
                    break;
                }

            }
            if (s)
            {
                for(int i = 0; i < m.Length; i++)
                {
                    Console.WriteLine(g[i]);
                }
            }
        }
        public void sort(int[] m,int l,int h)
        {
           
            if (l < h)
            {
                int pivot = partition(m, l, h);
                sort(m,l,pivot-1);
                sort(m,pivot+1, h);
            }

        }
        private static int partition(int[] m,int left,int right)
        {
            int pivot = m[right];
            int i = left;
            int temp;
            for(int j = left; j <=right; j++)
            {
                if (m[j] < pivot)
                {
                   
                    temp = m[j];
                    m[j] = m[i];
                    m[i] = temp;
                    i++;
                }
            }
            temp=m[right];
            m[right] = m[i];
            m[i] = m[right];
            calling(m);
            return i;
        }
        }
}