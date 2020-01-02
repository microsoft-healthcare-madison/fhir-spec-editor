using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// In resources, there's a single Search tab. In profiles, there can be a search tab for each 
    /// structure (with the tab name [profilename]-search)
    ///
    /// The Search tab contains the search operations for a resource or supplemental search operations 
    /// based on extensions.The standard search operations $page, $count and $id do not need to be 
    /// specified, but are added automatically.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Search",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "In resources, there's a single Search tab. In profiles, there can be a search tab for each " +
            "structure (with the tab name [profilename]-search)\n" +
            "\n" +
            "The Search tab contains the search operations for a resource or supplemental search operations " +
            "based on extensions.The standard search operations $page, $count and $id do not need to be " +
            "specified, but are added automatically."
        )]
    public class TabSearch
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - a lower-case string. May not end in "-before" or "-after", these suffixes are 
        /// automatically added for time-based searches.
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Name",
            displayName: "Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - a lower-case string. May not end in \"-before\" or \"-after\", these suffixes are " +
                "automatically added for time-based searches."
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - a choice. Allowed values are:
        /// - 'number'
        /// - 'date'
        /// - 'string'
        /// - 'token'
        /// - 'reference'
        /// - 'composite'
        /// - 'quantity'
        /// </summary>
        ///
        /// <value>The type of the search.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Type",
            displayName: "Search Data Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - a choice. Allowed values are:" +
                "- 'number'" +
                "- 'date'" +
                "- 'string'" +
                "- 'token'" +
                "- 'reference'" +
                "- 'composite'" +
                "- 'quantity'"
            )]
        public string SearchType { get; set; }

        public const string SearchTypeNumber = "number";
        public const string SearchTypeDate = "date";
        public const string SearchTypeString = "string";
        public const string SearchTypeToken = "token";
        public const string SearchTypeReference = "reference";
        public const string SearchTypeComposite = "composite";
        public const string SearchTypeQuantity = "quantity";

        /// <summary>List of types of the searches.</summary>
        public static readonly string[] SearchTypes =
        {
            SearchTypeComposite,
            SearchTypeDate,
            SearchTypeNumber,
            SearchTypeQuantity,
            SearchTypeReference,
            SearchTypeString,
            SearchTypeToken
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional - a comma delimited list of strings. Only allowed if Type="reference". If present, 
        /// indicates that the search only applies to the listed resource types (e.g. if a path called 
        /// SomeResource.subject is a Reference to multiple resource types, a corresponding search criteria 
        /// could limit allowed types.
        /// </summary>
        ///
        /// <value>A list of types of the targets.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Target Types",
            displayName: "Target Types",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional - a comma delimited list of strings. Only allowed if Type=\"reference\". If present, " +
                "indicates that the search only applies to the listed resource types (e.g. if a path called " +
                "SomeResource.subject is a Reference to multiple resource types, a corresponding search criteria " +
                "could limit allowed types."
            )]
        public string TargetTypes { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional - The path for the element that is the focus of this search criteria. If specified, 
        /// must correspond to a path for an element in the resource or must refer to the extension using 
        /// either "#extensionCode" for a locally-defined extension or the full extension URL for extensions 
        /// defined in a separate profile. Path is required if Type = "reference" and Target Types are not 
        /// provided
        /// </summary>
        ///
        /// <value>The element path.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Path",
            displayName: "Element Path",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional - The path for the element that is the focus of this search criteria. If specified, " +
                "must correspond to a path for an element in the resource or must refer to the extension using " +
                "either \"#extensionCode\" for a locally-defined extension or the full extension URL for extensions " +
                "defined in a separate profile. Path is required if Type = \"reference\" and Target Types are not " +
                "provided"
            )]
        public string Path { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional - a string. Required if path is not specified, will be defaulted based on path 
        /// otherwise. This element may be expressed using mark down to allow hyperlinking to other elements 
        /// in the specification, including bullets and other formatting.
        /// </summary>
        ///
        /// <value>The description.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Description",
            displayName: "Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional - a string. Required if path is not specified, will be defaulted based on path " +
                "otherwise. This element may be expressed using mark down to allow hyperlinking to other elements " +
                "in the specification, including bullets and other formatting."
            )]
        public string Description { get; set; }
    }
}
