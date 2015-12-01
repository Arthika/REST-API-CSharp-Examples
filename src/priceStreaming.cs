using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Web.Script.Serialization;

// Note: To enable JSON (JavaScriptSerializer) add following reference: System.Web.Extensions

namespace priceStreaming
{
    public class hftRequest
    {
        public getPriceRequest  getPrice { get; set; }
    }

    public class hftResponse
    {
        public getPriceResponse getPriceResponse { get; set; }
    }

    public class getPriceRequest
    {
        public string        user { get; set; }
        public string        token { get; set; }
        public List<string>  security { get; set; }
        public List<string>  tinterface { get; set; }
    }

    public class getPriceResponse
    {
        public int              result { get; set; }
        public string           message { get; set; }
        public List<priceTick>  tick { get; set; }
        public priceHeartbeat   heartbeat { get; set; }
        public string           timestamp { get; set; }
    }

    public class priceTick
    {
        public string  security { get; set; }
        public string  tinterface { get; set; }
        public double  price { get; set; }
        public int     pips { get; set; }
        public int     liquidity { get; set; }
        public string  side { get; set; }
    }

    public class priceHeartbeat
    {
        public List<string>  security { get; set; }
        public List<string>  tinterface { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------
            // STEP 1 : Prepare and send a price request
            // -----------------------------------------

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://demo.arthikatrading.com:81/cgi-bin/IHFTRestStreamer/getPrice");
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                hftRequest request = new hftRequest();

                request.getPrice            = new getPriceRequest();
                request.getPrice.user       = "demo";
                request.getPrice.token      = "927814C103AAF349D435659059BCCEAD9A91C8E9";
                request.getPrice.security   = new List<string> { "EUR_USD", "GBP_USD" };
                request.getPrice.tinterface = new List<string> { "TI1" };

                streamWriter.WriteLine(serializer.Serialize(request));
            }

            // --------------------------------------------------------------
            // STEP 2 : Wait for continuous responses from server (streaming)
            // --------------------------------------------------------------

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                hftResponse response;

                try
                {
                    while (true)
                    {
                        response = serializer.Deserialize<hftResponse>(streamReader.ReadLine());

                        if (response.getPriceResponse.timestamp != null)
                        {
                            Console.WriteLine("Response timestamp: " + response.getPriceResponse.timestamp + " Contents:");
                        }
                        if (response.getPriceResponse.tick != null)
                        {
                            foreach (priceTick tick in response.getPriceResponse.tick)
                            {
                                Console.WriteLine("Security: " + tick.security + " Price: " + tick.price + " Side: " + tick.side + " Liquidity: " + tick.liquidity);
                            }
                        }
                        if (response.getPriceResponse.heartbeat != null)
                        {
                            Console.WriteLine("Heartbeat!");
                        }
                        if (response.getPriceResponse.message != null)
                        {
                            Console.WriteLine("Message from server: " + response.getPriceResponse.message);
                        }
                    }
                }
                catch (SocketException ex) { Console.WriteLine(ex.Message); }
                catch (IOException ioex) { Console.WriteLine(ioex.Message);}
            }
        }
    }
}
