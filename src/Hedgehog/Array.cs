namespace Hedgehog
{
    public static class Array
    {

        public static void Insert<T>(this T[] array, T[] value, int index)
        {
            int offset = 0;
            foreach (var item in value)
            {
                array[index + offset] = item;
                offset += 1;
            }
        }

    }
}
