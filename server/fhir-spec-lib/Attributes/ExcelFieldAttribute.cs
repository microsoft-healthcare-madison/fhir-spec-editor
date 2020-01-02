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
    public class ExcelFieldAttribute : System.Attribute
    {
        public enum FieldRequiredLevels 
        {
            Optional,
            Conditional,
            Required,
            Prohibited,
            Recommended
        }

        [field: ExcelField(
            fieldName: "",
            displayName: "",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "\n" +
                ""
            )]
        public string fieldName;
        public string displayName;
        public FieldRequiredLevels required;
        public string description;

        public ExcelFieldAttribute(
                                        string fieldName, 
                                        string displayName, 
                                        FieldRequiredLevels required,
                                        string description
                                        )
        {
            this.fieldName = fieldName;
            this.displayName = displayName;
            this.required = required;
            this.description = description;
        }
    }
}
