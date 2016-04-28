//
// Extensions.cs
//
// Author:
//       Tom Diethe <tom.diethe@bristol.ac.uk>
//
// Copyright (c) 2016 University of Bristol
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace InferHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MicrosoftResearch.Infer.Distributions;
    using MicrosoftResearch.Infer.Maths;

    public static class Extensions
    {
        /// <summary>
        /// Gets the log probability of truth.
        /// </summary>
        /// <param name="variables">
        /// The variables.
        /// </param>
        /// <param name="truth">
        /// The truth.
        /// </param>
        /// <returns>
        /// The log probabilities.
        /// </returns>
        public static double[] GetLogProbabilityOfTruth(this IList<Bernoulli> variables, IList<bool> truth)
        {
            if (variables == null || truth == null)
            {
                return null;
            }

            if (variables.Count != truth.Count)
            {
                throw new ArgumentException("variables and truth should be the same length");
            }

            return variables.Select((ia, i) => ia.GetLogProb(truth[i])).ToArray();
        }

        /// <summary>
        /// Gets the log probability of truth.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <param name="truth">
        /// The truth.
        /// </param>
        /// <returns>
        /// The log probabilities.
        /// </returns>
        public static double[][] GetLogProbabilityOfTruth(this Bernoulli[][] jaggedArray, bool[][] truth)
        {
            if (jaggedArray == null || truth == null)
            {
                return null;
            }

            if (jaggedArray.Length != truth.Length)
            {
                throw new ArgumentException("variables and truth should be the same length");
            }

            return jaggedArray.Select((inner, i) => inner.GetLogProbabilityOfTruth(truth[i])).ToArray();
        }

        /// <summary>
        /// Gets the means.
        /// </summary>
        /// <param name="variables">
        /// The variables.
        /// </param>
        /// <returns>
        /// The means
        /// </returns>
        public static double[] GetMeans(this IEnumerable<Bernoulli> variables)
        {
            return variables.Select(ia => ia.GetMean()).ToArray();
        }

        /// <summary>
        /// Gets the means.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <returns>
        /// The means.
        /// </returns>
        public static double[][] GetMeans(this IEnumerable<IEnumerable<Bernoulli>> jaggedArray)
        {
            return jaggedArray.Select(inner => inner.GetMeans()).ToArray();
        }

        /// <summary>
        /// Gets the means.
        /// </summary>
        /// <param name="variables">
        /// The variables.
        /// </param>
        /// <returns>
        /// The means.
        /// </returns>
        public static double[] GetMeans(this IEnumerable<Beta> variables)
        {
            return variables.Select(ia => ia.GetMean()).ToArray();
        }

        /// <summary>
        /// Gets the means.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <returns>
        /// The means.
        /// </returns>
        public static double[][] GetMeans(this IEnumerable<IEnumerable<Beta>> jaggedArray)
        {
            return jaggedArray.Select(inner => inner.GetMeans()).ToArray();
        }

        public static double[] GetMeans<T>(this IEnumerable<T> variables)
            where T: CanGetMean<double>
        {
            return variables.Select(ia => ia.GetMean()).ToArray();
        }

        public static double[][] GetMeans<T>(this IEnumerable<IEnumerable<T>> variables)
            where T: CanGetMean<double>
        {
            return variables.Select(ia => ia.GetMeans<T>()).ToArray();
        }

        public static Vector[] GetMeans(this IEnumerable<VectorGaussian> variables)
        {
            return variables.Select(ia => ia.GetMean()).ToArray();
        }

        public static double[] GetVariances<T>(this IEnumerable<T> variables)
            where T: CanGetVariance<double>
        {
            return variables.Select(ia => ia.GetVariance()).ToArray();
        }

        public static double[][] GetVariances<T>(this IEnumerable<IEnumerable<T>> variables)
            where T: CanGetVariance<double>
        {
            return variables.Select(ia => ia.GetVariances<T>()).ToArray();
        }

        public static double[] GetStandardDeviations<T>(this IEnumerable<T> variables)
            where T: CanGetVariance<double>
        {
            return variables.Select(ia => Math.Sqrt(ia.GetVariance())).ToArray();
        }

        public static double[][] GetStandardDeviations<T>(this IEnumerable<IEnumerable<T>> variables)
            where T: CanGetVariance<double>
        {
            return variables.Select(ia => ia.GetStandardDeviations<T>()).ToArray();
        }

        public static double[] GetPrecisions(this IEnumerable<Gaussian> variables)
        {
            return variables.Select(ia => ia.Precision).ToArray();
        }

        public static double[][] GetPrecisions(this IEnumerable<IEnumerable<Gaussian>> variables)
        {
            return variables.Select(ia => ia.GetPrecisions()).ToArray();
        }

        public static PositiveDefiniteMatrix[] GetPrecisions(this IEnumerable<VectorGaussian> variables)
        {
            return variables.Select(ia => ia.Precision).ToArray();
        }

        /// <summary>
        /// Gets the plus minus sigma.
        /// </summary>
        /// <returns>The plus minus sigma.</returns>
        /// <param name="gaussian">The Gaussian.</param>
        public static double[] GetPlusMinusSigma(this Gaussian gaussian)
        {
            return new[] { gaussian.GetMean() - Math.Sqrt(gaussian.GetVariance()), gaussian.GetMean() + Math.Sqrt(gaussian.GetVariance()) };
        }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        /// <typeparam name="T">
        /// The array type.
        /// </typeparam>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <returns>
        /// The number of columns.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// jagged Array
        /// </exception>
        public static int NumberOfColumns<T>(this IEnumerable<T[]> jaggedArray)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            return jaggedArray.Max(row => row.Length);
        }

        /// <summary>
        /// Converts jagged array to 2D array, using default(T) for missing values
        /// </summary>
        /// <typeparam name="T">
        /// The type of the jagged array
        /// </typeparam>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <returns>
        /// The 2D array
        /// </returns>
        public static T[,] To2D<T>(this T[][] jaggedArray)
        {
            if (jaggedArray == null)
            {
                return null;
            }

            int cols = jaggedArray.NumberOfColumns();

            var darray = new T[jaggedArray.Length, cols];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j < jaggedArray[i].Length)
                    {
                        darray[i, j] = jaggedArray[i][j];
                    }
                    else
                    {
                        darray[i, j] = default(T);
                    }
                }
            }

            return darray;
        }

        /// <summary>
        /// Convert from 2D array to jagged array.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the 2D array
        /// </typeparam>
        /// <param name="matrix">
        /// The 2D array.
        /// </param>
        /// <returns>
        /// The jagged array
        /// </returns>
        public static T[][] ToJagged<T>(this T[,] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            var darray = new T[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                darray[i] = new T[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    darray[i][j] = matrix[i, j];
                }
            }

            return darray;
        }

        public static Gaussian Scale(this Gaussian gaussian, double scale)
        {
            double mean = gaussian.GetMean() / scale;
            double variance = Math.Pow(Math.Sqrt(gaussian.GetVariance()) / scale, 2);
            return Gaussian.FromMeanAndVariance(mean, variance);
        }

        /// <summary>
        /// Normalises the array.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="array">array.</param>
        public static Gaussian[][] Normalise(this Gaussian[][] array)
        {
            var arrayNormalised = new Gaussian[array.Length][];
            for (var i = 0; i < array.Length; i++)
            {
                // Compute norm of row
                var means = array[i].GetMeans();
                double norm = means.Sum(x => x * x);

                // Rescaling from Theorem 4.3 of https://www.probabilitycourse.com/chapter4/4_2_3_normal.php
                arrayNormalised[i] = array[i].Select(g => g.Scale(norm)).ToArray();
            }

            return arrayNormalised;
        }
    }
}

