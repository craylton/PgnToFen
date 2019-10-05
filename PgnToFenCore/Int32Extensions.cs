namespace PgnToFen
{
    public static class Int32Extensions
    {
        public static int Modulo(this int number, int divisor) =>
            ((number % divisor) + divisor) % divisor;
    }
}
