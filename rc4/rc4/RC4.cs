using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace rc4
{
    public class RC4
    {

        public byte[] text;
        private byte[] S = new byte[256];

        private int i = 0;
        private int j = 0;
        private void swap(byte[] array, int ind1, int ind2)
        {
            byte temp = array[ind1];
            array[ind1] = array[ind2];
            array[ind2] = temp;
        }

        public void init(byte[] key)
        {
            for (i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            j = 0;
            for (i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % key.Length]) % 256;
                swap(S, i, j);
            }
            i = j = 0;
        }

        public byte kword()
        {
            i = (i + 1) % 256;
            j = (j + S[i]) % 256;
            swap(S, i, j);
            byte K = S[(S[i] + S[j]) % 256];
            return K;
        }

        public byte[] code()
        {
            byte[] data = text.Take(text.Length).ToArray();
            byte[] res = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                res[i] = (byte)(data[i] ^ kword());
            }
            return res;
        }

        public void WriteByteArrayToFile(Byte[] buffer, string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                for (int i = 0; i < buffer.Length; i++)
                    bw.Write(buffer[i]);

                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Byte[] ReadByteArrayFromFile(string fileName)
        {
            Byte[] buffer = null;

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                long numBytes = new FileInfo(fileName).Length;
                buffer = br.ReadBytes((int)numBytes);

                br.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return buffer;
        }
    }
}
