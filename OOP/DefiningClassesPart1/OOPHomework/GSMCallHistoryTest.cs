namespace OOPHomework
{
    using System;

    public class GSMCallHistoryTest
    {
        const decimal pricePerMinute = 0.37m;

        public static void GsmCallHistoryTest()
        {
            GSM gsm = GSM.IPhone4s;
            gsm.Owner = "Telerik";

            gsm.AddCall(new Call(new DateTime(2014, 1, 31, 12, 24, 12), "0888888888", 61));
            gsm.AddCall(new Call(new DateTime(2014, 1, 31, 2, 12, 03), "0999999999", 161));
            gsm.AddCall(new Call(new DateTime(2014, 1, 31, 18, 59, 41), "0777777777", 261));

            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 20));
            }

            decimal totalPrice = gsm.CalculateTotalPrice(pricePerMinute);

            Console.WriteLine("Total price: {0}", totalPrice);

            Call longestCall = new Call(new DateTime(), string.Empty, 0);

            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                if (gsm.CallHistory[i].Duration > longestCall.Duration)
                {
                    longestCall = gsm.CallHistory[i];
                }
            }

            gsm.DeleteCall(longestCall);

            totalPrice = gsm.CalculateTotalPrice(pricePerMinute);

            Console.WriteLine("Total price: {0}", totalPrice);

            gsm.ClearCallHistory();

            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
