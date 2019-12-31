using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Attributes
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>Attribute for spreadsheet field.</summary>
    ///
    /// <remarks>Gino Canessa, 12/30/2019.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    class SpreadsheetFieldAttribute : System.Attribute
    {
        public string fieldNameLower;
        public string displayName;
        public string description;

        public SpreadsheetFieldAttribute(string fieldNameLower, string displayName, string description)
        {
            this.fieldNameLower = fieldNameLower;
            this.displayName = displayName;
            this.description = description;
        }

        //[field: SpreadsheetField(
        //    fieldNameLower: "",
        //    displayName:"",
        //    description:
        //        ""
        //    )]
    }
}
