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
        private string encWord;
        private string key;
        private string hashedWord;
        private int keyOriginalLength;
        private char e, k;


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

            for (int i = 0; i < encWord.Length; i++)
            {

                e = encWord.ElementAt(i);
                k = key.ElementAt(i);

                if (e > 31 && e < 128)
                {

                    k = (char)((int)k - 32);
                    e = (char)(e - 32 + k);
                    sb.Append((char)(e % 95 + 32));
                }
                else sb.Append(e);
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

            for (int i = 0; i < encWord.Length; i++)
            {

                e = encWord.ElementAt(i);
                k = key.ElementAt(i);

                if (e > 31 && e < 128)
                {

                    k = (char)((int)k - 32);
                    e = (char)(e - 32 + (95 - k));
                    sb.Append((char)(e % 95 + 32));
                }
                else sb.Append(e);
            }

            hashedWord = sb.ToString();
        }
    }
}