using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Helpers
{
    public class CommonHelper
    {
        // high included!!!
       public static int GetRandom(int low, int high)
        {
            int rand = 0;
            Random random = new Random();
            rand = random.Next(low, high);
            return rand;
        }
    }
}