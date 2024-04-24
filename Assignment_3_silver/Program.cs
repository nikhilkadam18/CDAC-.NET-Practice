namespace Silver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1.Silver, 2.Golde,3.Platinum ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                IPrime prime = new Silver();
                prime.Amazon();
            }
            else if (choice == 2)
            {
                IPrimeAmazon prime1 = new Gold();
                prime1.Amazon();
                prime1.AmazonPrime();
                
            }
            else if (choice == 3)
            {
                ISuperPrime prime2 = new Platinum();

                prime2.Amazon();
                prime2.AmazonPrime();
                prime2.FreeDelivery();
                
               
            }
            else
            {
                Console.WriteLine("ENter valid choice ");
            }
        }
    }
    public interface IPrime
    {
        public void Amazon();

    }
    public interface IPrimeAmazon : IPrime
    {
     
        public void AmazonPrime();
    }
    public interface ISuperPrime : IPrimeAmazon
    {
       
        public void FreeDelivery();
        
       
    }

    public class Silver() : IPrime
    {
        public void Amazon()
        {
            Console.WriteLine(" Regular Services + ");
        }
    }
    public class Gold() : IPrime, IPrimeAmazon
    {
        public void Amazon()
        {
            Console.WriteLine(" Regular Services");
        }
        public void AmazonPrime()
        {
            Console.WriteLine("  Two User Access ");
        }
        
    }
    public class Platinum : IPrime, IPrimeAmazon, ISuperPrime
    {
        public void Amazon()
        {
            Console.WriteLine(" Regular Services");
        }
        public void AmazonPrime()
        {
            Console.WriteLine("  Two User Access ");
        }
        public void FreeDelivery()
        {
            Console.WriteLine(" Free Delivery...!");
        }
        
    }
}
