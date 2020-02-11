using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// The Packages tab lists all conformance packages (combinations of structure, extension and/or 
    /// search criteria definitions) that are associated with the current resource (or data type). This 
    /// allows the profiles associated with a given resource for linkage in the publication. "Related" 
    /// means defining extensions, search criteria or structures for the resource/data type.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/6/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Packages",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Required,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Required,
        description:
            "The Packages tab lists all conformance packages (combinations of structure, extension and/or " +
            "search criteria definitions) that are associated with the current resource (or data type). This " +
            "allows the profiles associated with a given resource for linkage in the publication. \"Related\" " +
            "means defining extensions, search criteria or structures for the resource/data type."
        )]
    public class TabPackages : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - This is the name of the profile referenced. It will appear in the list of associated 
        /// profile. (Comment the row by starting the name with '!')
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Profile Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - This is the name of the profile referenced. It will appear in the list of associated " +
                "profile. (Comment the row by starting the name with '!')"
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - This is the filename of the profile to be produced in the "publish" directory
        /// </summary>
        ///
        /// <value>The filename.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Filename",
            displayName: "Profile Filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - This is the filename of the profile to be produced in the \"publish\" directory"
            )]
        public string Filename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - This is the filename of the source for the profile. (Defaults to the same as Filename). 
        /// It should be relative to the resource directory.
        /// </summary>
        ///
        /// <value>The source filename.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Source",
            displayName: "Source Filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - This is the filename of the source for the profile. (Defaults to the same as Filename). " +
                "It should be relative to the resource directory."
            )]
        public string SourceFilename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - Indicates if the profile is defined as a spreadsheet or a profile XML file (choices 
        /// are spreadsheet|profile).
        /// </summary>
        ///
        /// <value>The type of the package.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Type",
            displayName: "Package Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - Indicates if the profile is defined as a spreadsheet or a profile XML file (choices " +
                "are spreadsheet|profile)."
            )]
        public string PackageType { get; set; }

        public const string PackageTypeSpreadsheet = "spreadsheet";
        public const string PackageTypeProfile = "profile";
        public static readonly string[] PackageTypes =
        {
            PackageTypeSpreadsheet,
            PackageTypeProfile
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - the implementation guide that the package belongs to (must refer to an entry in 
        /// fhir.ini by the code used in the ini file)
        /// </summary>
        ///
        /// <value>The name of the implementation guide.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "IG Name",
            displayName: "IG Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - the implementation guide that the package belongs to (must refer to an entry in " +
                "fhir.ini by the code used in the ini file)"
            )]
        public string ImplementationGuideName { get; set; }
    }
}
