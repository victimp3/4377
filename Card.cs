using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    //класс Card реализует (имплементирует)
    //интерфейс IComparable
    //задаём "правила" сравнения/сортровки объектов
    class Card : IComparable<Card>
    {
        string title;
        string author;
        int number;

        public string Title { get { return title; } }
        public string Author { get { return author; } }
        public int Number { get { return number; } }


        public Card(string author = "unknow",
            string title = "unknow", int number = 0)
        {
            SetInfo(author, title, number);
        }

        public void SetInfo(
            string author, string title, int number)
        {
            this.author = author;
            this.title = title;
            if (number >= 0)
            {
                this.number = number;
            }
            else
            {
                this.number = 0;
            }
        }

        public void Info()
        {
            Console.WriteLine(
                "author: {0,-20},title: {1,-30}, count:{2,3}",
                this.author, this.title, this.number);
        }

        public override string ToString()
        {
            return String.Format("{0,-30} {1,-40} {2,3}",
                this.author, this.title, this.number); 
        }

        //Формируем строку в определённом формате,
        //чтобы в дальнейшем было легко рапаковать строку и
        //выделить значения для полей класса

        public string StringToFile()
        {
            return String.Format("{0,-30} | {1,-40} | {2,3}",
                this.author, this.title, this.number); 
        }

        int IComparable<Card>.CompareTo(Card? other)
        {
            return this.Author.CompareTo(other.Author);
            //return this.Title.CompareTo(other.Title);
            //return this.Number.CompareTo(other.Number);
        }
    }
}
