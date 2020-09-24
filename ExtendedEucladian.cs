using System;
using System.Numerics;

namespace P4
{
    public static class ExtendedEucladian
    {
        // Returns the greatest common denominator between 2 numbers
        //If they are co-prime they will return 1 as gcd.
        public static (BigInteger, BigInteger, BigInteger) Compute(BigInteger a, BigInteger b)
        {
            //variables to be returned that satisfy the equation a*x + b*y = d
            // return format (int d, int x, int y)
            //  has a runtime of o(log(n)^2)

            if (b == 0)
            {
                return (a, 1, 0);
            }

            // make sure that the arguments passed are in the form of a>=b
            if (b > a)
            {
                (b, a) = (a, b);
            }

            // initialize variables
            (BigInteger x1, BigInteger x2, BigInteger y1, BigInteger y2) = (0, 1, 1, 0);
            while (b > 0)
            {
                var quotient = a / b;
                var rem = a - quotient * b;
                var x = x2 - quotient * x1;
                var y = y2 - quotient * y1;

                (a, b, x2, x1, y2, y1) = (b, rem, x1, x, y1, y);
            }

            var gcd = a;

            return (gcd, x2, y2);
        }

        public static BigInteger ModInv(BigInteger e, BigInteger phi)
        {
            // This is used to find the encryption key for RSA
            // Use this to solve this equation given (e*d) mod(phi(N)) = 1
            // Given the Encryption Key (e), The Industry standard is 65537 and phi(N).
            // phi(N) is calculated (p-1)(q-1) where p and q are 1024 bits.  

            BigInteger t1 = 0, tNew = 1, r = phi, rNew = e;

            while (rNew != 0)
            {
                var quot = r / rNew;

                var temp = tNew;
                tNew = t1 - quot * tNew;
                t1 = temp;
                temp = rNew;
                rNew = r - quot * rNew;
                r = temp;
            }

            if (t1 < 0) t1 = t1 + phi;
            return t1;
        }
    }
}