using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptor.AES
{
    internal class rijndaelManaged
    {
        public static void Encrypt(string inputFile, string outputFile, byte[] passwordBytes, int keysize, int blocksize, byte[] saltbytes)
        {
            try
            {
                byte[] saltBytes = saltbytes;
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged _AES = new RijndaelManaged();

                _AES.KeySize = keysize;
                _AES.BlockSize = blocksize;


                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                _AES.Key = key.GetBytes(_AES.KeySize / 8);
                _AES.IV = key.GetBytes(_AES.BlockSize / 8);
                _AES.Padding = PaddingMode.Zeros;

                _AES.Mode = CipherMode.CBC;

                CryptoStream cs = new CryptoStream(fsCrypt,
                     _AES.CreateEncryptor(),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        public static void Decrypt(string inputFile, string outputFile, byte[] passwordBytes, int keysize, int blocksize, byte[] saltbytes)
        {
            try
            {
                byte[] saltBytes = saltbytes;
                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged AES = new RijndaelManaged();

                AES.KeySize = keysize;
                AES.BlockSize = blocksize;


                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Padding = PaddingMode.Zeros;

                AES.Mode = CipherMode.CBC;

                CryptoStream cs = new CryptoStream(fsCrypt,
                    AES.CreateDecryptor(),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                {
                    fsOut.WriteByte((byte)data);
                }

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
    }
}
