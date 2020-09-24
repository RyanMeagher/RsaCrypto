using System;
using System.Numerics;

namespace P4
{
    public class RSA
    {
        public BigInteger EncryptKey { get; }
        public BigInteger DecryptKey { get; }
        public BigInteger P { get; }
        public BigInteger Q { get; }
        public BigInteger EulersQuotient { get; }

        //public BigInteger gcd { get; }
        public BigInteger N { get; }

        public RSA(BigInteger p, BigInteger q, BigInteger encryptKey)
        {
            //constructor
            P = p;
            Q = q;
            N = BigInteger.Multiply(p, q);
            EulersQuotient = (q - 1) * (p - 1);
            EncryptKey = encryptKey;
            DecryptKey = ExtendedEucladian.ModInv(EncryptKey, EulersQuotient);
        }

        public BigInteger Encrypt(BigInteger plaintext)
        {
            //c = (m^e) modN
            BigInteger ciphertext = BigInteger.ModPow(plaintext, EncryptKey, N);
            return ciphertext;
        }

        public BigInteger Decrypt(BigInteger ciphertext)
        {
            // m = (c^d) modN
            var plaintext = BigInteger.ModPow(ciphertext, DecryptKey, N);
            return plaintext;
        }
    }
}