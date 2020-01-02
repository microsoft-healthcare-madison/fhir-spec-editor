using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// (Profile-only) 
    /// This tab captures definitional information about the profile - who made 
    /// it, what it's called, what it's for, etc. This information is not needed for resources and data 
    /// types because they are not separately maintained and published. The metadata for all FHIR 
    /// resources and data types is fixed.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 12/30/2019.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName:"Metadata",
        fieldStructure:ExcelTabAttribute.FieldNameStructures.NameValueRows,
        allowedForProfile:ExcelTabAttribute.PageAllowedLevels.Required,
        allowedForResource:ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        allowedForDataType:ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        description:
            "(Profile-only) This tab captures definitional information about the profile - who made " +
            "it, what it's called, what it's for, etc. This information is not needed for resources and data " +
            "types because they are not separately maintained and published. The metadata for all FHIR " +
            "resources and data types is fixed."
        )]
    public class TabMetadata
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - string. This is a unique id for the profile within the build environment. Normally 
        /// human-readable, lower-case, dash-separated. If doing a "general" profile, this is the same as 
        /// the [id] specified in the fhir.ini file. If doing a resource or data type-specific profile, the 
        /// first word should be the focal resource or data type name followed by a dash followed by one or 
        /// more qualifying words to create a short, unique, semi-descriptive id.
        /// </summary>
        ///
        /// <value>The id.</value>
        ///-------------------------------------------------------------------------------------------------

        [field:ExcelField(
            fieldName:"id",
            displayName:"Profile ID",
            required:ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required. This is a unique id for the profile within the build environment. " +
                "Normally human-readable, lower-case, dash-separated. If doing a \"general\" profile, " +
                "this is the same as the [id] specified in the fhir.ini file. If doing a resource or " +
                "data type-specific profile, the first word should be the focal resource or data type " +
                "name followed by a dash followed by one or more qualifying words to create a short, " +
                "unique, semi-descriptive id."
            )]
        public string Id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is a descriptive name for the profile. If doing a resource-specific profile, this should be 
        /// the same as the 'Name' for the profile specified in the resource spreadsheet.
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "name",
            displayName: "Profile Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required, 
            description:
                "This is a descriptive name for the profile. If doing a resource-specific profile, this " +
                "should be the same as the 'Name' for the profile specified in the resource spreadsheet."
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should be "HL7 International - [owning work group name - e.g. Orders & Observations] WG"
        /// </summary>
        ///
        /// <value>The authoring work group.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "name.author",
            displayName: "Owning WG Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This should be \"HL7 International - [owning work group name - e.g.Orders & Observations] WG\""
            )]
        public string OwningWorkingGroupName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should be the URL for the owning work group on the HL7 website. E.g. 
        /// http://hl7.org/Special/committees/orders
        /// </summary>
        ///
        /// <value>The owner reference.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "name.reference",
            displayName: "Owning WG URL",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This should be the URL for the owning work group on the HL7 website. E.g. " +
                "http://hl7.org/Special/committees/orders"
            )]
        public Uri OwningWorkingGroupUrl { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This isn't used at present and should be left blank. If you think you need it, talk to someone 
        /// from the FMG.
        /// </summary>
        ///
        /// <value>The code.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "code",
            displayName: "Code (Reserved - do not use)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Prohibited,
            description:
                "This isn't used at present and should be left blank. If you think you need it, talk to " +
                "someone from the FMG."
            )]
        public string Code { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is a short description that will be displayed when displaying lists of profiles. It's also 
        /// what will show up as the description of the profile if no "introduction" filename is provided 
        /// below.
        /// </summary>
        ///
        /// <value>The description.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "description",
            displayName: "Profile Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This is a short description that will be displayed when displaying lists of profiles. " +
                "It's also what will show up as the description of the profile if no \"introduction\" " +
                "filename is provided below."
            )]
        public string Description { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should be "draft". It will be changed when the profile goes normative.
        /// </summary>
        ///
        /// <value>The status.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "status",
            displayName: "Profile Status",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This should be \"draft\". It will be changed when the profile goes normative."
            )]
        public string Status { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should be set to the date the profile was first created. It will be changed when the 
        /// profile goes normative.
        /// </summary>
        ///
        /// <value>The date.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "date",
            displayName: "Publish Date",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This should be set to the date the profile was first created. It will be changed when the " +
                "profile goes normative."
            )]
        public DateTime? PublishDate { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is the name of a tab that defines one of the "published" structures for the profile. It 
        /// must match the name of one of the tabs in the spreadsheet corresponding to a structure. It must 
        /// be omitted if the profile only defines extensions and/or search criteria. If a profile defines 
        /// multiple structures, create multiple rows all with a label of "published.structure" and specify 
        /// a distinct structure tab name for each. It is possible to have structures that aren't 
        /// "published". In this case, the tab is defined and referenced from other structures tabs but is 
        /// not referenced from the metadata tab.
        /// </summary>
        ///
        /// <value>The published structures.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "published.structure",
            displayName: "Published Structure Names",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "This is the name of a tab that defines one of the \"published\" structures for the profile. " +
                "It must match the name of one of the tabs in the spreadsheet corresponding to a structure. It " +
                "must be omitted if the profile only defines extensions and/or search criteria. If a profile " +
                "defines multiple structures, create multiple rows all with a label of \"published.structure\" " +
                "and specify a distinct structure tab name for each. It is possible to have structures that aren't " +
                "\"published\". In this case, the tab is defined and referenced from other structures tabs but is " +
                "not referenced from the metadata tab."
            )]
        public List<string> PublishedStructureNames { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This should be omitted unless there are specific reasons to declare a business version for the 
        /// profile
        /// </summary>
        ///
        /// <value>The version.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "version",
            displayName: "Version",
            required: ExcelFieldAttribute.FieldRequiredLevels.Prohibited,
            description:
                "This should be omitted unless there are specific reasons to declare a business version for " +
                "the profile"
            )]
        public string Version { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This provides the base URI for extensions and search criteria as well as for structures 
        /// referenced in other profiles. It also forms the "identifier" for the profile.
        /// </summary>
        ///
        /// <value>The extension URI.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "extension.uri",
            displayName: "Profile Base URI",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This provides the base URI for extensions and search criteria as well as for structures " +
                "referenced in other profiles. It also forms the \"identifier\" for the profile."
            )]
        public Uri ExtensionUri { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is the full name of the "introduction" HTML file (if one exists). This name must be 
        /// specified for the introduction to be rendered.
        /// </summary>
        ///
        /// <value>The filename of the introduction file.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "introduction",
            displayName: "Introduction HTML Filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "This is the full name of the \"introduction\" HTML file (if one exists). This name must be " +
                "specified for the introduction to be rendered."
            )]
        public string IntroductionFilename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is the full name of the "notes" HTML file (if one exists). This name must be specified for 
        /// the notes to be rendered.
        /// </summary>
        ///
        /// <value>The filename of the notes file.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "notes",
            displayName: "Notes HTML Filename",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "This is the full name of the \"notes\" HTML file (if one exists). This name must be " +
                "specified for the notes to be rendered."
            )]
        public string NotesFilename { get; set; }
    }
}
