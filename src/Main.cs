using System;
using System.Linq;

// Note: To enable JSON (JavaScriptSerializer) add following reference: System.Web.Extensions

class Program
{

    static void Main(string[] args)
    {
        int sel = 0;
        if (args != null && args.Count() > 0)
        {
            if (!Int32.TryParse(args[0], out sel))
            {
                sel = 0;
            }
        }
        switch (sel)
        {
            case 1:
                Console.WriteLine("PriceStreaming");
                PriceStreaming.PriceStreaming.Exec();
                break;
            case 2:
                Console.WriteLine("PricePolling");
                PricePolling.PricePolling.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 3:
                Console.WriteLine("PositionStreaming");
                PositionStreaming.PositionStreaming.Exec(); ;
                break;
            case 4:
                Console.WriteLine("PositionPolling");
                PositionPolling.PositionPolling.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 5:
                Console.WriteLine("OrderStreaming");
                OrderStreaming.OrderStreaming.Exec();
                break;
            case 6:
                Console.WriteLine("OrderPolling");
                OrderPolling.OrderPolling.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 7:
                Console.WriteLine("SetOrder");
                SetOrder.SetOrder.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 8:
                Console.WriteLine("ModifyOrder");
                ModifyOrder.ModifyOrder.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 9:
                Console.WriteLine("CancelOrder");
                CancelOrder.CancelOrder.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 10:
                Console.WriteLine("GetAccount");
                GetAccount.GetAccount.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 11:
                Console.WriteLine("GetInterface");
                GetInterface.GetInterface.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            case 12:
                Console.WriteLine("GetHistoricalPrice");
                GetHistoricalPrice.GetHistoricalPrice.Exec();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Choose option: ");
                Console.WriteLine(" 0: Exit");
                Console.WriteLine(" 1: PriceStreaming");
                Console.WriteLine(" 2: PricePolling");
                Console.WriteLine(" 3: PositionStreaming");
                Console.WriteLine(" 4: PositionPolling");
                Console.WriteLine(" 5: OrderStreaming");
                Console.WriteLine(" 6: OrderPolling");
                Console.WriteLine(" 7: SetOrder");
                Console.WriteLine(" 8: ModifyOrder");
                Console.WriteLine(" 9: CancelOrder");
                Console.WriteLine("10: GetAccount");
                Console.WriteLine("11: GetInterface");
                Console.WriteLine("12: GetHistoricalPrice");
                string input = Console.ReadLine();
                if (input.Equals("0"))
                {
                    Console.WriteLine("Exit");
                    return;
                }
                string[] newargs = new string[1];
                newargs[0] = input;
                Main(newargs);
                break;
        }
    }

}
