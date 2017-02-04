using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Amethyst
{
    /// <summary>
    /// Utility class for multiple purposes
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Serialization Utility
        /// </summary>
        public class Serialization
        {
            /// <summary>
            /// Serialize an object into an XML file
            /// </summary>
            /// <param name="obj">The object to serialize</param>
            /// <param name="fileName">The name of the file were the XML will be saved</param>
            /// <returns>true if succeed, false if an error occurs</returns>
            public static bool ToXML(object obj, string fileName)
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(obj.GetType());
                    StreamWriter w = new StreamWriter(fileName);
                    s.Serialize(w, obj);
                    w.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("An error occured during ToXML(...)");
                    System.Diagnostics.Debug.Print(ex.Message);
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Deserialize en XML file into an object
            /// </summary>
            /// <typeparam name="T">The type of the deserialized object</typeparam>
            /// <param name="fileName">The name of the file that contains the XML representation of the object</param>
            /// <returns>The deserialized object if succeed, the default value for type T if an error occurs</returns>
            public static T FromXML<T>(string fileName)
            {
                T obj = default(T);
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    FileStream f = new FileStream(fileName, FileMode.Open);
                    obj = (T)s.Deserialize(f);
                    f.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("An error occured during FromXML<"+typeof(T).Name+">(...)");
                    System.Diagnostics.Debug.Print(ex.Message);
                    return default(T);
                }
                return obj;
            }
        }

        /// <summary>
        /// Encryption Utility
        /// </summary>
        public class Encryption
        {
            /// <summary>
            /// Encrypt a string using SHA1-RC2-128bits
            /// </summary>
            /// <param name="plainText">The string to encrypt</param>
            /// <param name="pass">The secret password used for encryption</param>
            /// <returns>The encrypted text</returns>
            public static string Encrypt(string plainText, string pass)
            {
                string result = string.Empty;

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider()
                {
                    IV = new byte[8]
                };
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(pass, new byte[0]);

                des.Key = pdb.CryptDeriveKey("RC2", "SHA1", 128, new byte[8]);

                using (MemoryStream ms = new MemoryStream(plainText.Length * 2))
                {
                    using (CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        encStream.Write(plainBytes, 0, plainBytes.Length);
                        encStream.FlushFinalBlock();
                        byte[] encryptedBytes = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(encryptedBytes, 0, (int)ms.Length);
                        encStream.Close();
                        ms.Close();
                        result = Convert.ToBase64String(encryptedBytes);
                    }
                }
                return result;
            }

            /// <summary>
            /// Decrypt a string using SHA1-RC2-128bits
            /// </summary>
            /// <param name="cryptedText">The string to decrypt</param>
            /// <param name="pass">The secret password that was used for encryption</param>
            /// <returns>The decrypted text</returns>
            public static string Decrypt(string cryptedText, string pass)
            {
                string result = string.Empty;

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider()
                {
                    IV = new byte[8]
                };
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(pass, new byte[0]);
                des.Key = pdb.CryptDeriveKey("RC2", "SHA1", 128, new byte[8]);
                byte[] encryptedBytes = Convert.FromBase64String(cryptedText);

                using (MemoryStream ms = new MemoryStream(cryptedText.Length))
                {
                    using (CryptoStream decStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        decStream.FlushFinalBlock();
                        byte[] plainBytes = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(plainBytes, 0, (int)ms.Length);
                        result = Encoding.UTF8.GetString(plainBytes);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Arrays Utility
        /// </summary>
        public class Arrays
        {
            /// <summary>
            /// Resize a 2-dimensionnal array
            /// </summary>
            /// <typeparam name="T">The type of the array</typeparam>
            /// <param name="original">The original array</param>
            /// <param name="newDim1Size">The new 1st dimension's size</param>
            /// <param name="newDim2Size">The new 2nd dimension's size</param>
            /// <param name="pos1">The offset for 1st dimension</param>
            /// <param name="pos2">The offset for 2nd dimension</param>
            /// <returns>The new resized array</returns>
            public static T[,] ResizeArray<T>(T[,] original, int newDim1Size, int newDim2Size, int pos1 = 0, int pos2 = 0)
            {
                T[,] newT = new T[newDim1Size, newDim2Size];

                int end1 = System.Math.Min(newDim1Size, original.GetLength(0) - pos1);
                int end2 = System.Math.Min(newDim2Size, original.GetLength(1) - pos2);

                for (int x = pos1; x < end1; ++x)
                {
                    for (int y = pos2; y < end2; ++y)
                    {
                        newT[x, y] = original[x - pos1, y - pos2];
                    }
                }

                return newT;
            }
        }
    }
}
