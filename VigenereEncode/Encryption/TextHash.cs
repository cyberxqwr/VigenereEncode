using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereEncode.Encryption
{
    public class TextHash : IDisposable
    {

        private string regex = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž".ToUpper();
        private string encWord;
        private string key;
        private string hashedWord;
        private int keyOriginalLength;


        // Disposeable
        bool is_disposed = false;

        public TextHash(string encWord, string key) {
        
            this.encWord = encWord.ToUpper();
            this.key = key.ToUpper();
            keyOriginalLength = key.Length - 1;
            RegulateKey();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.is_disposed = true;
        }

        private void RegulateKey()
        {

            if (encWord.Length > key.Length)
            {

                StringBuilder sb = new StringBuilder();

                int counter = 0;

                for (int i = 0; i < encWord.Length; i++)
                {

                    if (counter != keyOriginalLength)
                    {
                        sb.Append(key[counter]);
                        counter++;
                    }   else
                    {
                        sb.Append(key[counter]);
                        counter = 0;
                    }
                }

                key = sb.ToString();

                Console.WriteLine(key);
                Console.ReadKey();
            }   else
            {

                key = key.Substring(0, encWord.Length);
            }
        }

        public void StartHashing()
        {

            HashText();
        }

        private void HashText()
        {

            StringBuilder sb = new StringBuilder();
            int encWordPos, keyPos, newPos;

            for (int i = 0; i < encWord.Length; i++)
            {

                encWordPos = regex.IndexOf(encWord.ElementAt(i));
                keyPos = regex.IndexOf(key.ElementAt(i));

                newPos = encWordPos + keyPos;

                if (newPos < regex.Length)
                {

                    sb.Append(regex[newPos]);
                }   else sb.Append(regex[newPos - regex.Length]);
            }

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }




}
