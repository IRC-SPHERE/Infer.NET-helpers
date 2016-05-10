//
// MyClass.cs
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
    using System.Linq;
    using MicrosoftResearch.Infer.Distributions;
    using MicrosoftResearch.Infer.Maths;

    /// <summary>
    /// Distribution helpers.
    /// </summary>
    public class DistributionHelpers
    {
        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        public static Gaussian[][] CreateUniformGaussians(int first, int second)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    t => Gaussian.Uniform()).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        public static Gaussian[][][] CreateUniformGaussians(int first, int second, int third)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Enumerable.Range(0, third).Select(
                        t => Gaussian.Uniform()).ToArray()).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="count">Count.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[] CreateGaussianArray(int count, double mean, double variance)
        {
            return Enumerable.Range(0, count).Select(ia => Gaussian.FromMeanAndVariance(mean, variance)).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="count">Count.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[] CreateGaussianArray(int count, double mean, Func<double> variance)
        {
            return Enumerable.Range(0, count).Select(ia => Gaussian.FromMeanAndVariance(mean, variance())).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="count">Count.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[] CreateGaussianArray(int count, Func<double> mean, double variance)
        {
            return Enumerable.Range(0, count).Select(ia => Gaussian.FromMeanAndVariance(mean(), variance)).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="count">Count.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[] CreateGaussianArray(int count, Func<double> mean, Func<double> variance)
        {
            return Enumerable.Range(0, count).Select(ia => Gaussian.FromMeanAndVariance(mean(), variance())).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][] CreateGaussianArray(int first, int second, double mean, double variance)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Gaussian.FromMeanAndVariance(mean, variance)).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][] CreateGaussianArray(int first, int second, double mean, Func<double> variance)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Gaussian.FromMeanAndVariance(mean, variance())).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][] CreateGaussianArray(int first, int second, Func<double> mean, double variance)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Gaussian.FromMeanAndVariance(mean(), variance)).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][] CreateGaussianArray(int first, int second, Func<double> mean, Func<double> variance)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Gaussian.FromMeanAndVariance(mean(), variance())).ToArray()).ToArray();
        }

        /// <summary>
        /// Creates the vector gaussian array.
        /// </summary>
        /// <returns>The vector gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static VectorGaussian[] CreateVectorGaussianArray(int first, int second, double mean, double variance)
        {
            return Enumerable.Range(0, first).Select(
                f => VectorGaussian.FromMeanAndVariance(
                    Vector.FromArray(Enumerable.Repeat(mean, second).ToArray()),
                    PositiveDefiniteMatrix.IdentityScaledBy(second, variance)
                )
            ).ToArray();
        }

        /// <summary>
        /// Creates the vector gaussian array.
        /// </summary>
        /// <returns>The vector gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static VectorGaussian[] CreateVectorGaussianArray(int first, int second, Func<double> mean, double variance)
        {
            return Enumerable.Range(0, first).Select(
                f => VectorGaussian.FromMeanAndVariance(
                    Vector.FromArray(Enumerable.Range(0, second).Select(s => mean()).ToArray()),
                    PositiveDefiniteMatrix.IdentityScaledBy(second, variance)
                )
            ).ToArray();
        }

        /// <summary>
        /// Creates the gamma array.
        /// </summary>
        /// <returns>The gamma array.</returns>
        /// <param name="count">Count.</param>
        /// <param name="shape">Shape.</param>
        /// <param name="rate">Rate.</param>
        public static Gamma[] CreateGammaArray(int count, double shape, double rate)
        {
            return Enumerable.Range(0, count).Select(ia => Gamma.FromShapeAndRate(shape, rate)).ToArray();
        }

        /// <summary>
        /// Creates the gamma array.
        /// </summary>
        /// <returns>The gamma array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="shape">Shape.</param>
        /// <param name="rate">Rate.</param>
        public static Gamma[][] CreateGammaArray(int first, int second, double shape, double rate)
        {
            return Enumerable.Range(0, first).Select(
                f => Enumerable.Range(0, second).Select(
                    s => Gamma.FromShapeAndRate(shape, rate)).ToArray()).ToArray();
        }

        /// <summary>
        /// Gets the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="matrix">Matrix.</param>
        public static Gaussian[][] GetGaussianArray(double[][] matrix)
        {
            return matrix?.Select(ia => ia.Select(Gaussian.PointMass).ToArray()).ToArray();
        }

        /// <summary>
        /// Gets the vector gaussian array.
        /// </summary>
        /// <returns>The vector gaussian array.</returns>
        /// <param name="matrix">Matrix.</param>
        public static VectorGaussian[] GetVectorGaussianArray(double[][] matrix)
        {
            return matrix?.Select(ia => VectorGaussian.PointMass(Vector.FromArray(ia))).ToArray();
        }

        /// <summary>
        /// Independent (diagonal) approximation of the vector Gaussian.
        /// </summary>
        /// <returns>The approximation.</returns>
        /// <param name="variable">Variable.</param>
        public static Gaussian[] IndependentApproximation(VectorGaussian variable)
        {
            var means = variable.GetMean().ToArray();
            var precs = variable.Precision.Diagonal().ToArray();
            return means.Zip(precs, Gaussian.FromMeanAndPrecision).ToArray();
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[] Copy(Gaussian[] array)
        {
            return array?.Select(ia => new Gaussian(ia)).ToArray();
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[][] Copy(Gaussian[][] array)
        {
            return array?.Select(Copy).ToArray();
        }

        /// <summary>
        /// Copies the gamma array.
        /// </summary>
        /// <returns>The gamma array copy.</returns>
        public static Gamma[] Copy(Gamma[] array)
        {
            return array?.Select(ia => new Gamma(ia)).ToArray();
        }

        /// <summary>
        /// Copies the gamma array.
        /// </summary>
        /// <returns>The gamma array copy.</returns>
        public static Gamma[][] Copy(Gamma[][] array)
        {
            return array?.Select(Copy).ToArray();
        }

        /// <summary>
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[,] Copy(Gaussian[,] array)
        {
            if (array == null)
            {
                return null;
            }

            var copy = new Gaussian[array.GetLength(0), array.GetLength(1)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    copy[i, j] = new Gaussian(array[i, j]);
                }
            }

            return copy;
        }

        /// <summary>
        /// Maximum difference between Gaussian arrays according to function f
        /// </summary>
        public static double MaxDiff(Gaussian[] a, Gaussian[] b, Func<Gaussian, Gaussian, double> f)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                throw new InvalidOperationException("Both arrays should be non null and same length");
            }

            return a.Zip(b, f).Max();
        }

        /// <summary>
        /// Maximum difference between Gaussian arrays according to function f
        /// </summary>
        public static double MaxDiff(Gaussian[][] a, Gaussian[][] b, Func<Gaussian, Gaussian, double> f)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                throw new InvalidOperationException("Both arrays should be non null and same length");
            }

            return a.Zip(b, (ia, ib) => MaxDiff(ia, ib, f)).Max();
        }

        /// <summary>
        /// Maximum difference between Gaussian arrays according to function f
        /// </summary>
        public static double MaxDiff(Gaussian[,] a, Gaussian[,] b, Func<Gaussian, Gaussian, double> f)
        {
            return MaxDiff(a.ToJagged(), b.ToJagged(), f);
        }
    }
}

