using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Resource/Data Type-only - required.
    /// This is the tab that defines the content of the data type or resource.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Data Elements",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Required,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Required,
        description:
            "Resource/Data Type-only - required." +
            "This is the tab that defines the content of the data type or resource."
        )]
    public class TabDataElements : CommonElementFields
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This indicates whether the element should be included in a query response for which 
        /// "summary" elements have been requested. It must be set to either "Y" or "N". (The tool will 
        /// default it to "N" if omitted.) It is only relevant when defining resources.
        /// </summary>
        ///
        /// <value>The summary.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Summary",
            displayName: "Summary",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This indicates whether the element should be included in a query response for which " +
                "\"summary\" elements have been requested. It must be set to either \"Y\" or \"N\". (The tool will " +
                "default it to \"N\" if omitted.) It is only relevant when defining resources."
            )]
        public bool? Summary { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This may be specified for data elements with 'simple' data types. It asserts a regular 
        /// expression that should be asserted as part of the schema for validating that particular resource 
        /// or data type element. (If you want to assert a regular expression on an element in a profile, 
        /// use an Invariant.)
        /// </summary>
        ///
        /// <value>The validation RegEx.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Regex",
            displayName: "Validation RegEx",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This may be specified for data elements with 'simple' data types. It asserts a regular " +
                "expression that should be asserted as part of the schema for validating that particular resource " +
                "or data type element. (If you want to assert a regular expression on an element in a profile, " +
                "use an Invariant.)"
            )]
        public string ValidationRegEx { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This overrides the default placement of the element in the UML layout. It can only be 
        /// specified on "complex" elements (those without a declared type). There are two different ways 
        /// the UML diagram can be controlled:
        /// 
        /// - The simple way: assert the direction(left|right|up|down) the 'class' should be with respect to 
        /// the containing 'class'.
        /// 
        /// - The explicit way: The format is "x;y", where "x" is the horizontal coordinate in pixels and 
        /// the "y" is the vertical coordinate in pixels. (The general methodology is play around with values 
        /// and keep re-generating until the diagram looks the way you want it to.)
        /// </summary>
        ///
        /// <value>The UML hint.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "UML",
            displayName: "UML Override",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This overrides the default placement of the element in the UML layout. It can only be " +
                "specified on \"complex\" elements (those without a declared type). There are two different ways " +
                "the UML diagram can be controlled:\n" +
                "\n" +
                "- The simple way: assert the direction(left|right|up|down) the 'class' should be with respect to " +
                "the containing 'class'.\n" +
                "\n" +
                "- The explicit way: The format is \"x;y\", where \"x\" is the horizontal coordinate in pixels and " +
                "the \"y\" is the vertical coordinate in pixels. (The general methodology is play around with values " +
                "and keep re-generating until the diagram looks the way you want it to.)"
            )]
        public string UML { get; set; }


        
    }
}
