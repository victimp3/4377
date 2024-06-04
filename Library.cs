using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace MyLibrary
{
    class Library
    {
        List<Card> list;

        string fileName = "lib.dat";
        public Library()
        {
            list = new List<Card>();

            this.LibraryLoad();
        }

        public int CountCard {  get { return list.Count; } }

        public void Add(Card card)
        {
            list.Add(card);
        }

        public void Add(string author, string title, int number) 
        {
            //Card card = new Card(author,title, number);
            //list.Add(card);

            list.Add(new Card(author, title, number));
        }

        public void Add()
        {
            list.Add(new Card());
        }

        public bool IsUnique(Card cardTarget)
        {
            foreach(Card card in list)
            {
                if (
                    card.Title.Equals(cardTarget.Title) &&
                    card.Author.Equals(cardTarget.Author) &&
                    card.Number.Equals(cardTarget.Number)
                    )
                {
                    return false;
                }
            }return true;
        }

        public List<Card> GetCardsByAuthor(string author)
        {
            List<Card> foundCards = new List<Card>();
            foreach (Card card in list)
            {
                if (card.Author.Equals(author)) { foundCards.Add(card); }
            }
            return foundCards;
        }


        void PrintHeader()
        {
            Console.WriteLine("\n\n{0,-30} {1,-30} {2,3}",
                "Автор","Название книги", "Количество книг");
            Console.WriteLine(
                "______________________________________________________________________________"
                );
            
        }
        public void Print()
        {

            if (list.Count > 0)
            {
                PrintHeader();
                foreach (Card card in list)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Список пустой!!!");
            }
            Console.WriteLine();
        }

        //поиск всех книг, которые соответствуют введённому фрагменту названия"
        public void FindPartTitle(string title)
        {
            Console.WriteLine();
            int count = 0;

            foreach (Card card in list)
            {
                if (card.Title.ToUpper().IndexOf(title.ToUpper()) >= 0)
                {
                    if(count == 0)
                    {
                        PrintHeader();
                    }
                    Console.WriteLine(card);
                    count++;
                }
            }
            Console.WriteLine();
            PrintFooter(count);
        }

        public void SortCards()
        {
            list.Sort();
        }

        public Card FindCardByTitle(string title)
        {
            Card foundCard = null;
            foreach (Card card in list)
            {
                if (card.Title.Equals(title)) { foundCard = card; }
            }
            return foundCard;
        }

        public int NumberOfCards()
        {
            return list.Count;
        }

        public int NumberOfBooks() 
        {
            int count = 0;
            foreach (Card card in list)
            {
                count = count + card.Number;
            }
            return count;
        }

        void PrintFooter(int count)
        {
            if(count == 0)
            {
                Console.WriteLine("\nЗапрашиваемая книга не найдена\n");
            }
            else
            {
                Console.WriteLine("\nНайдено: {0} \n", count);
            }
        }

        //*IO*
        //Сохраняем информацию в файл в текстовом/символьном формате
        public void LibrarySave()
        {
            try
            {
                //FileStream FS = new FileStream(fileName, FileMode.Create);
                //StreamWriter write_handler = new StreamWriter(FS);

                StreamWriter write_handler =
                    new StreamWriter(new FileStream(fileName, FileMode.Create));

                foreach (Card card in list)
                {
                    write_handler.WriteLine(card.StringToFile());
                }

                write_handler.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                MyConsole.Pause("RUS");
            }
        }

        //Читаем из текстового файла информацию и заносим в объект lib
        void LibraryLoad()
        {
            //FileStream FS = new FileStream(fileName, FileMode.Open);
            //StreamReader reader_handler = new StreamReader(FS);

            try
            {
                StreamReader reader_handler =
                  new StreamReader(
                       new FileStream(fileName, FileMode.Open));

                string str;

                while ((str = reader_handler.ReadLine()) != null)
                {
                    //Разделеям строку на три части по сепаратору/разделителю '|'
                    string[] part = str.Split('|');

                    //Если строка разделилась на три подстроки, создаём объект класса Card
                    //и добавляем объект в наш каталок библиотечных карточек
                    if (part.Length == 3)
                    {
                        Card card = new Card(
                            part[0].Trim(), part[1].Trim(),
                            Int32.Parse(part[2].Trim()));

                        list.Add(card);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Некорректная распоковка строки");
                         MyConsole.Pause("RUS");
                    }
                }//end while

                reader_handler.Close();


            }
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    MyConsole.Pause("RUS");
            //    return;
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    MyConsole.Pause("RUS");
            //}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MyConsole.Pause("RUS");
            }
        }
    }
}
