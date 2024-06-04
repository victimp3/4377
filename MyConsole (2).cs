using System;
using System.Text;

namespace MyLibrary
{
    class MyConsole
    {
        /*
          по умолчанию метод будет печатать сообщение 
          на английском языке (str = "ENG").
          Если в качестве входного значения переменная str = "RUS",
          то сообщения будут печататься на русском языке
         */
        public static void Pause(string str = "ENG")
        {
            if (str == "ENG")
            {
                Console.Write("Press any key to continue...");
            }
            else if(str == "RUS"){
                Console.Write("" +
                    "\n\nНажми любую клавишу для продолжения...");
            }

            Console.ReadKey();
        }//end Pause()

        public static void StartCyrillic()
        {
            Encoding.RegisterProvider(
                CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
        }

    }
}
