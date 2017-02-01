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

using System.Collections.Generic;
using System.Reflection;

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
        public static Gaussian[] CreateUniformGaussians(int first)
        {
            return Enumerable.Range(0, first).Select(t => Gaussian.Uniform()).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        public static Gaussian[][] CreateUniformGaussians(int first, int second)
        {
            return Enumerable.Range(0, first).Select(
                f => CreateUniformGaussians(second)).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        public static Gaussian[][] CreateUniformGaussians(int first, int[] second)
        {
            return Enumerable.Range(0, first).Select(
                (f, i) => CreateUniformGaussians(second[i])).ToArray();
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
                f => CreateUniformGaussians(second, third)).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        public static Gaussian[][][] CreateUniformGaussians(int first, int second, int[] third)
        {
            return Enumerable.Range(0, first).Select(
                f => CreateUniformGaussians(second, third)).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="fourth">Fourth.</param>
        public static Gaussian[][][][] CreateUniformGaussians(int first, int second, int third, int fourth)
        {
            return Enumerable.Range(0, first).Select(
                f => CreateUniformGaussians(second, third, fourth)).ToArray();
        }

        /// <summary>
        /// Creates the uniform gaussians.
        /// </summary>
        /// <returns>The uniform gaussians.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="fourth">Fourth.</param>
        public static Gaussian[][][][] CreateUniformGaussians(int first, int second, int third, int[] fourth)
        {
            return Enumerable.Range(0, first).Select(
                f => CreateUniformGaussians(second, third, fourth)).ToArray();
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
            return CreateGaussianArray(count, () => mean, () => variance);
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
            return CreateGaussianArray(count, () => mean, variance);
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
            return CreateGaussianArray(count, mean, () => variance);
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
            return Enumerable.Range(0, first).Select(f => CreateGaussianArray(second, mean, variance)).ToArray();
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
            return CreateGaussianArray(first, second, () => mean, variance);
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
            return CreateGaussianArray(first, second, mean, () => variance);
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
            return Enumerable.Range(0, first).Select(f => CreateGaussianArray(second, mean(), variance())).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][] CreateGaussianArray(int first, int[] second, Func<double> mean,
            Func<double> variance)
        {
            return Enumerable.Range(0, first)
                .Select((f, i) => CreateGaussianArray(second[i], mean(), variance()))
                .ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][][] CreateGaussianArray(int first, int second, int third, Func<double> mean,
            Func<double> variance)
        {
            return Enumerable.Range(0, first).Select(f => CreateGaussianArray(second, third, mean, variance)).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][][] CreateGaussianArray(int first, int second, int[] third, Func<double> mean,
            Func<double> variance)
        {
            return Enumerable.Range(0, first).Select(f => CreateGaussianArray(second, third, mean, variance)).ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="fourth">Fourth.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][][][] CreateGaussianArray(int first, int second, int third, int fourth,
            Func<double> mean, Func<double> variance)
        {
            return Enumerable.Range(0, first)
                .Select(f => CreateGaussianArray(second, third, fourth, mean, variance))
                .ToArray();
        }

        /// <summary>
        /// Creates the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="fourth">Fourth.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static Gaussian[][][][] CreateGaussianArray(int first, int second, int third, int[] fourth,
            Func<double> mean, Func<double> variance)
        {
            return Enumerable.Range(0, first)
                .Select(f => CreateGaussianArray(second, third, fourth, mean, variance))
                .ToArray();
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
            return CreateVectorGaussianArray(first, second, () => mean, variance);
        }

        /// <summary>
        /// Creates the vector gaussian array.
        /// </summary>
        /// <returns>The vector gaussian array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="mean">Mean.</param>
        /// <param name="variance">Variance.</param>
        public static VectorGaussian[] CreateVectorGaussianArray(int first, int second, Func<double> mean,
            double variance)
        {
            return Enumerable.Range(0, first)
                .Select(
                    f => VectorGaussian.FromMeanAndVariance(
                        Vector.FromArray(Enumerable.Range(0, second).Select(s => mean()).ToArray()),
                        PositiveDefiniteMatrix.IdentityScaledBy(second, variance)
                    )
                )
                .ToArray();
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
        /// <param name="count">Count.</param>
        /// <param name="gamma">The distribution to clone.</param>
        public static Gamma[] CreateGammaArray(int count, Gamma gamma)
        {
            return Enumerable.Repeat((Gamma)gamma.Clone(), count).ToArray();
        }

        /// <summary>
        /// Creates the gamma array.
        /// </summary>
        /// <returns>The gamma array.</returns>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="gamma">The distribution to clone.</param>
        public static Gamma[][] CreateGammaArray(int first, int second, Gamma gamma)
        {
            return Enumerable.Repeat(CreateGammaArray(second, gamma), first).ToArray();
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
        /// Gets the gaussian array.
        /// </summary>
        /// <returns>The gaussian array.</returns>
        /// <param name="matrices">Matrices.</param>
        public static Gaussian[][][] GetGaussianArray(double[][][] matrices)
        {
            return matrices?.Select(GetGaussianArray).ToArray();
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
        /// Copies the vector gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static VectorGaussian[] Copy(VectorGaussian[] array)
        {
            return array?.Select(ia => new VectorGaussian(ia)).ToArray();
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
        /// Copies the gaussian array.
        /// </summary>
        /// <returns>The gaussian array copy.</returns>
        public static Gaussian[][][] Copy(Gaussian[][][] array)
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
        /// Copy the distribution array.
        /// </summary>
        /// <typeparam name="TDistribution">The type of the distribution.</typeparam>
        /// <param name="arrayToCopy">The array to copy.</param>
        /// <returns>
        /// The <see cref="DistributionStructArray{TDistribution, Double}" />.
        /// </returns>
        public static DistributionStructArray<TDistribution, double> Copy<TDistribution>(
            IEnumerable<TDistribution> arrayToCopy)
            where TDistribution : struct, IDistribution<double>, SettableToProduct<TDistribution>,
            SettableToRatio<TDistribution>,
            SettableToPower<TDistribution>, SettableToWeightedSum<TDistribution>, CanGetLogAverageOf<TDistribution>,
            CanGetLogAverageOfPower<TDistribution>, CanGetAverageLog<TDistribution>, Sampleable<double>
        {
            return (DistributionStructArray<TDistribution, double>) Distribution<double>.Array(arrayToCopy.ToArray());
        }

        /// <summary>
        /// Copy the distribution array.
        /// </summary>
        /// <typeparam name="TDistribution">The type of the distribution.</typeparam>
        /// <param name="arrayToCopy">The array to copy.</param>
        /// <returns>
        /// The <see cref="DistributionStructArray{TDistribution, Double}" /> array.
        /// </returns>
        public static DistributionStructArray<TDistribution, double>[] Copy<TDistribution>(
            IEnumerable<IList<TDistribution>> arrayToCopy)
            where TDistribution : struct, IDistribution<double>, SettableToProduct<TDistribution>,
            SettableToRatio<TDistribution>,
            SettableToPower<TDistribution>, SettableToWeightedSum<TDistribution>, CanGetLogAverageOf<TDistribution>,
            CanGetLogAverageOfPower<TDistribution>, CanGetAverageLog<TDistribution>, Sampleable<double>
        {
            return arrayToCopy.Select(Copy).ToArray();
        }

        public static double MeanComparer(Gaussian ia, Gaussian ib)
        {
            return Math.Abs(ia.GetMean() - ib.GetMean());
        }

        public static double StdDevComparer(Gaussian ia, Gaussian ib)
        {
            return Math.Abs(Math.Sqrt(ia.GetVariance()) - Math.Sqrt(ib.GetVariance()));
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

            var diffs = new double[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                diffs[i] = f(a[i], b[i]);
            }

            return diffs.Max();
            // return a.Zip(b, f).Max();
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

        /// <summary>
        /// Gets the approximate sparsity.
        /// </summary>
        /// <param name="gaussians">The Gaussian array.</param>
        /// <param name="threshold">The threshold.</param>
        public static double GetSparsity(Gaussian[] gaussians, double threshold)
        {
            // Want to take the norm of the vector into account
            double norm = gaussians.L2Norm();
            double cutoff = threshold * norm;

            // TODO: Do we want to call GetLogProb and take the variance into account?
            return gaussians.Select(ia => Math.Abs(ia.GetMean()) > cutoff ? 0.0 : 1.0).Average();
        }

        /// <summary>
        /// Gets the approximate sparsity.
        /// </summary>
        /// <param name="gaussians">The Gaussian array.</param>
        /// <param name="threshold">The threshold.</param>
        public static double[] GetSparsity(Gaussian[][] gaussians, double threshold)
        {
            return gaussians.Select(ia => ia.GetSparsity(threshold)).ToArray();
        }

        /// <summary>
        /// Create a distribution over an array domain from independent distributions over the elements.
        /// </summary>
        /// <typeparam name="T">Distribution type for an array element.</typeparam>
        /// <param name="array">The distribution of each element.</param>
        /// <returns>A single distribution object over the array domain.</returns>
        public static IDistribution<double[][][][]> Array<T>(T[][][][] array)
            where T : IDistribution<double>
        {
            var inner2Type = Distribution.MakeDistributionArrayType(typeof (T), 1);
            var innerType = Distribution.MakeDistributionArrayType(inner2Type, 1);
            var middleType = Distribution.MakeDistributionArrayType(innerType, 1);
            var method =
                new Func<T[][][][], IDistribution<double[][][][]>>(Array1111<T, object, object, object>).Method
                    .GetGenericMethodDefinition();
            method = method.MakeGenericMethod(typeof (T), inner2Type, innerType, middleType);
            return (IDistribution<double[][][][]>) method.Invoke(null, new object[] {array});
        }

        private static IDistribution<double[][][][]> Array1111<T, TInner2, TInner, TMiddle>(T[][][][] array)
            where T : IDistribution<double>
        {
            return (IDistribution<double[][][][]>) Activator.CreateInstance(
                Distribution.MakeDistributionArrayType(typeof(TMiddle), 1), (object) array.Length,
                (object) (Func<int, TMiddle>) (i => (TMiddle) Activator.CreateInstance(typeof(TMiddle), array[i].Length,
                    (Func<int, TInner>) (j => (TInner) Activator.CreateInstance(typeof(TInner),
                        (object) array[i][j].Length,
                        (object) (Func<int, TInner2>) (k => (TInner2) Activator.CreateInstance(typeof(TInner2),
                            array[i][j][k])))))));
        }
//
//        private static IDistribution<T[][][]> Array111<Distribution, TInner, TMiddle>(Distribution[][][] array) where Distribution : IDistribution<T>
//        {
//            return (IDistribution<T[][][]>) Activator.CreateInstance(Distribution.MakeDistributionArrayType(typeof (TMiddle), 1), new object[2]
//            {
//                (object) array.Length,
//                (object) (Func<int, TMiddle>) (i => (TMiddle) Activator.CreateInstance(typeof (TMiddle), new object[2]
//                {
//                    (object) array[i].Length,
//                    (object) (Func<int, TInner>) (j => (TInner) Activator.CreateInstance(typeof (TInner), new object[1]
//                    {
//                        (object) array[i][j]
//                    }))
//                }))
//            });
//        }
    }
}

