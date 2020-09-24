using System;
using System.Collections.Generic;
using System.Numerics;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {
            //key to use for encryption, This is the Industry standard 
            BigInteger ENCRYPTKEY = 65537;
            
            // initialize variables that are passed in via dot net run cons. List contains [pE,pC,qE,qC].  p= (2^pE)-pC
            // ciphertext to be decrypted  and plaintext to de encrypted with the secret Key via RSA 
            // Secret Key found via factors p & q this allows us to calculate the Eulers Totient (p-1)*(q-1)
            
            (List<int> variableList, BigInteger ciphertext, BigInteger plaintext, BigInteger p, BigInteger q) = Init.GetVariables(args);

           //create an instance of RSA class
            var rsa= new RSA(p, q, ENCRYPTKEY);
            
          //Encode and decode the plaintext and the ciphertext that was provided 
            var cipher = rsa.Encrypt(plaintext);
            var plain = rsa.Decrypt(ciphertext);

            Console.Write($"{plain.ToString()},");
            Console.Write($"{cipher.ToString()}");

        }
    }
}


