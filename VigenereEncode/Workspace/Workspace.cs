using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigenereEncode.Encryption;
using VigenereEncode.Utilities;

namespace VigenereEncode.Workspace
{
    public class Wspc
    {

        private string encWord;
        private string key;
        private Util util = new Util();

        public Wspc() {

            Console.WriteLine(util.options.ElementAt(0));
            encWord = Console.ReadLine();

            if (encWord.Length == 0) {

                while(encWord.Length == 0) {

                    Console.WriteLine(util.exceptions.ElementAt(0));
                    encWord = Console.ReadLine();
                }
            
            }
            Console.WriteLine(util.options.ElementAt(1));
            key = Console.ReadLine();

            if (key.Length == 0)
            {

                while (key.Length == 0)
                {

                    Console.WriteLine(util.exceptions.ElementAt(1));
                    key = Console.ReadLine();
                }

            }

            using (TextHash ENC = new TextHash(encWord, key))
            {

            }
        }

    }

}
