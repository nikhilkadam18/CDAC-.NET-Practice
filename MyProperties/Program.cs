using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Workers workers = new Workers();
            //workers.WID = 1;
            workers.Name = "Ram";
            workers.Address="mumbai";
            Console.WriteLine("Id is:{0},Name is: {1},Address is: {2}",workers.WID,workers.Name,workers.Address);
        }
    }
    public class Workers
    {
        private int _WID = 10;
        private string _name;
        private string _Address;

        //public int WID
        //{
        //    get { return _WID; }
        //}
        public int WID
        {
            get { if(_WID==10)
                {
                    _WID = 1000;
                }
                    return _WID; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}
