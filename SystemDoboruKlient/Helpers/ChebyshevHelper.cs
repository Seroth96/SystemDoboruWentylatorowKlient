using System;

namespace SystemDoboruKlient.Helpers
{
    public static class ChebyshevHelper
    {
        private static double T0(double x)
        {
            return 1.0;
        }

        // n = 1
        private static double T1(double x)
        {
            return x;
        }

        // n = 2
        private static double T2(double x)
        {
            return (2.0 * x * x) - 1.0;
        }

        /*
        *	Tn(x)
        */
        public static double Tn(uint n, double x)
        {
            if (n == 0)
            {
                return T0(x);
            }
            else if (n == 1)
            {
                return T1(x);
            }
            else if (n == 2)
            {
                return T2(x);
            }
            return (2.0 * x * Tn(n - 1, x)) - Tn(n - 2, x);
        }

        public static double EvaluateFunctionFromCoefficients(double[] C, double u)
        {
            double sum = 0;
            for (uint i = 0; i < C.Length; i++)
            {
                sum += C[i] * Tn(i, u);
            }
            return sum;
        }

        public static double Normalize(double a, double b, double x)
        {
            return ((2 * x) - a - b) / (b - a);
        }
    }
}