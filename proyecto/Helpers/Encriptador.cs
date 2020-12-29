using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace proyecto.Helpers
{
    public class Encriptador
    {
        Encriptador3DES _encriptador3DES = new Encriptador3DES();
        EncriptadorAES _encriptadorAES = new EncriptadorAES();
        public string TextoPlano { get; set; }
        public string TextoEncriptado { get; set; }

        public string DesencriptarCadenaConexion(string cadenaConexion)
        {
            string cadena = _encriptador3DES.Desencriptar(cadenaConexion);

            return cadena;
        }
        public string DesencriptarValorFront(string valor)
        {
            string valorDesencriptado = _encriptadorAES.Desencriptar(valor);

            return valorDesencriptado;
        }
    }
    public class Encriptador3DES
    {
        private string key32 = "[6bg#d1sa%y5ui/4pb=cxawf8bsFs+z";

        public string Desencriptar(string input)
        {
            try
            {
                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(input);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key32));
                    hashmd5.Clear();
                }
                else
                {
                    keyArray = UTF8Encoding.UTF8.GetBytes(key32);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class EncriptadorAES
    {
        private const string CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyz0123456789";
        private readonly int iterations = 100;
        private byte[] Salt = new byte[16];
        private byte[] IV = new byte[16];
        string passwordAES32 = "[6bg#d1sa%y5ui/4pb=cxawf8bsFs+z";
        //string passwordAES32 = "añpuet12$dh12dskh23456lsÑsa!2'S";

        private void GetKey(String _IV, String _Salt)
        {
            IV = ConvertHexToString(_IV);
            Salt = ConvertHexToString(_Salt);
        }
        public EncriptadorAES()
        {
            IV = Generatekey(16);
            Salt = Generatekey(16);
        }
        private static byte[] FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
        private byte[] ConvertHexToString(String hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return bytes;
        }
        private static string ConvertStringToHex(byte[] encoding)
        {
            StringBuilder sbBytes = new StringBuilder(encoding.Length * 2);
            foreach (byte b in encoding)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        private byte[] CreateKey(string password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
                return rfc2898DeriveBytes.GetBytes(32);
        }
        private byte[] Generatekey(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }
            return Encoding.ASCII.GetBytes(bytes.Select(x => CaracteresPermitidos[x % CaracteresPermitidos.Length]).ToArray());
        }
        public string Encriptar(string input)
        {
            byte[] encrypted;
            byte[] Key = CreateKey(passwordAES32, Salt);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return ConvertStringToHex(Salt) + ConvertStringToHex(IV) + Convert.ToBase64String(encrypted);
        }
        public string Desencriptar(string input)
        {
            string plaintext = null;
            try
            {
                byte[] Encoded = new byte[input.Length - Salt.Length - IV.Length];
                GetKey(input.Substring(32, 32), input.Substring(0, 32));
                Encoded = Convert.FromBase64String(input.Substring(64));

                byte[] Key = CreateKey(passwordAES32, Salt);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new MemoryStream(Encoded))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}