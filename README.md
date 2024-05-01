# CDAC-.NET-Practice
1]DemoOverriding

namespace _05DemoOverriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class CMath
    {
        public virtual void Add(int x, int y)
        {
            Console.WriteLine("Add = {0}",(x+y));
        }
        public void Sub(int x, int y)
        {
            Console.WriteLine("Sub = {0}", (x - y));
        }
        public virtual void Mul(int x, int y)
        {
            Console.WriteLine("Mul = {0}", (x * y));
        }
        public virtual void Div(int x, int y)
        {
            Console.WriteLine("Div = {0}", (x / y));
        }
    }
    public class AdvMath:CMath
    {
        public override void Add(int x, int y)
        {
            Console.WriteLine("Add = {0}", (x + y +100));
        }
        public void Square(int x)
        {
            Console.WriteLine("Square = {0}", (x*x));
        }

        public override void Mul(int x, int y)
        {
            // base.Mul(x, y);
            Console.WriteLine("Square = {0}", (x * y * 20));
        }
    }
}

2]Interface Factory Pattern
namespace _07OOPInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string op = null;
            do
            {
                Console.WriteLine("Enter your DB Choice :");
                Console.WriteLine("1.Sql Server, 2.Oracle Server 3. MySQL Server");
                int dbChoice = Convert.ToInt32(Console.ReadLine());
                DataBaseFactory dataBaseFactory = new DataBaseFactory();
                IDatabase db = dataBaseFactory.GetDataBase(dbChoice);
                
                Console.WriteLine("Enter your DB Operation Choice:");
                Console.WriteLine("1.Insert, 2. Update,3.Delete");
                int opChoice1 = Convert.ToInt32(Console.ReadLine());
                switch (opChoice1)
                {
                      case 1:
                            db.Insert();
                                break;
                      case 2:
                            db.Update();
                                break;
                      case 3:
                           db.Delete();
                                break;
                            default:
                                break;
                        }
                Console.WriteLine("Do you want to continue? y/n");
                op = Console.ReadLine();
            } while (op != "n");
        }
        
       
    }
    public interface IDatabase
    {
        void Insert();
        void Update();
        void Delete();
    }
    //Factory Pattern
    public class DataBaseFactory //Factory Classes
    {
        public IDatabase GetDataBase(int dbChoice)//Factory Methods
        {
            if(dbChoice == 1)
            {
                return new SQLServer();
            }
            else if(dbChoice == 2)
            {
                return new OracleServer();
            }
            else if(dbChoice==3)
            {
                MySQLServer mysqlObj = new MySQLServer();
                return mysqlObj;
            }
            else
            {
                return null;
            }
        }
    }
    public class SQLServer:IDatabase
    {
        public void Insert()
        {
            Console.WriteLine("Data Inserted into SQL Server Successfully!!");
        }
        public void Update()
        {
            Console.WriteLine("Data Updated into SQL Server Successfully!!");
        }
        public void Delete()
        {
            Console.WriteLine("Data Delete into SQL Server Successfully!!");
        }
    }
    public class OracleServer:IDatabase
    {
        public void Insert()
        {
            Console.WriteLine("Data Inserted into Oracle Server Successfully!!");
        }
        public void Update()
        {
            Console.WriteLine("Data Updated into Oracle Server Successfully!!");
        }
        public void Delete()
        {
            Console.WriteLine("Data Delete into Oracle Server Successfully!!");
        }
    }
    public class MySQLServer : IDatabase
    {
        public void Insert()
        {
            Console.WriteLine("Data Inserted into MySQL Server Successfully!!");

        }
        public void Update()
        {
            Console.WriteLine("Data Updated into MySQL Server Successfully!!");
        }
        public void Delete()
        {
            Console.WriteLine("Data Delete into MySQL Server Successfully!!");
        }
    }
   
}

3]Abstract class (pdf,txt,docx,xml-parse,validate..)

namespace _10OOPAbstarct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PDF pdf = new PDF();
            //pdf.Parse();
            //pdf.Validate();
            //pdf.Save();
            string closeOP = null;
            do
            {
               
                Console.WriteLine("Choose Report Option :");
                Console.WriteLine("1.PDF, 2. DOCX, 3. TXT, 4.XML");
                int choice = Convert.ToInt32(Console.ReadLine());
                ReportFactory factory = new ReportFactory();
                Report report = factory.GetReport(choice);
                report.GenerateReport();               

            } while (closeOP !="n");
            Console.ReadLine();
        }
        
    }
    public abstract class Report
    {
        protected abstract void Parse();
        protected abstract void Validate();
        protected abstract void Save();
        public virtual void GenerateReport()
        {
            Parse();
            Validate();
            Save();
        }
    }
    public abstract class SpecialReport:Report
    {
        protected abstract void ReValidate();
        public override void GenerateReport()
        {
            Parse();
            Validate();
            ReValidate();
            Save();
        }
    }
    public class ReportFactory
    {
        public Report GetReport(int choice)
        {
            if (choice == 1) 
            {
                return new PDF();
            }else if (choice == 2) 
            {
                return new DOCX();
            }
            else if (choice == 3)
            {
                return new TXT();
            }
            else if (choice == 4)
            {
                return new XML();
            }
            else
            {
                return null;
            }
        }
    }
    public class PDF :Report
    {
        protected override void Parse()
        {
            Console.WriteLine("PDF parsed");
        }
        protected override void Validate()
        {
            Console.WriteLine("PDF validated");
        }
        protected override void Save()
        {
            Console.WriteLine("PDF saved");
        }
        
    }
    public class DOCX : Report 
    {
        protected override void Parse()
        {
            Console.WriteLine("DOCX parsed");
        }
        protected override void Validate()
        {
            Console.WriteLine("DOCX validated");
        }
        protected override void Save()
        {
            Console.WriteLine("DOCX saved");
        }        
    }
    public class TXT : SpecialReport
    {
        protected override void Parse()
        {
            Console.WriteLine("TXT parsed");
        }
        protected override void Validate()
        {
            Console.WriteLine("TXT validated");
        }
        protected override void ReValidate()
        {
            Console.WriteLine("TXT Re validated");
        }
        protected override void Save()
        {
            Console.WriteLine("TXT saved");
        }
        
    }
    public class XML : SpecialReport
    {
        protected override void Parse()
        {
            Console.WriteLine("XML parsed");
        }
        protected override void Validate()
        {
            Console.WriteLine("XML validated");
        }
        protected override void ReValidate()
        {
            Console.WriteLine("XML Re validated");
        }
        protected override void Save()
        {
            Console.WriteLine("TXT saved");
        }

    }

}

4]Dependency injection(Notepad appln,spellchecker)

namespace _12OOPDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Notepad notepad = new Notepad(null);
            // Notepad notepad = new Notepad("fr");
            //Notepad notepad = new Notepad("hindi");
            //HindiSpellChecker hindiObj = new HindiSpellChecker();
            //Notepad notepad1 = new Notepad(hindiObj);
            //-----------------------------------------------------
            Notepad notepad1 = new Notepad(null);
            //-----------------------------------------------------
            //SpellCheckerFactory spellCheckerFactory = new SpellCheckerFactory();
            // ISpellChecker checker =  spellCheckerFactory.GetSpellChecker("gr");
            //Notepad notepad1 = new Notepad(checker);

            notepad1.SpellCheck();
        }
    }
    #region First approach based on lang selection 
    //public class Notepad
    //{
    //    //Notepad has Cut, Copy , Paste like functionalities here ....
    //    private ISpellChecker _someSpellChecker = null;
    //    SpellCheckerFactory factory = new SpellCheckerFactory();
    //    public Notepad(string lang)
    //    {
    //        if(lang == null) 
    //        {
    //            _someSpellChecker = factory.GetSpellChecker("eng");
    //        }else
    //        {
    //            _someSpellChecker = factory.GetSpellChecker(lang);
    //        }
    //    }
    //    public void SpellCheck()
    //    {
    //        _someSpellChecker.DoSpellCheck();
    //    }
    //} 
    #endregion
    public class Notepad
    {
        //Notepad has Cut, Copy , Paste like functionalities here ....
        private ISpellChecker _someSpellChecker = null;
        SpellCheckerFactory factory = new SpellCheckerFactory();
        public Notepad(ISpellChecker checker)//Constructor Dependency Injection
        {
            if (checker == null)
            {
                _someSpellChecker = factory.GetSpellChecker("eng");
            }
            else
            {
                _someSpellChecker = checker;
            }
        }
        public void SpellCheck()
        {
            _someSpellChecker.DoSpellCheck();
        }
    }
    public class HindiSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for Hindi!");
        }
    }
    public interface ISpellChecker
    {
        void DoSpellCheck();
    }
    public class SpellCheckerFactory
    {
        public ISpellChecker GetSpellChecker(string lang)
        {
            ISpellChecker spellChecker = null;
            switch (lang) 
            {
                case "eng":
                    spellChecker = new EnglishSpellChecker();
                    break;
                case "gr":
                    spellChecker = new GermanSpellChecker();
                    break;
                case "fr":
                    spellChecker = new FrenchSpellChecker();
                    break;
                default:
                    spellChecker = new EnglishSpellChecker();
                    break;
            }
            return spellChecker;
        }
    }
    public class EnglishSpellChecker :ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for English!");
        }
    }
    public class GermanSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for German!");
        }
    }
    public class FrenchSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for French!");
        }
    }
}

5]Sealed classes

namespace _13OOPSealed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String 
        }
    }
    public sealed class MyButton
    {
        public void RoundButton(string VideoURL)//$ 1000 
        {
            //code here...
        }
    }
    //public class CDAC :MyButton
    //{
    //    public void MyCustomiseButton()
    //    {
    //        base.RoundButton();
    //    }
    //}
}

5]events&Delegates

namespace _16EventsDelegates
{
    public delegate void MyDelgate(int mrk);
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine("Wlecome {0}", student.GetStudentName());
            Console.WriteLine("Enter your marks :");
            int mark = Convert.ToInt32(Console.ReadLine());

            MyDelgate myDel1 = new MyDelgate(student.onSuccess);
            MyDelgate myDel2 = new MyDelgate(student.onFailure);

            student.onPass += myDel1;
            student.onFail += myDel2;
            
            student.Mark = mark;

           

        }
       

    }
    public class Student
    {
        public event MyDelgate onPass;
        public event MyDelgate onFail;

        private int _Mark;

        public int Mark
        {
            get { return _Mark; }
            set 
            {
                _Mark = value;
                if(_Mark >=35)
                {
                    onPass(_Mark);
                }else
                {
                    onFail(_Mark);
                }
            }
        }

        public void onSuccess(int mrk)
        {
            Console.WriteLine("Congratulations you have passed with {0} marks :)", mrk);
        }
        public void onFailure(int mrk)
        {
            Console.WriteLine("Bravo!! you have failed with {0} marks :)", mrk);
        }
        public string GetStudentName()
        {
            return "Nisha";
        }
    }
}

6]Fileio seri,deseri

string filePath1 = @"D:\IETCDAC\MyData1.txt";
FileStream fs = null;
if (File.Exists(filePath1))
{
    fs = new FileStream(filePath1, FileMode.Append, FileAccess.Write);
}
else
{
    fs = new FileStream(filePath1, FileMode.CreateNew, FileAccess.Write);
}
Customer customer = new Customer();
Console.WriteLine("Enter ID :");
customer.Id = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter name ");
customer.CName = Console.ReadLine();
Console.WriteLine("Enter address");
customer.CAddress = Console.ReadLine();


StreamWriter write = new StreamWriter(fs);
write.Write(customer);
write.AutoFlush = true;
write.Close();
fs.Close();
Console.WriteLine("Done");

seri,deseri binary- 

  namespace MySerialD
{
    [Serializable]
    public class Student
    {
        private int _RollNo;
        private String _Name;

        public string Name
        {
            get { return _Name;}
            set { _Name = value; }
        }

        public int RollNo
        {
            get { return _RollNo; }
            set { _RollNo = value; }
        }
        public void SetStdDetails()
        {
            Console.WriteLine("Enter Student name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Entetr RollNo: ");
            RollNo = Convert.ToInt32(Console.ReadLine());
        }
        public string GetStdDetails()
        {
            string str = "Student name is: " + _Name + "  Roll No is: " + _RollNo;
            return str;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\IET\Desktop\DOT_NET\Assignment4_MySerialD\check.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            Student student = new Student();
            student.SetStdDetails();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, student);
            fs.Close();
            Console.WriteLine("file closed");

            FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read);
            Student s1 = bf.Deserialize(fs1) as Student;
            Console.WriteLine(s1.GetStdDetails());
            fs1.Close();
            Console.WriteLine("Done");
            Console.ReadLine();

        }
      
       
    }
}

soap seri,deseri- only change binary to soap.
xml-seri-
  ////Type type = customer.GetType();
////XmlSerializer xmlSerializer = new XmlSerializer(type);
//XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
//xmlSerializer.Serialize(fs, customer);

//fs.Close();
//Console.WriteLine("Done");

7]Reflection--

 namespace _19Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"D:\IETCDAC\CDACDemos\MyMath\bin\Debug\net6.0\MyMath.dll");
            Type [] allTypes = assembly.GetTypes();
            for (int i = 0; i < allTypes.Length; i++) 
            {
                Type type = allTypes[i];
                object DynamicallyCreatedObject = assembly.CreateInstance(type.FullName);
                MethodInfo [] allMethods = type.GetMethods();
                for (int j = 0; j < allMethods.Length; j++)
                {
                    MethodInfo method = allMethods[j];
                    Console.WriteLine("For {0}:", method.Name);
                    ParameterInfo[] parameters = method.GetParameters();
                    object[] inputValues = new object[parameters.Length];
                    for (int k = 0; k < parameters.Length; k++)
                    {
                        ParameterInfo para = parameters[k];
                        Console.WriteLine("Enter value for parameter {0} of Type {1}",
                                                    para.Name,para.ParameterType.ToString());
                        string ?inputs = Console.ReadLine();
                        inputValues[k] = Convert.ChangeType(inputs, para.ParameterType);
                    }

                    object ?result = type.InvokeMember(method.Name,
                                                     BindingFlags.Public |
                                                     BindingFlags.Instance |
                                                     BindingFlags.InvokeMethod,
                                                     null,
                                                     DynamicallyCreatedObject,
                                                     inputValues);
                    // new object[] { 10, 20 });
                    Console.WriteLine("Result of {0} is {1}", method.Name, result.ToString());
                }
                        
            }
        }
    }
}

8]Collection-
  1]Arraylist--ArrayList arr2 = new ArrayList();
            arr2.Add(emp1);
            arr2.Add(emp2);
            foreach (Emp e in arr2)
            {
                Console.WriteLine(e.Id);
                //Emp e = obj as Emp;
            }
            //add records dynamically .. 
            Console.WriteLine("Enter Id to be searched ..");
  2]Dictionary--  

//Dictionary<int,Emp> dt=new Dictionary<int, Emp>();
//  dt.Add(1, emp1);
//  dt.Add(2, emp2);
//      dt.Add(3, emp3);
//  foreach (int  key in dt.Keys)
//  {
//      Emp emp = dt[key];
//      Console.Write("Key = {0}",key);
//      Console.WriteLine(" -- Value {0}",emp.GetEmpDetails());
//  } 

  3]Dictionary--

Hashtable ht = new Hashtable();
ht.Add(1, 100);
ht.Add("abc", "something");
ht.Add("IT", emp1);
ht.Add("fictional", book1);
foreach (object key in ht.Keys)
{
    Console.WriteLine("Key = {0}, Value ={1}", key, ht[key]);
    if (ht[key] is Emp)
    {
        Emp emp = ht[key] as Emp;
        Console.WriteLine(emp.GetEmpDetails());
    }
}

9] C#features
  1]LINQ-LINQ - Lazy Loading of LINQ
            // //LINQ - Language Integrated Query 
            //// IEnumerable<T>
            ////Lazy Loading of LINQ
            //var filteredEmpCollection =  from emp in emps
            //                             where emp.Address.ToLower() == city.ToLower()
            //                             select emp;
            // emps.Add(new Emp() { No = 20, Name = "Nilesh", Address = "Pune" });

            // Console.WriteLine("----------------");
            // foreach (Emp filteredEmp in filteredEmpCollection)
            // {
            //     Console.WriteLine("No = {0}, Name ={1}, Address={2}",filteredEmp.No,
            //         filteredEmp.Name,filteredEmp.Address);
            // } 
  
