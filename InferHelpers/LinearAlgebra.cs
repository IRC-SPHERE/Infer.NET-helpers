//
// LinearAlgebra.cs
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
    using MicrosoftResearch.Infer.Models;

    /// <summary>
    /// Linear algebra operations on array/matrix distributions
    /// </summary>
    public static class LinearAlgebra
    {
        /// <summary>
        /// Compute the matrix norm
        /// </summary>
        /// <param name="matrix">The input matrix.</param>
        /// <param name="norm">The norm.</param>
        /// <returns>The norm of the matrix.</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">Unknown norm.</exception>
        public static Variable<double> MatrixNorm(VariableArray<VariableArray<double>, double[][]> matrix, string norm)
        {
            var source = matrix.Ranges[0];
            norm = norm.ToLowerInvariant();

            switch (norm)
            {
                case "1":
                    // simply the maximum absolute column sum of the matrix. Transpose and use the infinity norm
                    var outer = matrix.Range;
                    var inner = matrix[0].Range;
                    var transposed = Variable.Array(Variable.Array<double>(outer), inner);
                    using (Variable.ForEach(outer))
                    {
                        using (Variable.ForEach(inner))
                        {
                            transposed[inner][outer] = matrix[outer][inner];
                        }
                    }
                    return MatrixNorm(transposed, "max");
                    
                case "fro":
                    var rowNorms = Variable.Array<double>(source);
                    using (Variable.ForEach(source))
                    {
                        var copy = Variable.Copy(matrix[source]);
                        var vec = Variable.Vector(copy);

                        rowNorms[source] = Variable.InnerProduct(matrix[source], vec);
                    }

                    return Variable.Sum(rowNorms);
                case "max":
                case "infinity":
                    // Infinity (max) norm: which is simply the maximum absolute row sum of the matrix
                    var rowSums = Variable.Array<double>(source);
                    using (Variable.ForEach(source))
                    {
                        var abs = GetAbsolute(matrix[source]);
                        rowSums[source] = Variable.Sum(abs);
                    }
                    return Max(rowSums);
            }

            throw new ArgumentOutOfRangeException(nameof(norm));
        }

        /// <summary>
        /// Get the absolute values of the jagged array (matrix)
        /// </summary>
        /// <param name="matrix">The jagged array of variables.</param>
        /// <returns>Absolute values of the matrix.</returns>
        private static VariableArray<VariableArray<double>, double[][]> GetAbsolutes(
            VariableArray<VariableArray<double>, double[][]> matrix)
        {
            var source = matrix.Range;
            var feature = matrix[0].Range;
            var absolutes = Variable.Array(Variable.Array<double>(feature), source);
            using (Variable.ForEach(source))
            {
                absolutes[source] = GetAbsolute(matrix[source]);
            }

            return absolutes;
        }

        /// <summary>
        /// Get the absolute values of the array
        /// </summary>
        /// <param name="array">The array of variables.</param>
        /// <returns>Absolute values of the array.</returns>
        private static VariableArray<double> GetAbsolute(VariableArray<double> array)
        {
            var feature = array.Range;
            var abs = Variable.Array<double>(feature).Named("abs");
            using (Variable.ForEach(feature))
            {
                var isPos = Variable.IsPositive(array[feature]);
                using (Variable.If(isPos))
                {
                    abs[feature] = Variable.Copy(array[feature]);
                }

                using (Variable.IfNot(isPos))
                {
                    abs[feature] = -array[feature];
                }
            }

            return abs;
        }

        /// <summary>
        /// Maximum value of the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <returns>The max of the array.</returns>
        public static Variable<double> Max(VariableArray<double> array)
        {
            var n = array.Range;
            var maxUpTo = Variable.Array<double>(n).Named("maxUpTo");
            using (var fb = Variable.ForEach(n))
            {
                var i = fb.Index;
                using (Variable.Case(i, 0))
                {
                    maxUpTo[i] = Variable.Copy(array[i]);
                }
                using (Variable.If(i > 0))
                {
                    maxUpTo[i] = Variable.Max(maxUpTo[i - 1], array[i]);
                }
            }

            var max = Variable.Copy(maxUpTo[(Variable<int>)n.Size - 1]);
            return max;
        }
    }
}