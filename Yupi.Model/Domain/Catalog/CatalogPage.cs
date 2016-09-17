﻿#region Header

// ---------------------------------------------------------------------------------
// <copyright file="CatalogPage.cs" company="https://github.com/sant0ro/Yupi">
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
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Linq;

    public class CatalogPage : IPopulate
    {
        #region Properties

        public virtual string Caption
        {
            get;
            set;
        }

        public virtual IList<CatalogPage> Children
        {
            get;
            protected set;
        }

        // TODO Isn't enabled the same as visible?
        public virtual bool Enabled
        {
            get;
            set;
        }

        public virtual int Icon
        {
            get;
            set;
        }

        public virtual int Id
        {
            get;
            protected set;
        }

        public virtual CatalogPageLayout Layout
        {
            get;
            set;
        }

        public virtual uint MinRank
        {
            get;
            set;
        }

        public virtual IList<CatalogOffer> Offers
        {
            get;
            protected set;
        }

        public virtual int OrderNum
        {
            get;
            set;
        }

        public virtual CatalogPage Parent
        {
            get;
            set;
        }

        public virtual CatalogOffer SelectedOffer
        {
            get;
            set;
        }

        public virtual CatalogType Type
        {
            get;
            set;
        }

        public virtual bool Visible
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructors

        protected CatalogPage()
        {
            this.Offers = new List<CatalogOffer>();
            this.Children = new List<CatalogPage>();
            this.Visible = true;
            this.Type = CatalogType.Normal;
            this.Layout = new Default3x3Layout();
        }

        #endregion Constructors

        #region Methods

        public virtual void Populate()
        {
            CatalogPage root = new CatalogPage()
            {
                Caption = "root",
                    Layout = new FrontpageFeaturedLayout()
                {
                    Text1 = "Text1",
                    Text2 = "Text2",
                    HeaderImage = "catalogue/catal_fp_header"
                },
            };

            root.Children.Add(new CatalogPage()
                {
                    Layout = new Default3x3Layout()
                    {
                        Text1 = "Text1",
                        Text2 = "Text2",
                        Description = "Description",
                        HeaderDescription = "HeaderDesc",
                        SpecialText = "SpecialText",
                    },
                    Caption = "Test",
                    Parent = root
                });

            ModelHelper.PopulateObject(
                root
            );
        }

        #endregion Methods
    }
}