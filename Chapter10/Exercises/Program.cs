using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {

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
