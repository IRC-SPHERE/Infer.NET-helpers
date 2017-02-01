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

using MicrosoftResearch.Infer.Collections;

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
            return variables.Select(ia => ia.GetMeans()).ToArray();
        }

        public static double[][][] GetMeans<T>(this IEnumerable<IEnumerable<IEnumerable<T>>> variables)
            where T: CanGetMean<double>
        {
            return variables.Select(ia => ia.GetMeans()).ToArray();
        }

        public static double[][][][] GetMeans<T>(this IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>> variables)
            where T: CanGetMean<double>
        {
            return variables.Select(ia => ia.GetMeans()).ToArray();
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

        public static double[][][] GetPrecisions(this IEnumerable<IEnumerable<IEnumerable<Gaussian>>> variables)
        {
            return variables.Select(ia => ia.GetPrecisions()).ToArray();
        }

        public static double[][][][] GetPrecisions(this IEnumerable<IEnumerable<IEnumerable<IEnumerable<Gaussian>>>> variables)
        {
            return variables.Select(ia => ia.GetPrecisions()).ToArray();
        }

        public static PositiveDefiniteMatrix[] GetPrecisions(this IEnumerable<VectorGaussian> variables)
        {
            return variables.Select(ia => ia.Precision).ToArray();
        }

        public static Gaussian[] GetPointMassGaussians(this IEnumerable<double> values)
        {
            return values.Select(Gaussian.PointMass).ToArray();
        }

        public static Gaussian[][] GetPointMassGaussians(this IEnumerable<IEnumerable<double>> values)
        {
            return values.Select(ia => ia.GetPointMassGaussians()).ToArray();
        }

        public static Gamma[] GetPointMassGammas(this IEnumerable<double> values)
        {
            return values.Select(Gamma.PointMass).ToArray();
        }

        public static Gamma[][] GetPointMassGammas(this IEnumerable<IEnumerable<double>> values)
        {
            return values.Select(ia => ia.GetPointMassGammas()).ToArray();
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

        /// <summary>
        /// Scales the Gaussian.
        /// </summary>
        /// <returns>The scaled Gaussian.</returns>
        /// <param name="gaussian">The Gaussian.</param>
        /// <param name="scale">The scaling factor.</param>
        public static Gaussian Scale(this Gaussian gaussian, double scale)
        {
            double mean = gaussian.GetMean() / scale;
            double variance = Math.Pow(Math.Sqrt(gaussian.GetVariance()) / scale, 2);
            return Gaussian.FromMeanAndVariance(mean, variance);
        }

        /// <summary>
        /// L2 Norm of the Gaussian array (means).
        /// </summary>
        /// <returns>The L2 norm.</returns>
        /// <param name="array">array.</param>
        public static double L2Norm(this Gaussian[] array)
        {
            var means = array.GetMeans();
            double norm = means.Sum(x => x * x);
            return norm;
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
                double norm = array[i].L2Norm();

                // Rescaling from Theorem 4.3 of https://www.probabilitycourse.com/chapter4/4_2_3_normal.php
                arrayNormalised[i] = array[i].Select(g => g.Scale(norm)).ToArray();
            }

            return arrayNormalised;
        }

        /// <summary>
        /// Gets the approximate sparsity.
        /// </summary>
        /// <param name="gaussians">The Gaussian array.</param>
        /// <param name="threshold">The threshold.</param>
        public static double GetSparsity(this Gaussian[] gaussians, double threshold)
        {
            return DistributionHelpers.GetSparsity(gaussians, threshold);
        }

        /// <summary>
        /// Gets the approximate sparsity.
        /// </summary>
        /// <param name="gaussians">The Gaussian array.</param>
        /// <param name="threshold">The threshold.</param>
        public static double[] GetSparsity(this Gaussian[][] gaussians, double threshold)
        {
            return DistributionHelpers.GetSparsity(gaussians, threshold);
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[] Copy(this Gaussian[] array)
        {
            return DistributionHelpers.Copy(array);
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[][] Copy(this Gaussian[][] array)
        {
            return DistributionHelpers.Copy(array);
        }

        /// <summary>
        /// Copies the vector gaussian array.
        /// </summary>
        /// <returns>The vector gaussian array copy.</returns>
        public static VectorGaussian[] Copy(this VectorGaussian[] array)
        {
            return DistributionHelpers.Copy(array);
        }

        /// <summary>
        /// Copies the gamma array.
        /// </summary>
        /// <returns>The gamma array copy.</returns>
        public static Gamma[] Copy(this Gamma[] array)
        {
            return DistributionHelpers.Copy(array);
        }

        /// <summary>
        /// Copies the gamma array.
        /// </summary>
        /// <returns>The gamma array copy.</returns>
        public static Gamma[][] Copy(this Gamma[][] array)
        {
            return DistributionHelpers.Copy(array);
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[,] Copy(this Gaussian[,] array)
        {
            return DistributionHelpers.Copy(array);
        }

        public static void Print(this Gaussian[] array, int max = int.MaxValue)
        {
            // Console.WriteLine(string.Join(", ", array.Take(max).Select(ia => $"[{ia.GetMean():N4}, {ia.GetVariance():N4}]")));
            Console.WriteLine(string.Join(", ", array.Take(max).Select(ia => ia.ToString())));
        }

        public static void Print(this Gamma[] array, int max = int.MaxValue)
        {
            // Console.WriteLine(string.Join(", ", array.Take(max).Select(ia => $"[{ia.Shape:N4}, {ia.Rate:N4}]")));
            Console.WriteLine(string.Join(", ", array.Take(max).Select(ia => ia.ToString())));
        }

        public static void Print(this Discrete[] array, int max = int.MaxValue)
        {
            Console.WriteLine(string.Join(", ", array.Take(max).Select(ia => ia.ToString())));
        }

        public static void Print(this IEnumerable<Gaussian[]> array, int maxRows = int.MaxValue, int maxCols = int.MaxValue)
        {
            array.Take(maxRows).ForEach(ia => ia.Print(maxCols));
        }

        public static void Print(this IEnumerable<Gamma[]> array, int maxRows = int.MaxValue, int maxCols = int.MaxValue)
        {
            array.Take(maxRows).ForEach(ia => ia.Print(maxCols));
        }

        /// <summary>
        /// Transposes the specified 2D array.
        /// </summary>
        /// <typeparam name="T">
        /// The array type.
        /// </typeparam>
        /// <param name="array2D">
        /// The array2D.
        /// </param>
        /// <returns>
        /// The transposed array.
        /// </returns>
        public static T[,] Transpose<T>(this T[,] array2D)
        {
            if (array2D == null)
            {
                return null;
            }

            int rows = array2D.GetLength(0);
            int cols = array2D.GetLength(1);
            var transposed = new T[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = array2D[i, j];
                }
            }

            return transposed;
        }

        /// <summary>
        /// Transposes the specified jagged array.
        /// </summary>
        /// <typeparam name="T">
        /// The array type.
        /// </typeparam>
        /// <param name="array">
        /// The jagged array.
        /// </param>
        /// <returns>
        /// The transposed array.
        /// </returns>
        public static T[][] Transpose<T>(this T[][] array)
        {
            if (array == null)
            {
                return null;
            }

            // NOTE: Assumes that this array is in fact a 2D array (i.e. not actually jagged)

            int rows = array.Length;
            int cols = array[0].Length;
            var transposed = new T[cols][];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                        transposed[j] = new T[rows];

                    transposed[j][i] = array[i][j];
                }
            }

            return transposed;
        }
    }
}

