
using System;
using System.Collections.Generic;
using System.Text;

namespace DCS.TagAutocomplete
{
    class TagObject: AutocompleteItem
    {
        public TagObject(string tag)
            : base(tag)
        {
            ImageIndex = 0;
            ToolTipTitle = "Insert ImporExportSelected:";
            ToolTipText = tag;
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (fragmentText == Text)
                return CompareResult.VisibleAndSelected;
            if (fragmentText.Contains("."))
                return CompareResult.Visible;
            return CompareResult.Hidden;
        }
    }
}
