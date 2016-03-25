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
    using System.Linq;
    using MicrosoftResearch.Infer.Distributions;

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
    }
}

