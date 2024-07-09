using System.Reflection.Metadata;

class Program
{

    public interface IMessageSender
    {
        string SendMessage();
    }

    public class GoodMessage : IMessageSender
    {
        public string SendMessage()
        {
            return "You're looking very handsome today.";
        }
    }

    public class BadMessage : IMessageSender
    {
        public string SendMessage()
        {
            return "You're looking very ugly today.";
        }
    }
    public class ConsoleMessageReader
    {

        public string ReadMessage(IMessageSender sender)
        {
            return sender.SendMessage();
        }
    }

    static void Main(string[] args)
    {
        var messageReader = new ConsoleMessageReader();
       
        while (true)
        {
            Console.WriteLine("What type of message would you like? Good or Bad?");
            var userInput = Console.ReadLine().ToLower();
            string returnMessage = "";

            while (true)
            {
                if (userInput == "good")
                {
                    IMessageSender goodMessage = new GoodMessage();
                    returnMessage = messageReader.ReadMessage(goodMessage);
                    Console.WriteLine(returnMessage);
                    break;
                }
                else if (userInput == "bad")
                {
                    IMessageSender badMessage = new BadMessage();
                    returnMessage = messageReader.ReadMessage(badMessage);
                    Console.WriteLine(returnMessage);
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect command, please type 'Good' or 'Bad'.");
                    userInput = Console.ReadLine().ToLower();
                }
            }

            Console.WriteLine("Want another?");
            var continueInput = Console.ReadLine().ToLower();
            if (continueInput != "yes")
            {
                break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}