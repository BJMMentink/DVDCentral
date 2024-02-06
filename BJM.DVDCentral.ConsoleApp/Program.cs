using BJM.DVDCentral.ConsoleApp;
using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static string DrawMenu()
    {
        Console.WriteLine("Which operation would you like to perform?");
        Console.WriteLine("Connect to a Channel (c)");
        Console.WriteLine("Send a message to a channel (s)");
        Console.WriteLine("Exit (x)");

        string operation = Console.ReadLine();
        return operation;

    }
    private static void Main(string[] args)
    {
        string user = "Ben";
        string hubAddress = "https://fvtcdp.azurewebsites.net/GameHub";
        string operation = DrawMenu();

        var signalRConnection = new SignalRConnection(hubAddress);

        while (operation != "x")
        {
            switch (operation)
            {
                case "c":
                    signalRConnection.Connect(user);
                    break;
                case "s":
                    break;
                case "x":
                    break;

            }
            operation = DrawMenu();
        }
    }
}