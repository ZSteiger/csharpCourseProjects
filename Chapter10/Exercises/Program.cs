using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using static System.Console;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            RijndaelManaged key = null;
            try
            {
                // Create a new key
                key = new RijndaelManaged();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("customers.xml");

                // encrypt the creditcard element
                Encrypt(xmlDoc, "creditcard", key);
                WriteLine("The element was encrypted");
                WriteLine(xmlDoc.InnerXml);
                Decrypt(xmlDoc, key);
                WriteLine("The element was decrypted");
                WriteLine(xmlDoc.InnerXml);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                // clear the key
                if (key != null)
                {
                    key.Clear();
                }
            }
        }
        public static void Encrypt(XmlDocument Doc, string ElementName, SymmetricAlgorithm Key)
        {
            // Check the arguments
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementName == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (Key == null)
                throw new ArgumentNullException("Alg");

            // find the specified element in the XmlDocument object and create a a new xmlElement object
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementName)[0] as XmlElement;
            // Throw an XmlException if the element was not found
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");
            }
            // create a new instance of EncryptedXml class and use it to encrypt the XmlElement with the symmetric key
            EncryptedXml eXml = new EncryptedXml();

            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, Key, false);

            // construct the EncryptedData object and populate it with desired encryption information
            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;

            // Create an EncryptionMethod element so that the receiver knows which algorithm to use for decryption. Determind what kind of algorithm is being used and supply the appropriate URL to the EncryptionMethod element

            string encryptionMethod = null;

            if (Key is TripleDES)
            {
                encryptionMethod = EncryptedXml.XmlEncTripleDESUrl;
            }
            else if (Key is DES)
            {
                encryptionMethod = EncryptedXml.XmlEncDESUrl;
            }
            if (Key is Rijndael)
            {
                switch (Key.KeySize)
                {
                    case 128:
                        encryptionMethod = EncryptedXml.XmlEncAES128Url;
                        break;
                    case 198:
                        encryptionMethod = EncryptedXml.XmlEncAES192Url;
                        break;
                    case 256:
                        encryptionMethod = EncryptedXml.XmlEncAES256Url;
                        break;
                }
            }
            else
            {
                // throw an exception if the transform is not in the previous categories
                throw new CryptographicException("The specified algorithm is not supported for XML Encryption");
            }
            edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);

            // add the encrypted element data to the EncryptedData object
            edElement.CipherData.CipherValue = encryptedElement;

            // Replace the element from the original XmlDocument object with the EncryptedData element
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

        }

        public static void Decrypt(XmlDocument Doc, SymmetricAlgorithm Alg)
        {
            // check the arguments
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            // find the EncryptedData element in the XmlDocument
            XmlElement encryptedElement = Doc.GetElementsByTagName("EncryptedData")[0] as XmlElement;
            // if the EncryptedData element was not found, throw an exception
            if (encryptedElement == null)
            {
                throw new XmlException("The EncryptedData element was not found");
            }

            // create an EncryptedData object and populate it
            EncryptedData edElement = new EncryptedData();
            edElement.LoadXml(encryptedElement);

            // create a new EncryptedXml object
            EncryptedXml exml = new EncryptedXml();
            // decrypt the element using the symmetric key
            byte[] rgbOutput = exml.DecryptData(edElement, Alg);

            // replace the encryptedData element with plaintext XML element
            exml.ReplaceData(encryptedElement, rgbOutput);
        }
    }
}

/* ------ Exercise01 ------
1. Of the encryption algorithms provided by .NET, which is the best choice for symmetric encryption? A: Advanced Encryption System, or AES
2. Of the encryption algorithms provided by .NET, which is the best choice for asymmetric encryption? A: RSA (Rivest–Shamir–Adleman)
3. What is a rainbow attack? A: A rainbow table is a large set of pre-computed hashes of available strings. Much faster than a brute force attack, it'll compare and reduce the strings until the final password is recognized
4. For encryption algorithms, is it better to have a larger or smaller block size? A: Larger block sizes have greater security, but have reduced speed, 64-bit was common but now 128 is more the norm with algorithms such as AES
5. What is a hash? A: A one-way encryption of a string
6. What is a signature? A: A technique used to ensure the data you received is from someone you trust, usually by validating a signature applied to the data against someone's public key.
7. What is the difference between symmetric and asymmetric encryption? A: Symmetric encryption is where you have a single key that can encrypt and decrypt. Asymmetric is where you could have a public facing encryption key, but to decrypt you would need a private key.
8. What does RSA stand for? A: Rivest-Shamir-Adleman
9. Why should passwords be salted before being stored? A: Because otherwise your hash is simply a conversion from string -> encrypted string, meaning "123456" hashed is the same across all devices. Adding a salt ensures an extra layer of security, generating different hashes for the same password.
10. SHA1 is a hashing algorithm designed by the United States National Security Agency. Why should you never use it? A: "SHA1 and other hash algorithms generate a digital fingerprint that in theory is unique for each different file or text input they sign. When the underlying plaintext is altered in even miniscule ways, the signature changes. The algorithms are used cryptographically to prove that no unauthorized changes have been made to websites or software code. Collision attacks undermine this assurance by allowing attackers to forge the cryptographic signatures provided by the algorithm."
 */
