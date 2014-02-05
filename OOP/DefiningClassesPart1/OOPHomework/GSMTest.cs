namespace OOPHomework
{
    using System;
    using System.Collections.Generic;

    public class GSMTest
    {
        public static void GsmTest()
        {
            List<GSM> listOfGSMs = new List<GSM>()
            {
                new GSM("Sofia", "70015D", 250, "Telerik", "batteryModel-4", BatteryType.NiCd, 1, 0, 265, 621, 2),
                new GSM("Varna", "50146D", 2500, "Telerik", "batteryModel-5", BatteryType.NiMH, 10, 5, 126, 984, 1592),
                new GSM("Plovdiv", "5022669SD", 500, "Telerik", new Battery("M-2000", BatteryType.LiIon, 240, 100), new Display(1920, 1080, 16000000))            //Nice display size uh? :D
            };

            foreach (var gsm in listOfGSMs)
            {
                Console.Write(gsm);
                Console.WriteLine(new string('-', 20));
            }

            Console.WriteLine(GSM.IPhone4s);
        }
    }
}
