// <copyright file="BasicCodingTasks.cs" company="LearningCompany">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace L108BasicCoding
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main L108BasicCoding class.
    /// Contains all methods for tasks in module Basic Coding.
    /// </summary>
    public class BasicCodingTasks
    {
        /// <summary>
        /// Method for insertNumber algorithm.
        /// </summary>
        /// <param name="numberSource">number where change bits</param>
        /// <param name="numberIn">number with bits for change</param>
        /// <param name="i">position one in numberSource</param>
        /// <param name="j">position two in numberSource</param>
        /// <returns>Returns the number with replaced bits.</returns>
        public int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            int bitStatus;
            int difference = j - i;

            // traverse through bits to insert
            for (int a = 0; a <= difference; a++)
            {
                // check whether bit is 1 or 0 in numberIn
                bitStatus = (numberIn >> a) & 1;

                // make bit as in numberIn in numberSource
                numberSource = this.SetOrClearBit(bitStatus, numberSource, a + i);
            }

            return numberSource;
        }

        /// <summary>
        /// Method for find  max from numbers using recursion algorithm.
        /// </summary>
        /// <param name="i">set i as 0</param>
        /// <param name="a">array where find maximum</param>
        /// <param name="n">length of array where find maximum</param>
        /// <param name="maximum">found maximum in array</param>
        /// <returns>Returns the maximum in A array.</returns>
        public int FindMax(int i, int[] a, int n, int maximum)
        {
            // go until last number
            if (i == n - 1)
            {
                if (a[i] > maximum)
                {
                    return a[i];
                }
                else
                {
                    return maximum;
                }
            }

            if (a[i] > maximum)
            {
                maximum = a[i];
            }

            return this.FindMax(i + 1, a, n, maximum);
        }

        /// <summary>
        /// Method for get position of number where left and rights sides' sums are equal.
        /// </summary>
        /// <param name="a">array to find this position</param>
        /// <returns>Returns the position of number where left and rights sides' sums are equal.</returns>
        public int GetNumberRightAndLeftEqual(int[] a)
        {
            // traverse through all array
            for (int i = 0; i < a.Length; i++)
            {
                // find sum of numbers on the left
                int sumLeft = 0;
                for (int j = 0; j < i; j++)
                {
                    sumLeft += a[j];
                }

                Console.WriteLine(sumLeft);

                // find sum of numbers on the right
                int sumRight = 0;
                for (int j = i + 1; j < a.Length; j++)
                {
                    sumRight += a[j];
                }

                // if sums are equal return position
                if (sumLeft == sumRight)
                {
                    return i;
                }
            }

            return 1;
        }

        /// <summary>
        /// Method to concatenate two string. If there are duplicate chars remove them.
        /// </summary>
        /// <param name="a">string one to concatenate</param>
        /// <param name="b">string two to concatenate</param>
        /// <returns>Returns the concatenated string without duplicates</returns>
        public string ConcatenateWithoutDuplicates(string a, string b)
        {
            string newString = string.Empty;

            // add to strings
            string stringForCheck = a + b;

            // remove dublicates
            for (int i = 0; i < stringForCheck.Length; i++)
            {
                if (!newString.Contains(stringForCheck[i]))
                {
                    newString += stringForCheck[i];
                }
            }

            return newString;
        }

        /// <summary>
        /// Method for finding next bigger number from same digits.
        /// </summary>
        /// <param name="n">number to which we need find next bigger number</param>
        /// <param name="elapseMs">out parameter to check time</param>
        /// <returns>Returns the next bigger number from same digits.</returns>
        public int FindNextNumber(int n, out long elapseMs)
        {
            // begin timer
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            int i, j;

            // convert number to array of digits
            var charArrayOfDigits = n.ToString().ToCharArray();
            int[] arrayOfDigits = Array.ConvertAll(charArrayOfDigits, c => (int)char.GetNumericValue(c));

            // find digit when this digit is bigger than digit on the right
            // traverse in back order
            for (i = arrayOfDigits.Length - 1; i > 0; i--)
            {
                if (arrayOfDigits[i] > arrayOfDigits[i - 1])
                {
                    break;
                }
            }

            elapseMs = watch.ElapsedMilliseconds;

            // there is no bigger number from same digits in this case
            if (i == 0)
            {
                return -1;
            }

            int x = arrayOfDigits[i - 1], smallestLoc = i;
            Console.WriteLine(x);

            // find the smallest number on the right from position we found earlier
            for (j = i + 1; j < arrayOfDigits.Length; j++)
            {
                if (arrayOfDigits[j] > x &&
                    arrayOfDigits[j] < arrayOfDigits[smallestLoc])
                {
                    smallestLoc = j;
                }
            }

            Console.WriteLine(smallestLoc);
            int temp;
            temp = arrayOfDigits[i - 1];
            arrayOfDigits[i - 1] = arrayOfDigits[smallestLoc];
            arrayOfDigits[smallestLoc] = temp;

            // sort on numbers on right from position i
            for (int m = i; m < arrayOfDigits.Length; m++)
            {
                for (int k = m + 1; k < arrayOfDigits.Length; k++)
                {
                    if (arrayOfDigits[m] > arrayOfDigits[k])
                    {
                        temp = arrayOfDigits[m];
                        arrayOfDigits[m] = arrayOfDigits[k];
                        arrayOfDigits[k] = temp;
                    }
                }
            }

            Console.WriteLine(arrayOfDigits);

            // convert back array of digits to number
            int value = 0;
            for (i = 0; i < arrayOfDigits.Length; ++i)
            {
                value += arrayOfDigits[i] * (int)Math.Pow(10, arrayOfDigits.Length - i - 1);
            }

            // the code that you want to measure comes here
            watch.Stop();
            elapseMs = watch.ElapsedMilliseconds;
            return value;
        }

        /// <summary>
        /// Method for filtering array to get only numbers with seven digit.
        /// </summary>
        /// <param name="digits">array of digits to filter</param>
        /// <returns>Returns the filtered array with digits containing 7.</returns>
        public int[] FilterDigit(int[] digits)
        {
            List<int> digitsWithSeven = new List<int>();
            foreach (int d in digits)
            {
                // convert number to array of digits
                int[] arrayOfDigits = Array.ConvertAll(d.ToString().ToCharArray(), c => (int)char.GetNumericValue(c));
                
                // check whether number contains 7 one by one digit
                int include = 0;
                for (int i = 0; i < arrayOfDigits.Length; i++)
                {
                    if (arrayOfDigits[i] == 7)
                    {
                        include = 1;
                        break;
                    }
                }

                // if number contains 7 digit, then add it to filtered list
                if (include == 1)
                {
                    digitsWithSeven.Add(d);
                }
            }

            return digitsWithSeven.ToArray();
        }

        /// <summary>
        /// auxiliary function to set one bit to 1 or 0 in number
        /// </summary>
        /// <param name="oneOrZero">set bit to one or zero</param>
        /// <param name="number">number in which we want to set bit</param>
        /// <param name="bitPosition">position in number where we want change bit</param>
        /// <returns>Returns the number with replaced bit.</returns>
        private int SetOrClearBit(int oneOrZero, int number, int bitPosition)
        {
            if (oneOrZero == 1)
            {
                // set bit as 1
                number |= 1 << bitPosition;
            }
            else
            {
                // to set bit as 0
                number &= ~(1 << bitPosition);
            }

            return number;
        }
    }
}