using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算
{
    class Program
    {

        private
        static void Main(string[] args)
        {
            int r = 10;
            int n = 1;
            int[] result = new int[2];
            Console.WriteLine("请输入生成题目的数量");
            string nn = Console.ReadLine();
            while (int.TryParse(nn, out n) == false)
            {
                Console.WriteLine("输入有误，请重新输入数字");
                nn = Console.ReadLine();
            }
            Console.WriteLine("请输入题目中数值的范围");
            nn = Console.ReadLine();
            while (int.TryParse(nn, out r) == false)
            {
                Console.WriteLine("输入有误，请重新输入数字");
                nn = Console.ReadLine();
            }
            calculation c = new calculation();
            int[][] ic = new int[n][];//n个计算式中计算数的和数
            for (int i = 0; i < n; i++)
            {
                string a = c.GetProblem(r, ref result, ref ic[i]);
                for (int j = 0; j < i; j++)
                {
                    if (ic[j] == ic[i])
                        a = "重新生成";
                }
                while (a == "重新生成")
                {
                    a = c.GetProblem(r, ref result, ref ic[i]);
                    for (int j = 0; j < i; j++)
                    {
                        if (ic[j] == ic[i])
                            a = "重新生成";
                    }
                }
                //将题目存入Exercises.txt中，可追加
                using (StreamWriter sw = new StreamWriter(@"F:\作业\软件工程\2\Exercises.txt", true))
                {
                    sw.WriteLine(i + ".四则运算题目 " + a);
                }
                //将答案存入Answers.txt
                using (StreamWriter sw = new StreamWriter(@"F:\作业\软件工程\2\Answers.txt", true))
                {
                    if (result[0] == 0 || result[1] == 1)
                        sw.WriteLine(i + ".答案 " + result[0].ToString());
                    else
                        sw.WriteLine(i + ".答案 " + result[0].ToString() + "/" + result[1].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
