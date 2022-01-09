using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions == null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            Shift(source, directions, 0);
            return source;
        }

        private static void Shift(int[] source, Direction[] directions, int index)
        {
            if (index == directions.Length)
            {
                return;
            }

            Direction currentDirection = directions[index];

            if (currentDirection == Direction.Left)
            {
                int firstValue = source[0];
                for (int j = 0; j < source.Length - 1; j++)
                {
                    source[j] = source[j + 1];
                }

                source[^1] = firstValue;
            }
            else if (currentDirection == Direction.Right)
            {
                int lastValue = source[^1];
                for (int j = source.Length - 1; j > 0; j--)
                {
                    source[j] = source[j - 1];
                }

                source[0] = lastValue;
            }
            else
            {
                throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
            }

            Shift(source, directions, index + 1);
        }
    }
}
