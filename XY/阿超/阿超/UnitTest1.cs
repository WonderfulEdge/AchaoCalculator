using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Build                       //运算类
    {
        private struct Calcu          //结构体，
        {
            public int x, y, z;       //x,y,z表示三个数据
            public int Sym1, Sym2;     //Sym1,Sym2表示运算符号
        }

        private void Choice(int Sym)  //符号选择方法
        {                             //通过随机数函数random从（1——5）随机产生的数来返回一个相应的返回符
            if (Sym == 1)
                Console.Write("+");
            else if (Sym == 2)
                Console.Write("-");
            else if (Sym == 3)
                Console.Write("*");
            else
                Console.Write("/");
        }

        private int Operation(int x, int Sym, int y)  //运算类型选择方法
        {                                             //通过随机数函数random从（1——5）随机产生的数来返回相应的运算类型
            if (Sym == 1)
                return x + y;
            else if (Sym == 2)
                return x - y;
            else if (Sym == 3)
                return x * y;
            else
                return x / y;
        }

        private bool Judge(List<Calcu> Calcu, Calcu r) //通过bool类型来排除几种运算错误的情况并来返回一个true
        {
            for (int i = 0; i < Calcu.Count; i++)
            {
                if (Calcu[i].x == r.x && Calcu[i].y == r.y && Calcu[i].z == r.z && Calcu[i].Sym1 == r.Sym1 && Calcu[i].Sym2 == r.Sym2)
                {
                    return false;
                }                               //判断是否重复
            }
            if (r.Sym1 == 4 && (r.x / r.y * r.y) != r.x)
            {
                return false;
            }
            if (r.Sym2 == 4 && ((r.Sym1 <= 2 && (r.y / r.z * r.z) != r.y) || (r.Sym1 > 2 && (Operation(r.x, r.Sym1, r.y) / r.z * r.z) != Operation(r.x, r.Sym1, r.y))))
            {
                return false;
            }                                   //判断是否为小数
            return true;
        }

        private int Sum(Calcu r)                //运算方法
        {

            if (r.Sym1 > 2 || r.Sym2 <= 2)
                return Operation(Operation(r.x, r.Sym1, r.y), r.Sym2, r.z);
            else
                return Operation(r.x, r.Sym1, Operation(r.y, r.Sym2, r.z));
            //返回运算结果
        }

        public Build(int n)                     //构造函数
        {
            List<Calcu> Calcu = new List<Calcu>();
            for (int i = 0; i < n;)
            {
                i++;
                Random ran = new Random();
                while (true)                    //当返回的为true时，进行随机数的产生
                {
                    Calcu r = new Calcu();
                    r.x = ran.Next(1, 100);     //从1——100中随机产生一个x
                    r.Sym1 = ran.Next(1, 5);    //从1，2，3，4中随机产生一个Sym
                    r.y = ran.Next(1, 100);     //从1——100中随机产生一个y
                    r.Sym2 = ran.Next(1, 5);
                    r.z = ran.Next(1, 100);
                    if (Judge(Calcu, r))
                    {
                        Calcu.Add(r);
                        break;
                    }
                }
            }                                   //将随机产生的数值相加
            int j = 1;
            for (int i = 0; i < n; i++)
            {
                Console.Write(j + ". ");
                j++;
                Console.Write(Calcu[i].x);
                Choice(Calcu[i].Sym1);
                Console.Write(Calcu[i].y);
                Choice(Calcu[i].Sym2);
                Console.WriteLine(Calcu[i].z + "=");
            }                                     //运算过程
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入题目数目：");     //输入一个整数n
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("题目如下：");
            Build run = new Build(n);            //实例化构造函数并调用
        }
    }
}
