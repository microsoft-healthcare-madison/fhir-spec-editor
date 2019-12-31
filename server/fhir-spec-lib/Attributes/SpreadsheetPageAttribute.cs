using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Attributes
{

    ///-------------------------------------------------------------------------------------------------
    /// <summary>Attribute for spreadsheet page.</summary>
    ///
    /// <remarks>Gino Canessa, 12/30/2019.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class SpreadsheetPageAttribute : System.Attribute
    {
        public enum FieldNameStructures
        {
            Columns,
            NameValueRows
        }

        string pageName;
        FieldNameStructures fieldStructure;

        public SpreadsheetPageAttribute(string pageName, FieldNameStructures fieldStructure)
        {
            this.pageName = pageName;
            this.fieldStructure = fieldStructure;
        }
    }
}
