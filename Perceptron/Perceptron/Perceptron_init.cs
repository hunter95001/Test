using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Perceptron_init
    {
        private double a; //학습율 
        private double y; //가중치값 
        private double NET;
        private int val;
        private int Pattern;
        private int[,] Input_Array; //출력값 (-1<0<1) 
        private double[] Output_Array; //목표값 
        private double[] firstW; //가중치값 
        private double[,] w; //가중치.

        public Perceptron_init(int[][] setVal) {
            init();
           int[] ss= new int [25]{
               0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1 };
            calc();
            Console.WriteLine("학습 끝 2번째 시작");
            //calc(ss);
        }
        private void init() {
            w = new double[2, 3] { { 0.2, 0.1, -0.1 }, { 0, 0, 0 } };
            Input_Array = new int[9, 25] {
            { 0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1,
              0,0,0, 0, 1 },

            { 1, 1, 1,1,1,
              0,0,0, 0, 1,
              1, 1, 1,1,1,
              1, 0, 0,0,0,
              1, 1, 1,1,1},

            { 1,1,1, 1, 1,
              0,0,0, 0, 1,
              1,1,1, 1, 1,
              0,0,0, 0, 1,
              1,1,1, 1, 1},

            { 1,0, 1, 0,0,
              1,0, 1, 0,0,
              1,1, 1, 1,1,
              0,0, 1, 0,0,
              0,0, 1, 0,0},

            { 1,1, 1, 1,1,
              1,0, 0, 0,0,
              1,1, 1, 1,1,
              0,0, 0, 0,1,
              1,1, 1, 1,1},

            { 1,0, 0, 0,0,
              1,0, 0, 0,0,
              1,1, 1, 1,1,
              1,0, 0, 0,1,
              1,1, 1, 1,1},

            { 1,1, 1, 1,1,
              1,0, 0, 0,1,
              1,0, 0, 0,1,
              0,0, 0, 0,1,
              0,0, 0, 0,1},

            { 1,1, 1, 1,1,
              1,0, 0, 0,1,
              1,1, 1, 1,1,
              1,0, 0, 0,1,
              1,1, 1, 1,1},

             { 1,1, 1, 1,1,
              1,0, 0, 0,1,
              1,1, 1, 1,1,
              0,0, 0, 0,1,
              0,0, 0, 0,1},


             }; 
            Output_Array = new double[9] { -1, 1, 1, 1,1,1,1,1,1 };
        }
        private void NET_calc(double aNET){
            double T = 0;
            if (T < aNET)
                y = 1;
            else if (T == aNET)
                y = 0;
            else
                y = -1;
            Console.WriteLine("y :" + y);
        }
        private void calc() {
            double[] arr = new double[9];
            double count = 0;
           
            a = 1;
            NET = 0;
            val = arr.Length;
            Pattern = Output_Array.Length;
            do
            {
                count = 0;
                for (int j = 0; j < Pattern; j++){
                    for (int i = 0; i < val; i++){
                        arr[i] = arr[i] + w[0, i] * Input_Array[j, i];
                        NET = NET + arr[i];
                        Console.WriteLine(arr[i]);
                        arr[i] = 0;
                    }
                    Console.WriteLine("합계" + NET);
                    NET_calc(NET);
                    if (y == Output_Array[j]){
                        count++;
                        Console.WriteLine("목표값 일치");
                        for (int i = 0; i < val; i++){
                            w[1, i] = 0;
                            w[1, i] = w[0, i] + w[1, i];
                            Console.Write(w[1, i] + ", ");
                        }
                    }

                    else
                    {
                        Console.WriteLine("가중치 조정");
                        for (int i = 0; i < val; i++){
                            w[0, i] = a * (Output_Array[j] - y) * Input_Array[j, i];
                            w[0, i] = w[0, i] + w[1, i];
                            Console.Write(w[0, i] + ", ");
                        }
                    }

                    NET = 0;
                    Console.WriteLine();
                    Console.WriteLine("================================");
                }
            } while (count < Pattern);
            // Console.WriteLine("Input"+ Input+ "Patten"+Patten);
        }
        private void calc(int[] setArray)
        {
            double[] arr = new double[3];
            double count = 0;

            a = 1;
            NET = 0;
            val = arr.Length;
            Pattern = Output_Array.Length;
            do
            {
                count = 0;
                for (int j = 0; j < Pattern; j++) {
                    for (int i = 0; i < val; i++) {
                        arr[i] = arr[i] + w[0, i] * setArray[i];
                        NET = NET + arr[i];
                        arr[i] = 0;
                    }
                    NET_calc(NET);
                  
                        count++;
                       
                        for (int i = 0; i < val; i++)
                        {
                            w[1, i] = 0;
                            w[1, i] = w[0, i] + w[1, i];
                            Console.Write(w[1, i] + ", ");
                        }
                    
                    
                    NET = 0;
                    Console.WriteLine();
                    Console.WriteLine("================================");
                }
            } while (count < Pattern);
            // Console.WriteLine("Input"+ Input+ "Patten"+Patten);
        }

    }
}
