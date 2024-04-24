using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;

namespace Assignment2Fileio
{
    [Serializable]
    public class Logger
    {
        public static Logger l1 = new Logger();
        private Logger()
        {
            Console.WriteLine("logger created");
        }

        public static string getlog(string msg)
        {
            return msg + DateTime.Now.ToString();
        }
    }

    internal class Program
    {
        

        static void Main(string[] args)
        {
          //string s= Logger.getlog("sd");

            string path = @"C:\Users\IET\Desktop\DOT_NET\Myserialdeserial\Mydata2";
            //FileStream fs = new FileStream(path, FileMode.Append,FileAccess.Write);
            FileStream fs = null;
            if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                }
            Console.WriteLine("Enter your message");
            string txt = Console.ReadLine();

            StreamWriter sw = new StreamWriter(fs);
            sw.Write(txt);
            
            Console.WriteLine(Logger.getlog(txt));
            
            
            string s = Logger.getlog(txt);
            sw.AutoFlush = true;
            sw.Close();
            fs.Close();

            //BFormatter bf = new SoapFormatter();
            //bf.Serialize(fs, txt);
            //fs.Close();
            //Console.WriteLine("Done");
        }
    }
}
