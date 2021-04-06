using System;
using System.Collections.Generic;
using System.Text;

namespace Events2
{
    class FireMen
    {
        private TownWithEvents MyNativeTown;
        public FireMen(TownWithEvents twe)
        {
            this.MyNativeTown = twe;
            MyNativeTown.fireEvent += new FireEvent(FireHandler);
        }
        private void FireHandler(int day,int buildings)
        {
            string message = "В городе {0} произошел пожар!" 
                + "В день {1}, в доме №{2} " 
                + "Пожар потушен!";
            Console.WriteLine(string.Format(message, MyNativeTown.TownName, day, buildings));
        }
        public void GoOut()
        {
            MyNativeTown.fireEvent -= new FireEvent(FireHandler);
        }
    }
}
