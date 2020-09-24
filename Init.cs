using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace P4
{
    public class Init
    {
        public static (List<int>, BigInteger, BigInteger, BigInteger, BigInteger) GetVariables(string[] args)
        {
            /* Paramaters to be passed via dotnet run are described below
              1) p_e in base 10
              2) p_c in base 10
              3) q_e in base 10
              4) q_c in base 10
              5) Ciphertext in base 10
              6) Plaintext message in base 10 */

            List<int> argsList = new List<int>();
            foreach (var arg in args[0..4])
            {
                argsList.Add(Convert.ToInt32(arg));
            }

            BigInteger ciphertext = BigInteger.Parse(args[4]);
            BigInteger plaintext = BigInteger.Parse(args[5]);
            (BigInteger p, BigInteger q) = ComputePrimeFactors(argsList[0], argsList[1], argsList[2], argsList[3]);
            
            return (argsList, ciphertext, plaintext, p, q);
        }
        public static (BigInteger, BigInteger) ComputePrimeFactors
            (BigInteger pE, BigInteger pC, BigInteger qE, BigInteger qC)
        {
            //Compute the primes 
            BigInteger p = BigInteger.Pow(2, (int) pE) - pC;
            BigInteger q = BigInteger.Pow(2, (int) qE) - qC;
            return (p, q);
        }
    }
}