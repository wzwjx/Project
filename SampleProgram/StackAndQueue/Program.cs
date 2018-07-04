using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str;
            //do
            //{
            //    Parentheses();
            //    Console.WriteLine("enter 'c' continue to testing:");
            //    str = Console.ReadLine();
            //} while (str == "c");



            Queue queue = new Queue(10);
            queue.Enqueus(1);
            queue.Enqueus(2);
            queue.Enqueus(3);
            Queue clonequeue = queue.Clone();
            int j = clonequeue.tail;
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine(clonequeue.Dequeue());
            }
            Console.ReadLine();



        }
        public static void Parentheses()
        {
            Console.WriteLine("Please enter string with brackets:");
            string k = Console.ReadLine();
            Stack stack = new Stack(k.Length);
            int a = 0, b = 0;

            //Traverse string.
            for (int i = 0; i < k.Length; i++)
            {
                string str = k[i].ToString();
                
                //push left parenthesis to stack.
                if (str.Equals("(") || str.Equals("{") || str.Equals("["))
                {
                    stack.Push(k[i]);
                    a++;
                }

                //pop left parenthesis which is correspond right parenthesis 
                while (str.Equals(")"))
                {
                    b++;
                    if (!stack.IsEmpty() && stack.Peek().ToString().Equals("("))
                    {
                        stack.Pop();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid Parentheses");
                        return;
                    }
                }

                while (str.Equals("]"))
                {
                    b++;
                    if (!stack.IsEmpty() && stack.Peek().ToString().Equals("["))
                    {
                        stack.Pop();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid Parentheses");
                        return;
                    }
                }

                while (str.Equals("}"))
                {
                    b++;
                    if (!stack.IsEmpty() && stack.Peek().ToString().Equals("{"))
                    {
                        stack.Pop();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid Parentheses");
                        return;
                    }
                }

            }
            if (stack.IsEmpty() && a-b==0)
            {
                Console.WriteLine("Valid Parentheses");
            }
            else if(a>b)
            {
                Console.WriteLine("invalid Parentheses");
            }
        }
    }
}
