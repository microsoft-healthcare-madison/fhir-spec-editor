using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// The Examples Tab lists the details for example files for a resource. If the tab does not hold 
    /// any references to examples, the resource's source directory will be search for a file ending 
    /// in "{resourcename}-example.xml" and this file is then used as an example instead.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/6/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Examples",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "The Examples Tab lists the details for example files for a resource. If the tab does not hold " +
            "any references to examples, the resource's source directory will be search for a file ending " +
            "in \"{resourcename}-example.xml\" and this file is then used as an example instead."
        )]
    public class TabExamples : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Required - A descriptive label for the example starting with upper-case.
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Example Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - A descriptive label for the example starting with upper-case."
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// A choice. Allowed values are:
        /// - (empty) or "xml": Standard XML instance example(could also be XML atom feed)
        /// - "csv": Requires custom support - ask Grahame if you want to use this
        /// - "tool": Requires custom support - ask Grahame if you want to use this
        /// </summary>
        ///
        /// <value>The type of the example.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Type",
            displayName: "Example Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "A choice. Allowed values are:" +
                "- (empty) or \"xml\": Standard XML instance example(could also be XML atom feed)" +
                "- \"csv\": Requires custom support - ask Grahame if you want to use this" +
                "- \"tool\": Requires custom support - ask Grahame if you want to use this"
            )]
        public string ExampleType { get; set; }

        public const string ExampleTypeEmpty = ""; // xml
        public const string ExampleTypeXml = "xml";
        public const string ExampleTypeCsv = "csv";
        public const string ExampleTypeTool = "tool";

        public static readonly string[] ExampleTypes =
        {
            ExampleTypeEmpty,
            ExampleTypeXml,
            ExampleTypeCsv,
            ExampleTypeTool
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - Explanation of the purpose of the example and what it shows. This element may be 
        /// expressed using mark down to allow hyperlinking to other elements in the specification, including 
        /// bullets and other formatting.
        /// </summary>
        ///
        /// <value>The description.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Description",
            displayName: "Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - Explanation of the purpose of the example and what it shows. This element may be " +
                "expressed using mark down to allow hyperlinking to other elements in the specification, including " +
                "bullets and other formatting."
            )]
        public string Description { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required (for XML only) - The identifier of the resource (must meet the constraints of the 
        /// 'id' data type)
        /// </summary>
        ///
        /// <value>The identity.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Identity",
            displayName: "Identity",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Required (for XML only) - The identifier of the resource (must meet the constraints of the " +
                "'id' data type)"
            )]
        public string Identity { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - the name of the example file
        /// </summary>
        ///
        /// <value>The filename.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "",
            displayName: "",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - the name of the example file"
            )]
        public string Filename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - The name of the profile the example should be linked to. (If blank, it will be linked 
        /// to the resource)
        /// </summary>
        ///
        /// <value>The profile.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Profile",
            displayName: "Profile Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - The name of the profile the example should be linked to. (If blank, it will be linked" +
                "to the resource)"
            )]
        public string Profile { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// If set to "Y", means the example will be included in the book form. (Not relevant right now 
        /// given that we no longer generate a book form)
        /// </summary>
        ///
        /// <value>The in book.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "In Book",
            displayName: "Include In Book",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "If set to \"Y\", means the example will be included in the book form. (Not relevant right now " +
                "given that we no longer generate a book form)"
            )]
        public bool? InBook { get; set; }
    }
}
