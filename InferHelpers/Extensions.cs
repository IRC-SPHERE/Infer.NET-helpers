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

        /// <summary>
        /// Gets the plus minus sigma.
        /// </summary>
        /// <returns>The plus minus sigma.</returns>
        /// <param name="gaussian">The Gaussian.</param>
        public static double[] GetPlusMinusSigma(this Gaussian gaussian)
        {
            return new[] { gaussian.GetMean() - Math.Sqrt(gaussian.GetVariance()), gaussian.GetMean() + Math.Sqrt(gaussian.GetVariance()) };
        }
    }
}

