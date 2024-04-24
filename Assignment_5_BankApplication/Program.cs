using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string [] arr=new  string[10]; 
            const int Pin = 0000;
            int choice;
            double withdrawammount;
            double depositeammount;
            double balance=20000;
            double checkbalance;
            Console.WriteLine("Enter Passward ");
            int pass = Convert.ToInt32(Console.ReadLine());
            
            if (Pin == pass)

            {
                do {
                    Console.WriteLine("1.deposite_ammount , 2. withdrawamount, 3. CHeck balance, 4.mini statement");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(" Enter amount for deposite:  ");
                            depositeammount = Convert.ToDouble(Console.ReadLine());
                            balance = balance + depositeammount;
                            arr[count++] = "deposite rs ==>>" +Convert.ToString(depositeammount);
                            Console.WriteLine(" after deposite balance amount is : " + balance);
                            break;
                           

                        case 2:
                            Console.WriteLine("Enter Ammount for withdrawl : ");
                            withdrawammount = Convert.ToDouble(Console.ReadLine());
                            if (withdrawammount < balance)
                            {
                                balance = balance - withdrawammount;
                                arr[count++] ="withdraw rs ==>>"+ Convert.ToString(withdrawammount);
                                Console.WriteLine("Successfully Withraw amount {0}", withdrawammount,"Rs");
                                Console.WriteLine("Remaining Balance is : " + balance);
                            }
                            else
                                Console.WriteLine("Insufficient balance ");
                                break;

                        case 3: Console.WriteLine("Your Account Balance is : " + balance);
                                break;

                        case 4:
                                 Console.WriteLine("nikhil");
                                 for (int i=count;i>=count-5;i--)
                               {
                                if(i<0)
                                {
                                    break;
                                }
                                Console.WriteLine(arr[i]);
                               }
                            break;

                        

                        
                    }
                }while(choice != 0);

                Console.ReadLine();

            }

        }


    }

   
}
