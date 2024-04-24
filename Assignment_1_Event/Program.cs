using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    public delegate void EventHandler();

    internal class Program
    {
        static void Main(string[] args)
        {
            EventExample example = new EventExample();



            EventHandler obj1 = new EventHandler(example.OnParseEvent);
            EventHandler obj2 = new EventHandler(example.OnValidateEvent);
            EventHandler obj3 = new EventHandler(example.OnSaveEvent);

            //coupling
            example.ParseEvent += obj1;
            example.validate += obj2;
            example.save += obj3;
            example.add();
        }

    }
    public class EventExample
    {
        public event EventHandler ParseEvent;
        public event EventHandler validate;
        public event EventHandler save;

        public void add()
        {
            ParseEvent();
            validate();
            save();
        }
        public void OnParseEvent()
        {
            Console.WriteLine("Parsing event Invoked");
        }
        public void OnValidateEvent()
        {
            Console.WriteLine("Validate event Invoked");
        }
        public void OnSaveEvent()
        {
            Console.WriteLine("save event Invoked");
        }
    }


   

}
