using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereEncode.Encryption
{
    public class TextHash : IDisposable
    {

        private string regex = "0123456789" + "abcdefghijklmnopqrstuvwxyz" + "abcdefghijklmnopqrstuvwxyz".ToUpper();
        private string regexASCII = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private string encWord;
        private string key;
        private string hashedWord;
        private int keyOriginalLength;


        // Disposeable
        bool is_disposed = false;

        public TextHash(string encWord, string key) {
        
            this.encWord = encWord;
            this.key = key;
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

        public string StartHashing()
        {

            HashText();
            return hashedWord;
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

                if (newPos < regex.Length - 1)
                {

                    sb.Append(regex[newPos]);
                }   else sb.Append(regex[newPos - (regex.Length - 1)]);
            }

            hashedWord = sb.ToString();
            Console.WriteLine(hashedWord);
            Console.ReadKey();
        }

        public string StartUnhashing()
        {
            UnhashText();
            return hashedWord;
        }

        private void UnhashText()
        {

            StringBuilder sb = new StringBuilder();
            int encWordPos, keyPos, newPos;

            for (int i = 0; i < encWord.Length; i++)
            {

                encWordPos = regex.IndexOf(encWord.ElementAt(i));
                keyPos = regex.IndexOf(key.ElementAt(i));

                newPos = encWordPos - keyPos + (regex.Length - 1);

                if (newPos < regex.Length - 1)
                {

                    sb.Append(regex[newPos]);
                }
                else sb.Append(regex[newPos - (regex.Length - 1)]);
            }

            hashedWord = sb.ToString();
        }

        public string StartHashingASCII()
        {
            HashTextASCII();
            return hashedWord;
        }

        private void HashTextASCII()
        {

            StringBuilder sb = new StringBuilder();
            int encWordPos, keyPos, newPos;

            for (int i = 0; i < encWord.Length; i++)
            {

                encWordPos = regexASCII.IndexOf(encWord.ElementAt(i));
                keyPos = regexASCII.IndexOf(key.ElementAt(i));

                newPos = encWordPos + keyPos;

                if (newPos < regexASCII.Length - 1)
                {

                    sb.Append(regexASCII[newPos]);
                }
                else sb.Append(regexASCII[newPos - regexASCII.Length]);
            }

            hashedWord = sb.ToString();
        }

        public string StartUnhashingASCII()
        {
            UnhashTextASCII();
            return hashedWord;
        }

        private void UnhashTextASCII()
        {

            StringBuilder sb = new StringBuilder();
            int encWordPos, keyPos, newPos;

            for (int i = 0; i < encWord.Length; i++)
            {

                encWordPos = regexASCII.IndexOf(encWord.ElementAt(i));
                keyPos = regexASCII.IndexOf(key.ElementAt(i));

                newPos = encWordPos - keyPos + (regexASCII.Length - 1);

                if (newPos < regexASCII.Length - 1)
                {

                    sb.Append(regexASCII[newPos]);
                }
                else sb.Append(regexASCII[newPos - (regexASCII.Length - 1)]);
            }

            hashedWord = sb.ToString();
        }
    }
}
