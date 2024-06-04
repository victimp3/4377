using System;

namespace MyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConsole.StartCyrillic();

            Library lib = new Library(); //Создаём экземпляр класса Library и присваиваем ему переменную lib

            for (; ; ) //Бесконечный цикл for
            {
                Console.Clear(); //Очистка консольного окна

                int key = Menu(); //Метод Menu показывает список опций и просит выбрать одну из них.
                                  //Затем метод возвращает номер выбранной опции как число.

                string inputTitle; //Объявляю переменные для хранения введенных данных
                string inputAuthor;
                string inputNumber;

                switch (key)
                {
                    case 0:  //для тестирования
                        Console.WriteLine("Добавили тест");

                        lib.Add("M. Ben-Ari", "Programming languages", 13);
                        lib.Add("George Bernard Dantzig", "Theory and extensions", 11);
                        lib.Add("Steve Oualline", "Practical C++ programming", 3);
                        lib.Add("Steve Oualline", "#Test", 3);
                        lib.Add("Larry Wall, Tom Christiansen", "Programming Perl", 2);
                        lib.Add("Jesse Liberty", "Programming C#", 9);
                        lib.Add("Eric S. Raymond", "The Art of Unix Programming", 7);

                        lib.Add(new Card("Benjamin C. Pierce", "Types and Programming Languages", 5));

                        lib.Add(new Card("Herb Schildt", "C# A Beginner's Guide", 25));

                        lib.Add(new Card("Herb Schildt", "C#", 5));
                        lib.Add(new Card("Herb Schildt", "Java 2.1", 5));

                        lib.Add();
                        //Метод Add добавляет новую карточку в каталог библиотеки.

                        break;

                    case 1:
                       
                        Console.WriteLine();
                        // код для добавления новой карточки в библиотеку
                        while (true) ////начало бесконечного цикла, который будет продолжаться до тех пор, пока не будет выполнено условие выхода
                        {
                            Console.Write("введите название карты: ");
                            inputTitle = Console.ReadLine(); Console.WriteLine(); //считывает ввод пользователя и печатает пустую строку

                            if (inputTitle != "") break; // если ввести не пустую строку, прерываем цикл

                        }
                        // аналогичные блоки для ввода автора и кол-ва
                        while (true)
                        {
                            Console.Write("введите название автора: ");
                            inputAuthor = Console.ReadLine(); Console.WriteLine();
                            if (
                                inputAuthor != ""  //проверяет, что ввод не пустой
                                && !inputAuthor.Any(char.IsDigit) //проверяет, что ввод не содержит цифр 
                                ) break;
                        }
                        while (true)
                        {
                            Console.Write("введите кол-во: ");
                            inputNumber = Console.ReadLine(); Console.WriteLine();
                            if (
                                inputNumber != ""
                                && inputNumber.All(char.IsDigit) //проверяет, что ввод состоит только из цифр

                                ) break;
                        }
                        Card newCard = new Card(inputAuthor, inputTitle, Int32.Parse(inputNumber)); //создаю новый объект типа Card с введенными данными, а метод Int32.Parse преобразует строку в целое число,
                                                                                                    //для того, чтобы преобразовать введенное кол-во в целое число, которое затем используется для создания объекта Card

                        if (lib.IsUnique(newCard)) lib.Add(newCard); //проверяем, является ли карточка уникальной
                        else
                        {
                            Console.WriteLine("ДУБЛИКАТ!!"); Console.ReadLine();
                        }
                        break; //если карточка уникальна, она добавляется в библиотеку, иначе выводится сообщение о дубликате

                    case 2: //вызывает метод Print для печати каталога библиотеки
                        lib.Print();
                        break;

                    case 3: //позволяет искать карточку книги по названию и выводить её инфо
                        while (true)
                        {
                            Console.Write("введите название книги: ");
                            inputTitle = Console.ReadLine(); //считываем ввод с консоли и сохраняем его в переменную inputTitle
                            Console.WriteLine();
                            if (
                                inputTitle != "" //проверяю, если ли название книги не пустое, то выполняется оператор break
                                ) break;
                        }
                        Card card = lib.FindCardByTitle(inputTitle); //создаю переменную card, которая хранит информацию о книге
                                                                     //в эту переменную записывается результат поиска книги по названию. ищем с помощью метода FindCardByTitle, который принадлежит объекту lib
                        Console.WriteLine(card.ToString()); //выводится информация о найденной карточке книги
                        break;

                    case 4: //ищем книги по фрагменту названия
                        Console.Write("\nВведите строку для поиска: ");
                        string partTitle = Console.ReadLine().Trim();

                        lib.FindPartTitle(partTitle);

                        break;

                    case 5: //ищем книги по имени автора
                        //Steve Oualline
                        while (true)
                        {
                            Console.Write("введите название автора: ");
                            inputAuthor = Console.ReadLine();//считывает ввод с консоли и сохраняет его в переменную inputAuthor
                            Console.WriteLine();
                            if (
                                inputAuthor != ""
                                && !inputAuthor.Any(char.IsDigit) //проверяю, что строка inputAuthor не пустая и что в строке нет цифр
                                ) break;
                        }
                        List<Card> cards = lib.GetCardsByAuthor(inputAuthor); //объявляю переменную cards типа List<Card>
                                                                              //вызываю метод GetCardsByAuthor объекта lib, он принимает inputAuthor в качестве аргумента и возвращает список карточек того автора
                        foreach (Card c in cards) //цикл foreach будет проходить через каждый элемент в коллекции cards, а переменная c будет обозначать текущий элемент типа Card на каждом его шаге
                        {
                            Console.WriteLine(c.ToString()); //вызываю метод ToString, чтобы он преобразовывал элемент в строку, и эта строка выводилась бы на экран
                                                             //метод ToString у объекта Card должен возвращать описание карточки
                        }
                        break;

                    case 6: //сортирует карточки, сохраняет библиотеку и завершает выполнение программы
                        lib.SortCards();
                        lib.LibrarySave();
                        return;

                    case 7:
                        Console.WriteLine(lib.NumberOfCards()); //строчка просит показать кол-во карт, которые есть у объекта lib, используя метод NumberOfCards()
                                                                //"Console.WriteLine()" для того, чтобы вывести кол-во в консоль, чтобы можно было увидеть его на экране
                        Console.ReadLine(); break;

                    case 8:
                        Console.WriteLine(lib.NumberOfBooks()); //метод NumberOfBooks() должен возвращать кол-во книг из библиотеки
                        Console.ReadLine(); break;
                    case 9:
                        lib.Print(); lib.SortCards(); lib.Print(); break; //метод SortCards() сортирует карты в объекте lib
                }

                MyConsole.Pause("RUS");
            }

        }

        static int Menu()
        {
            int key = 0;

            string[] menuName =
            {
               "1 - добавить карточку в каталог",
               "2 - печать каталога",
               "3 - поиск нужной книги по названию",
               "4 - поиск по фрагменту названия",
               "5 - поиск книг автора",
               "6 - завершение работы",
               "7 - количество карточек в каталоге",
               "8 - количество книг в библиотеке",
               "9 - сортировка по автору"
            };

            do
            {
                foreach (string str in menuName)
                {
                    Console.WriteLine(str);
                }
                // Console.Write(": ");

                key = ConsoleInput.ReadInt();
            } while (key < 0 || key > menuName.Length);  //0 - для тестирования

            return key;
        }
    }
}