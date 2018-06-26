using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = new int[] {-5,-4,-2,0,1,2,5,6,7,9,11,12,15};

            string result = Extract(numbers);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static string Extract(int[] args)
        {
            int count = 0;
            int mount = 0;
            int donut = 0;
            int pount = 0;
            ArrayCorrection a1 = new ArrayCorrection(count, mount, donut, pount, args);
            string answer = a1.FigureOut();
            answer = answer.Remove(answer.Length-1);
            return answer;
            
        }
        class ArrayCorrection
        {
            public int Count { get; set; }
            public int Mount { get; set; }
            public int Donut { get; set; }
            public int Pount { get; set; }
            public int[] Numbers { get; set; }

            string string1 = "";
            string string2 = "";
            string string3 = "";
            string stringfinal = "";
            int iteration = 0;

            public ArrayCorrection(int count, int mount, int donut, int pount, int[] numbers)
            {
                this.Count = count; //1,2, or 3+ consecutive numbers
                this.Mount = mount; //current iteration
                this.Donut = donut;//total for loops iteration
                this.Pount = pount; ////current iteration which then increases by 1 due to forloop
                this.Numbers = numbers;
            }
            public string FigureOut()
            {
                for (int i = Pount; i < Numbers.Length-1; i++)
                {
                     int a = Numbers[Mount];
                    if (Numbers[Mount] == Numbers[(Mount+1)+iteration] -(iteration)-1)
                    { 
                      
                        //int b = Numbers[(Mount + 1) + iteration];
                        //int c = -(iteration) - 1;
                        Donut++;
                        Count++;
                        iteration++;
                    }
                    else
                        break;
                }

                if (Count >= 2)
                {
                    return StringType3();
                }
                if (Count == 1)
                {
                   return StringType2();
                }
                else
                {
                    return StringType1();
                }
            }
            public string StringType1()
            {
                string1 = Numbers[Mount] + ",";
                Donut++;
                Mount++;
                Pount++;
                return StringCombiner();
            }
            public string StringType2()
            {
                iteration = iteration - 1;
                string2 = Numbers[Mount] + "," + Numbers[(Mount + 1) + iteration] + ",";
                return ResetforType2and3();
            }
            public string StringType3()

            {
                iteration = iteration - 1;
                string3 = Numbers[Mount] + "-" + Numbers[(Mount + 1) + iteration] + ",";
                return ResetforType2and3();
            }
            public string ResetforType2and3()
            {
                Pount = Donut+1;
                Mount = Donut+1;
                Donut = Mount;
                Count = 0;
                iteration = 0;
                return StringCombiner();
            }
            public string StringCombiner()
            {
                stringfinal = stringfinal + string1 + string2 + string3;
                string1 = "";
                string2 = "";
                string3 = "";
                if (Donut < Numbers.Length)
                {
                    FigureOut();
                }
                return stringfinal;
            }

        }
    }
}
