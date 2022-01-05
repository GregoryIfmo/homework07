using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using homework07.collection;

namespace homework07.tools
{
    class FileWorker
    {
        //имя файла
        private string _fileName;

        public FileWorker(string fileName)
        {
            _fileName = fileName;
        }

        private List<Note> Collection = new List<Note>();

        public  List<Note> ReadFile()
        {

            string[] objects = File.ReadAllLines(_fileName);
            try
            {
                foreach (string s in objects)
                {
                    string[] parameters = s.Split(',');
                    Note newNote = new Note(parameters[0], parameters[1], parameters[2], Convert.ToDateTime(parameters[3]));
                    Collection.Add(newNote);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("У вас нет доступа к этому файлу");
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Такого файла не существует, попробуйте ещё раз");
               
            }

            return Collection;
        }

        public void WriteFile(List<Note> collection)
        {
            StreamWriter streamWriter = new StreamWriter(_fileName);
            try
            {
                foreach (Note note in collection)
                {
                    streamWriter.WriteLine(note.ToCsv());
                }
                Console.WriteLine("Ваши записки успешно записаны в файл: "+_fileName);
                streamWriter.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("У вас нет доступа к этому файлу");
                //Console.WriteLine("Обратитесь к администратору(если вы и есть администратор то выдайте себе права лол) и попробуйте снова, или используйте другой файл");
                //Console.WriteLine("Для возвращения в меню введите: exit");
                //Console.WriteLine("Для создания новго файла введите: create");

                streamWriter.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Такого файла не существует, попробуйте ещё раз");
                //Console.WriteLine("Для возвращения в меню введите: exit");
                //Console.WriteLine("Для создания новго файла введите: create");
                streamWriter.Close();
            }
        }
        
    }
}
