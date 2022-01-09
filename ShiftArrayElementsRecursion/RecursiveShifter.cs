using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            Shift(source, iterations, 0);
            return source;
        }

        private static void Shift(int[] source, int[] iterations, int index)
        {
            if (index == iterations.Length)
            {
                return;
            }

            for (int j = 0; j < iterations[index]; j++)
            {
                if (index % 2 == 0)
                {
                    int tmp = source[0];
                    Array.Copy(source, 1, source, 0, source.Length - 1);
                    source[^1] = tmp;
                }
                else
                {
                    int tmp = source[^1];
                    Array.Copy(source, 0, source, 1, source.Length - 1);
                    source[0] = tmp;
                }
            }

            Shift(source, iterations, index + 1);
        }
    }
}
