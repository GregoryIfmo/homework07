using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.collection
{
    struct Note
    {
        private string _head;

        public string Head
        {
            get { return _head; }
            set { _head = value; }
        }
        
        private string _note;

        public string SingleNote
        {
            get { return _note; }
            set { _note = value; }
        }
        
        private DateTime _date;

        public DateTime Date
        {
            get { return _date;}
            set { _date = value; }
        }
        
        private Importance _importance;

        public Importance Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }
        
        private int _length;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public Note(string head, string note, Importance type)
        {
            _head = head;
            _note = note;
            _importance = type;

            _date = DateTime.Now;
            _length = _note.Length;
        }
        

        public Note(string head, string note, string type, DateTime Date)
        {
            _head = head;
            _note = note;
            if (type == "Common")
            {
                _importance = Importance.Common;
            }
            else if (type == "Important")
            {
                _importance = Importance.Important;
            }
            else
            {
                _importance = Importance.Common;
            }

            _date = Date;
            _length = _note.Length;
        }


        public string ToCsv()
        {
            string obj = _head + "," + _note + "," + _importance.ToString() + "," + _date.ToString() + "," + Convert.ToString(_length);


            return obj;
        }

        public void ShowNote()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine(_head);
            Console.WriteLine("Важность: "+ _importance.ToString());
            Console.WriteLine(_note);
            Console.WriteLine("Длинна записки: " + _length + " | " + _date);
            Console.WriteLine("---------------------------------");
        }

        

        
       
        
    }
}
