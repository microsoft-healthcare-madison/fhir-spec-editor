using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Tab listing profiles for this resource
    /// Not Documented
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/16/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Profiles",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "Profiles for this resource."
        )]
    public class TabProfiles : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The name used to label and reference the profile
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Name (label)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The name used to label and reference the profile"
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Description of the profile shown when it's listed in profileList.html (one sentence or so)
        /// </summary>
        ///
        /// <value>The description.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Description",
            displayName: "Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Description of the profile shown when it's listed in profileList.html (one sentence or so)"
            )]
        public string Description { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The name of the profile.xml file that should be generated from the spreadsheet. This should 
        /// generally be ResourceName-[same qualifier].xml
        /// </summary>
        ///
        /// <value>The filename.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Filename",
            displayName: "Output Profile XML Filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The name of the profile.xml file that should be generated from the spreadsheet. This should " +
                "generally be ResourceName-[same qualifier].xml"
            )]
        public string Filename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The name of the profile spreadsheet xml file.
        /// </summary>
        ///
        /// <value>The source.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Source",
            displayName: "Source filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The name of the profile spreadsheet xml file."
            )]
        public string Source { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should always be "spreadsheet" when using the spreadsheet method.
        /// </summary>
        ///
        /// <value>The type.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Type",
            displayName: "Definition Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This should always be \"spreadsheet\" when using the spreadsheet method."
            )]
        public string DefinitionType { get; set; }

        public const string DefinitionTypeSpreadsheet = "spreadsheet";

        public static readonly string[] DefinitionTypes = {
            DefinitionTypeSpreadsheet
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The Implementation Guide Name (?)
        /// Not documented
        /// </summary>
        ///
        /// <value>The name of the Implementation Guide.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "IGName",
            displayName: "IG Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The Implementation Guide Name (?)" +
                "Not documented"
            )]
        public string IGName { get; set; }
    }
}
