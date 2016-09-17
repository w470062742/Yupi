﻿#region Header

// ---------------------------------------------------------------------------------
// <copyright file="InfoRentablesLayout.cs" company="https://github.com/sant0ro/Yupi">
//   Copyright (c) 2016 Claudio Santoro, TheDoctor
// </copyright>
// <license>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
//
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//   THE SOFTWARE.
// </license>
// ---------------------------------------------------------------------------------

#endregion Header

namespace Yupi.Model.Domain
{
    using System;

    public class InfoRentablesLayout : DefaultImageLayout
    {
        #region Properties

        public virtual string HeaderDescription
        {
            get; set;
        }

        [Ignore]
        public override string Name
        {
            get {
                return "info_rentables";
            }
        }

        public virtual string Text1
        {
            get; set;
        }

        public virtual string Text2
        {
            get; set;
        }

        public virtual string Text3
        {
            get; set;
        }

        public virtual string Text4
        {
            get; set;
        }

        public virtual string Text5
        {
            get; set;
        }

        [Ignore]
        public override string[] Texts
        {
            get {
                return new string[] { HeaderDescription, Text1, Text2, Text3, Text4, Text5 };
            }
        }

        #endregion Properties
    }
}