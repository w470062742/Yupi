using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Yupi.Emulator.Game.Catalogs.Composers;


namespace Yupi.Emulator.Game.Catalogs.Interfaces
{
    /// <summary>
    ///     Class CatalogPage.
    /// </summary>
     public class CatalogPage
    {
             /// <summary>
        ///     The caption
        /// </summary>
     public string Caption;

        /// <summary>
        ///     The code name
        /// </summary>
     public string CodeName;

        /// <summary>
        ///     The coming soon
        /// </summary>
     public bool ComingSoon;

        /// <summary>
        ///     The enabled
        /// </summary>
     public bool Enabled;

        /// <summary>
        ///     The flat offers
        /// </summary>
     public Dictionary<uint, uint> FlatOffers;

        /// <summary>
        ///     The icon image
        /// </summary>
     public int IconImage;

        /// <summary>
        ///     The items
        /// </summary>
     public HybridDictionary Items;

        /// <summary>
        ///     The layout
        /// </summary>
     public string Layout;

        /// <summary>
        ///     The layout headline
        /// </summary>
     public string LayoutHeadline;

        /// <summary>
        ///     The layout special
        /// </summary>
     public string LayoutSpecial;

        /// <summary>
        ///     The layout teaser
        /// </summary>
     public string LayoutTeaser;

        /// <summary>
        ///     The minimum rank
        /// </summary>
     public uint MinRank;

        /// <summary>
        ///     The order number
        /// </summary>
     public int OrderNum;

        /// <summary>
        ///     The page link
        /// </summary>
     public string PageLink;

        /// <summary>
        ///     The page link title
        /// </summary>
     public string PageLinkTitle;

        /// <summary>
        ///     The parent identifier
        /// </summary>
     public short ParentId;

        /// <summary>
        ///     The text1
        /// </summary>
     public string Text1;

        /// <summary>
        ///     The text2
        /// </summary>
     public string Text2;

        /// <summary>
        ///     The text details
        /// </summary>
     public string TextDetails;

        /// <summary>
        ///     The text teaser
        /// </summary>
     public string TextTeaser;

        /// <summary>
        ///     The visible
        /// </summary>
     public bool Visible;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CatalogPage" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="codeName">Name of the code.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="comingSoon">if set to <c>true</c> [coming soon].</param>
        /// <param name="minRank">The minimum rank.</param>
        /// <param name="iconImage">The icon image.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="layoutHeadline">The layout headline.</param>
        /// <param name="layoutTeaser">The layout teaser.</param>
        /// <param name="layoutSpecial">The layout special.</param>
        /// <param name="text1">The text1.</param>
        /// <param name="text2">The text2.</param>
        /// <param name="textDetails">The text details.</param>
        /// <param name="textTeaser">The text teaser.</param>
        /// <param name="pageLinkTitle">The page link title.</param>
        /// <param name="pageLink">The page link.</param>
        /// <param name="orderNum">The order number.</param>
        /// <param name="cataItems">The cata items.</param>
     public CatalogPage(uint id, short parentId, string codeName, string caption, bool visible, bool enabled,
            bool comingSoon, uint minRank, int iconImage, string layout, string layoutHeadline, string layoutTeaser,
            string layoutSpecial, string text1, string text2, string textDetails, string textTeaser,
            string pageLinkTitle, string pageLink, int orderNum, ref HybridDictionary cataItems)
        {
            PageId = id;
            ParentId = parentId;
            CodeName = codeName;
            Caption = caption;
            Visible = visible;
            Enabled = enabled;
            ComingSoon = comingSoon;
            MinRank = minRank;
            IconImage = iconImage;
            Layout = layout;
            LayoutHeadline = layoutHeadline;
            LayoutTeaser = layoutTeaser;
            LayoutSpecial = layoutSpecial;
            Text1 = text1;
            PageLinkTitle = pageLinkTitle;
            PageLink = pageLink;
            Text2 = text2;
            TextDetails = textDetails;
            TextTeaser = textTeaser;
            OrderNum = orderNum;

            if (layout.StartsWith("frontpage"))
                OrderNum = -2;

            Items = new HybridDictionary();
            FlatOffers = new Dictionary<uint, uint>();

            foreach (
                CatalogItem catalogItem in
                    cataItems.Values.OfType<CatalogItem>().Where(x => x.PageId == id && x.GetFirstBaseItem() != null))
            {
                Items.Add(catalogItem.Id, catalogItem);

                uint flatId = catalogItem.GetFirstBaseItem().FlatId;

                if (!FlatOffers.ContainsKey(flatId))
                    FlatOffers.Add(catalogItem.GetFirstBaseItem().FlatId, catalogItem.Id);
            }
        }

        /// <summary>
        ///     Gets the page identifier.
        /// </summary>
        /// <value>The page identifier.</value>
     public uint PageId { get; private set; }

        /// <summary>
        ///     Gets the item.
        /// </summary>
        /// <param name="pId">The p identifier.</param>
        /// <returns>CatalogItem.</returns>
     public CatalogItem GetItem(uint pId)
        {
            uint num = pId;
            uint flatInt = pId;

            if (FlatOffers.ContainsKey(flatInt))
                return (CatalogItem) Items[FlatOffers[flatInt]];

            if (Items.Contains(num))
                return (CatalogItem) Items[num];

            return null;
        }
    }
}