using System;

namespace MyLibrary
{
    class ConsoleInput
    {
	// метод для чтения/ввода значений целого типа int с клавиатуры
        public static int ReadInt()
        {
            int N = 0;
            string stroka;
            bool flag;  // true , false
            do
            {
                flag = true;
                Console.Write(" : ");
                stroka = Console.ReadLine();  // "100"

                try
                {
                    N = Int32.Parse(stroka);
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                    flag = false;
                }
                catch (OverflowException exc)
                {
                    Console.WriteLine(exc.Message);
                    flag = false;
                }
            } while (flag == false);
            // или   // }while(!flag);  //или   // }while (flag!=true)

            return N;
        }  //end ReadInt()

         /*
		Копируем предыдущий метод public static int ReadInt()- чтения целых значений с клавиатуры
		Вносим следующие изменения для получения метода для чтения c клавиатуры значений типа double:


        */
	// метод для чтения/ввода значений типа double с клавиатуры
        public static double ReadDouble()  //  1- меняем название метода ReadInt() на ReadDouble(), 2 - тип возвращаемого значения double
        {
            double N = 0;               //  3  изменяем тип переменной int=> double
            string stroka;
            bool flag;  // true , false
            do
            {
                flag = true;
                Console.Write(" : ");
                stroka = Console.ReadLine();  // "100"

                try
                {
                    N = Double.Parse(stroka); //   4 Int32 -> Double  - последнее изменение в методе, ставим тип нужного метода Parse
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                    flag = false;
                }
                catch (OverflowException exc)
                {
                    Console.WriteLine(exc.Message);
                    flag = false;
                }
            } while (flag == false);
            // или   // }while(!flag);  //или   // }while (flag!=true)

            return N;
        }  //end ReadInt()
    }
}
