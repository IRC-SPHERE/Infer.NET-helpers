//
// ArrayHelpers.cs
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
    using System.Linq;
    using MicrosoftResearch.Infer.Maths;

    /// <summary>
    /// Array helpers.
    /// </summary>
    public static class ArrayHelpers
    {
        /// <summary>
        /// Array of zeros of length m.
        /// </summary>
        /// <param name="m">m.</param>
        public static double[] Zeros(int m)
        {
            return Enumerable.Repeat(0.0, m).ToArray();
        }

        /// <summary>
        /// Jagged array of zeros of lengths m, n.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        public static double[][] Zeros(int m, int n)
        {
            return Enumerable.Repeat(Zeros(n), m).ToArray();
        }

        /// <summary>
        /// Array of zero vectors of lengths m, n.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        public static Vector[] VectorZeros(int m, int n)
        {
            return Enumerable.Repeat(Vector.Zero(n), m).ToArray();
        }

        /// <summary>
        /// Uniform array of length m.
        /// </summary>
        /// <param name="m">m.</param>
        /// <param name="value">Value.</param>
        public static T[] Uniform<T>(int m, T value)
        {
            return Enumerable.Repeat(value, m).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="value">Value.</param>
        public static T[][] Uniform<T>(int m, int n, T value)
        {
            return Enumerable.Repeat(Uniform(n, value), m).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="value">Value.</param>
        public static T[][] Uniform<T>(int m, int[] n, T value)
        {
            return Enumerable.Range(0, m).Select(i => Uniform(n[i], value)).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n, p, q.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="p">P.</param>
        /// <param name="value">Value.</param>
        public static T[][][] Uniform<T>(int m, int n, int p, T value)
        {
            return Enumerable.Repeat(Uniform(n, p, value), m).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n, p, q.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="p">P.</param>
        /// <param name="value">Value.</param>
        public static T[][][] Uniform<T>(int m, int n, int[] p, T value)
        {
            return Enumerable.Repeat(Uniform(m, p, value), m).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n, p, q.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="p">P.</param>
        /// <param name="q">Q.</param>
        /// <param name="value">Value.</param>
        public static T[][][][] Uniform<T>(int m, int n, int p, int q, T value)
        {
            return Enumerable.Repeat(Uniform(n, p, q, value), m).ToArray();
        }

        /// <summary>
        /// Jagged array of uniform values of lengths m, n, p, q.
        /// </summary>
        /// <param name="m">M.</param>
        /// <param name="n">N.</param>
        /// <param name="p">P.</param>
        /// <param name="q">Q.</param>
        /// <param name="value">Value.</param>
        public static T[][][][] Uniform<T>(int m, int n, int p, int[] q, T value)
        {
            return Enumerable.Repeat(Uniform(n, p, q, value), m).ToArray();
        }

        /// <summary>
        /// double version of Enumerable.Range
        /// </summary>
        /// <param name="start">The starting value.</param>
        /// <param name="count">The number of items.</param>
        public static double[] DoubleRange(int start, int count)
        {
            return Enumerable.Range(start, count).Select(x => (double) x).ToArray();
        }
    }
}

