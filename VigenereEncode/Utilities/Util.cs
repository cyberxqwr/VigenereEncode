using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereEncode.Utilities
{
    public class Util
    {

        public List<string> options = new List<string>();
        public List<string> exceptions = new List<string>();

        public Util()
        {

            options.Add("Įveskite pradinį tekstą:");
            options.Add("Įveskite raktą:");

            exceptions.Add("Klaida. Neįvestas tekstas. Įveskite jį vėl.");
            exceptions.Add("Klaida. Neįvestas raktas. Įveskite jį vėl.");
        }
    }
}
