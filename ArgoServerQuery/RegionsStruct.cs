using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgoServerQuery
{
    class RegionsStruct
    {
        public struct regions
        {
            private static readonly List<string> EU_SET = new List<string>()
            {
                "149.202.151.92:27060",
                "149.202.151.92:27062",
                "149.202.151.92:27064",
                "149.202.151.92:27066",
                "149.202.151.92:27068",
                "149.202.151.92:27070",
                "149.202.151.92:27072",
                "149.202.151.92:27074",
                "149.202.151.92:27076"
            };

            private static readonly List<string> NA_SET = new List<string>()
            {
                "104.206.97.211:27060",
                "104.206.97.211:27062",
                "104.206.97.211:27064",
                "104.206.97.211:27066",
                "104.206.97.211:27068",
                "104.206.97.211:27070",
                "104.206.97.211:27072",
                "104.206.97.211:27074"
            };

            private static readonly List<string> AU_SET = new List<string>()
            {
                "43.245.161.54:27104",
                "43.245.161.54:27106"
            };

            public static List<string> EU { get; } = EU_SET;
            public static List<string> NA { get; } = NA_SET;
            public static List<string> AU { get; } = AU_SET;
        }
    } 
}
