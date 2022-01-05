using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework07.collection;

namespace homework07.tools
{
    class Command
    {
        private List<Note> _сollection;

        public Command(List<Note> сollection)
        {
            _сollection = сollection;
        }
        
        public void Help()
        {
            Console.WriteLine("Help                 : Показать доступные команды");
            Console.WriteLine("Show                 : Просмотреть записи");
            Console.WriteLine("Add                  : Добавить новую запись");
            Console.WriteLine("Edit                 : Редактировать запись");
            Console.WriteLine("Delete               : Удалить запись");
            Console.WriteLine("Load                 : Загрузить из файла(при этом текущие записи будут удалены)");
            Console.WriteLine("Save_to_file         : Сохранить в выбраный файл");
            Console.WriteLine("Add_from_file        : Добавить записи из файла");
            Console.WriteLine("Save                 : Сохранить");
            Console.WriteLine("Show_by_date         : Показать записи по выбраному диапазону дат");
            Console.WriteLine("Sort                 : Отсортировать по выбраному полю");
            Console.WriteLine("Exit                 : Выход");
        }
        
        public void Show()
        {
            int i = 1;
            foreach(Note n in _сollection)
            {
                Console.WriteLine(i);
                n.ShowNote();
                i++;
            }
            Console.WriteLine("Все элементы успешно выведены, введите help для просмотра всех доступных команд");
        }

        public void Show(List<Note> collection)
        {
            int i = 1;
            foreach (Note n in collection)
            {
                Console.WriteLine(i);
                n.ShowNote();
                i++;
            }
            Console.WriteLine("Все элементы успешно выведены, введите help для просмотра всех доступных команд");
        }
        
        public Importance UserImportance()
        {
            Importance im;
            while (true)
            {
                
                Console.WriteLine("Выберите важность: Important, Common");
                string importance = Console.ReadLine();
                if(importance.Trim().ToLower() == "important")
                {
                    im = Importance.Important;
                    break;
                }else if(importance.Trim().ToLower() == "common")
                {
                    im = Importance.Common;
                    break;
                }
                else
                {
                    Console.WriteLine("вы ввели неподходящее значение, попробуйте ещё");
                    continue;
                }
            }

            return im;
        }
        public void Add()
        {
            
            Console.WriteLine("Введите заголовок:");
            string head = Console.ReadLine();
            Console.WriteLine("Напишите записку:");
            string note = Console.ReadLine();
            Importance importance = UserImportance();
            Note newNote = new Note(head, note, importance);
            _сollection.Add(newNote);
            Console.WriteLine("Элемент успешно добавлен, введите help для просмотра досупных команд");

        }

        
        public void Edit()
        {
            if (_сollection.Count() == 0)
            {
                Console.WriteLine("Похоже ваш ежедневник пуст, давайте добавим хотябы одну заметку");
                Add();
            }
            int number;
            while (true)
            {
                Show();
                
                Console.WriteLine("Введите номер элемента, который хотите отредактировать");
                number = UserInteger();
                if (number <= 0 | number > _сollection.Count())
                {
                    Console.WriteLine("Число отрицательное или больше количества заметок");
                    continue;
                }
                break;


            }
            Console.WriteLine("Какой пункт вы хотите отредактировать?");
            Console.WriteLine("0 - заголовок");
            Console.WriteLine("1 - записку");
            Console.WriteLine("2 - важность");
            int point;
            Note note = _сollection[number - 1];
            point = UserInteger();
            if (point == 0)
            {
                Console.WriteLine("Введите новый заголовок"); 
                string newHead = Console.ReadLine();
                note.Head = newHead;

            }else if(point == 1)
            {
                Console.WriteLine("Введите откоректированную записку"); 
                string newNote = Console.ReadLine();
                note.SingleNote = newNote;
            }
            else if(point == 2)
            {
                Importance importance = UserImportance();
                note.Importance =  importance;
            }
            _сollection.RemoveAt(number - 1);
            _сollection.Insert(number - 1, note);
            Console.WriteLine("Элемент успешно отредактирован");
        }

        public void Delete()
        {
            if (_сollection.Count() == 0)
            {
                Console.WriteLine("Похоже ваш ежедневник пуст, давайте добавим хотябы одну заметку");
                Add();
            }
            int number;
            while (true)
            {
                Show();

                Console.WriteLine("Введите номер элемента, который хотите аннигелировать");
                number = UserInteger();
                if (number <= 0 | number > _сollection.Count())
                {
                    Console.WriteLine("Число отрицательное или больше количества заметок");
                    continue;
                }
                _сollection.RemoveAt(number - 1);
                Console.WriteLine("Элемент успешно удалён");
                break;


            }
        }

        public void LoadFromFile()
        {
            Console.WriteLine("ВВедите название файла из которого хотите загрузить данные");
            string fileName = Console.ReadLine();
            FileWorker newFileWorker = new FileWorker(fileName);
            _сollection = newFileWorker.ReadFile();
        }

        public void Save()
        {
            FileWorker newFileWorker = new FileWorker("Notes.csv");
            newFileWorker.WriteFile(_сollection);
        }

        public void SaveToFile()
        {
            Console.WriteLine("ВВедите название файла в который хотите сохранить записки");
            string fileName = Console.ReadLine();
            FileWorker newFileWorker = new FileWorker(fileName);
            newFileWorker.WriteFile(_сollection);
        }

        public void AddFromFile()
        {
            Console.WriteLine("ВВедите название файла из которого хотите добавить данные к текущей коллекции");
            string fileName = Console.ReadLine();
            FileWorker newFileWorker = new FileWorker(fileName);
            List<Note> collection = newFileWorker.ReadFile();
            foreach(Note note in collection)
            {
                _сollection.Add(note);
            }

        }

        public DateTime UserDate()
        {
            int day;
            int month;
            int year;
            while (true)
            {
                Console.WriteLine("введите день начала промежутка");
                day = UserInteger();
                Console.WriteLine("Введите месяц начала промежутка");
                month = UserInteger();
                Console.WriteLine("Введите год начала промежутка");
                year = UserInteger();
                if ((day > 0) & (0 < month) & (month <= 12) & (year > 0))
                {
                    switch (month)
                    {
                        case 2:
                            if (day > 28)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {

                                break;
                            }
                            
                        case 4:
                            if (day > 30)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                        case 6:
                            if (day > 30)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                        case 7:
                            if (day > 30)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                            
                        case 9:
                            if (day > 30)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                        case 11:
                            if (day > 30)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                            
                        default:
                            if (day > 31)
                            {
                                Console.WriteLine("Введённые данные некорректны");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                            
                    }
                }
                else
                {
                    Console.WriteLine("Введённые данные некорректны");
                    continue;
                }
                break;
            }
            DateTime date = new DateTime(year, month, day);
            return date;
        }
        public void ShowByDate()
        {
            DateTime theFirstDate = UserDate();
            DateTime theSecondDate = UserDate();

            List<Note> collection = _сollection;
            foreach(Note note in collection)
            {
                if(DateTime.Compare(theFirstDate,note.Date)>=0 & DateTime.Compare(theSecondDate, note.Date) <= 0)
                {
                    continue;
                }
                else
                {
                    collection.Remove(note);
                }
            }
            Show(collection);
            Console.WriteLine("Все элементы c " + theFirstDate + " по " + theSecondDate + " выведены, введите help для просмотра всех доступных команд");

        }

        public void SortByDateNew()
        {
            List<Note> collection1 = new List<Note>(_сollection);
            List<Note> collection2 = new List<Note>();
            
            Note note;
            
            while (collection2.Count() < _сollection.Count())
            {
                            
                note = collection1[0];
                for (int i=0; i < collection1.Count();i++)
                {
                                
                    if (DateTime.Compare(collection1[i].Date, note.Date) > 0)
                    {
                        note = collection1[i];
                    }
                                
                }
                collection2.Add(note);
                collection1.Remove(note);
            }
            Show(collection2);
        }

        public void SortByDateOld()
        {
            List<Note> collection1 = new List<Note>(_сollection);
            List<Note> collection2 = new List<Note>();
            
            Note note;
            
            while (collection2.Count() < _сollection.Count())
            {
                            
                note = collection1[0];
                for (int i=0; i < collection1.Count();i++)
                {
                                
                    if (DateTime.Compare(collection1[i].Date, note.Date) < 0)
                    {
                        note = collection1[i];
                    }
                                
                }
                collection2.Add(note);
                collection1.Remove(note);
            }
            Show(collection2);
            
        }

        public void SortByLength()
        {
            List<Note> collection1 = new List<Note>(_сollection);
            List<Note> collection2 = new List<Note>();
            
            Note note;
            
            while (collection2.Count() < _сollection.Count())
            {
                            
                note = collection1[0];
                for (int i = 0; i < collection1.Count(); i++)
                {

                    if (collection1[i].Length> note.Length)
                    {
                        note = collection1[i];
                    }

                }
                collection2.Add(note);
                collection1.Remove(note);
            }
            Show(collection2);
        }

        public void ImportanceFirst()
        {
            List<Note> collection = new List<Note>();
            foreach (Note note in _сollection)
            {
                if (note.Importance==Importance.Important)
                {
                    collection.Add(note);
                }
            }
            foreach (Note note in _сollection)
            {
                if (note.Importance == Importance.Common)
                {
                    collection.Add(note);
                }
            }

            Show(collection);
            
        }

        public void CommonFirst()
        {
            List<Note> collection = new List<Note>();
            
            foreach (Note note in _сollection)
            {
                if (note.Importance == Importance.Common)
                {
                    collection.Add(note);
                }
            }
            foreach (Note note in _сollection)
            {
                if (note.Importance == Importance.Important)
                {
                    collection.Add(note);
                }
            }
            Show(collection);
        }
        public void Sort()
        {
            Console.WriteLine("Выберите значение для сортировки");
            Console.WriteLine("0 - остортировать по дате, сначала старые");
            Console.WriteLine("1 - остортировать по дате, сначала новые");
            Console.WriteLine("2 - отсортировать по длинне");
            Console.WriteLine("3 - сначала важные");
            Console.WriteLine("4 - сначала неважные");
            int number;
            while (true)
            {
                number = UserInteger();
                switch (number)
                {
                    case 0:
                        SortByDateOld();
                        break;
                    case 1:
                        SortByDateNew();
                        break;
                    case 2:
                        SortByLength();
                        break;
                    case 3:
                        ImportanceFirst();
                        break;
                    case 4:
                        CommonFirst();
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует");
                        continue;
                }
                break;
            }
            
        }



        public int UserInteger()
        {
            int number;
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    break;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            return number;
        }
    }
}
