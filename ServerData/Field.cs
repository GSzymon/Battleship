using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerData
{
    public class Field
    {
        private char x; //1,2,3,4,5,6,7,8,9
        private char y; //a,b,c,d,e,f,g,h,i
        private char who; // A,B
        public string str;

        public Field(string label)
        {
            who = label[0];
            x = label[2];
            y = label[3];
            str = label;
        }
    }
}
