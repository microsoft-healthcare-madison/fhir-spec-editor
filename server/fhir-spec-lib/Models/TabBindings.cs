using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// The Binding tab contains the definition of the Bindings as mentioned in the definition of the 
    /// data elements. The Binding column in the Data Elements Tab refers to the Binding Name. Bindings 
    /// may be used in multiple resources, data types and/or profiles, but should only be defined in 
    /// one spreadsheet.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/10/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Bindings",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "The Binding tab contains the definition of the Bindings as mentioned in the definition of the " +
            "data elements. The Binding column in the Data Elements Tab refers to the Binding Name. Bindings " +
            "may be used in multiple resources, data types and/or profiles, but should only be defined in " +
            "one spreadsheet."
        )]
    public class TabBindings : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// required - a string beginning with an Uppercase letter. Must be unique across the FHIR 
        /// specification
        /// </summary>
        ///
        /// <value>The name of the binding.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Binding Name",
            displayName: "Binding Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "A string beginning with an Uppercase letter. Must be unique across the FHIR specification"
            )]
        public string BindingName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// required - a string explaining the purpose of this binding. Guides other developers in whether 
        /// to re-use this binding. Also displayed in the spec.
        /// </summary>
        ///
        /// <value>The definition.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Definition",
            displayName: "Definition (Explanation)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "required - a string explaining the purpose of this binding. Guides other developers in whether " +
                "to re-use this binding. Also displayed in the spec."
            )]
        public string Definition { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a choice. Allowed values are:
        /// - "code list" - an internal reference to a different tab, which enumerates a simple list of codes
        /// - "value set" - the name of a file in the same directory as the spreadsheet that has the value 
        ///   set for the attribute
        /// - "reference" - a direct reference to an external standard(usually an RFC) (not bound to 
        ///   schema.typical examples: language, mime type)
        /// - "special" - used for infrastructural things by the project team. (usually bound to schema)
        /// - "unbound" - This should only be used when example codes from an external terminology do not 
        ///   exist and none of the others apply. (This should be VERY rare.)
        /// </summary>
        ///
        /// <value>The binding.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Binding",
            displayName: "Binding Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "A choice. Allowed values are:\n" +
                "- \"code list\" - an internal reference to a different tab, which enumerates a simple list of codes\n" +
                "- \"value set\" - the name of a file in the same directory as the spreadsheet that has the value " +
                "  set for the attribute\n" +
                "- \"reference\" - a direct reference to an external standard(usually an RFC) (not bound to " +
                "  schema.typical examples: language, mime type)\n" +
                "- \"special\" - used for infrastructural things by the project team. (usually bound to schema)\n" +
                "- \"unbound\" - This should only be used when example codes from an external terminology do not " +
                "  exist and none of the others apply. (This should be VERY rare.)"
            )]
        public string Binding { get; set; }

        public const string BindingCodeList = "code list";
        public const string BindingValueSet = "value set";
        public const string BindingReference = "reference";
        public const string BindingSpecial = "special";
        public const string BindingUnbound = "unbound";

        public static readonly string[] BindingsValues =
        {
            BindingCodeList,
            BindingValueSet,
            BindingReference,
            BindingSpecial,
            BindingUnbound
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// (Resource-only) to indicate the the value set binding is an example. Default is 'N'. Only used 
        /// with "value set" bindings
        /// </summary>
        ///
        /// <value>True if this object is example, false if not.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Example",
            displayName: "Is Example Flag",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "(Resource-only) to indicate the the value set binding is an example. Default is 'N'. Only used" +
                "with \"value set\" bindings"
            )]
        public bool IsExample { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates whether the specified codes must be used. Choices are:
        /// - "required" - systems SHALL use the codes specified
        /// - "preferred" - systems SHOULD use the codes specified
        /// - "example" - systems MAY use the codes specified
        /// </summary>
        ///
        /// <value>The conformance.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Conformance",
            displayName: "Conformance Level",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Indicates whether the specified codes must be used. Choices are:\n" +
                "- \"required\" - systems SHALL use the codes specified\n" +
                "- \"preferred\" - systems SHOULD use the codes specified\n" +
                "- \"example\" - systems MAY use the codes specified\n"
            )]
        public string Conformance { get; set; }

        public const string ConformanceRequired = "required";
        public const string ConformancePreferred = "preferred";
        public const string ConformanceExample = "example";

        public static readonly string[] ConformanceValues =
        {
            ConformanceRequired,
            ConformancePreferred,
            ConformanceExample
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///  (Profile-only) - If 'Y', indicates that additional codes may be used if no appropriate code is 
        ///  in the specified set. If 'N', indicates that only the specified codes may be used (if the 
        ///  system chooses to adhere to the specified value set)
        /// </summary>
        ///
        /// <value>True if this object is extensible, false if not.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Extensible",
            displayName: "Is Extensible Flag",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "(Profile-only) - If 'Y', indicates that additional codes may be used if no appropriate code is " +
                "in the specified set. If 'N', indicates that only the specified codes may be used (if the " +
                "system chooses to adhere to the specified value set)"
            )]
        public bool IsExtensible { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Either #[tab-name], or [valueset-file-name] or [http url] - use depends on the binding type
        /// </summary>
        ///
        /// <value>The reference.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Reference",
            displayName: "Reference",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Either #[tab-name], or [valueset-file-name] or [http url] - use depends on the binding type"
            )]
        public string Reference { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string only used when the Binding is a "reference". It provides the descriptive text used for 
        /// the URL present in the Reference column
        /// </summary>
        ///
        /// <value>The description.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Description",
            displayName: "Description (if binding='reference')",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "a string only used when the Binding is a \"reference\". It provides the descriptive text used for " +
                "the URL present in the Reference column"
            )]
        public string Description { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - only for code lists. The OID to use for the code list if the FHIR generation 
        /// process shouldn't assign one
        /// </summary>
        ///
        /// <value>The code list oid.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "OID",
            displayName: "Code List OID",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - only for code lists. The OID to use for the code list if the FHIR generation " +
                "process shouldn't assign one"
            )]
        public string CodeListOID { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - only for code lists. The URI to use for the code list if the FHIR generation process 
        /// shouldn't assign one
        /// </summary>
        ///
        /// <value>The code list URI.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "URI",
            displayName: "Code List URI",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - only for code lists. The URI to use for the code list if the FHIR generation process " +
                "shouldn't assign one"
            )]
        public Uri CodeListURI { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - only for code lists. The contact information to use for the code list if the default 
        /// HL7 information shouldn't be used
        /// </summary>
        ///
        /// <value>Information describing the contact.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Website/Email",
            displayName: "Contact Info Override",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - only for code lists. The contact information to use for the code list if the default " +
                "HL7 information shouldn't be used"
            )]
        public string ContactInfoOverride { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - only for code lists. The copyright information if the default HL7 "public domain" 
        /// copyright shouldn't be used
        /// </summary>
        ///
        /// <value>The copyright.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Copyright",
            displayName: "Copyright (if not 'public domain')",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - only for code lists. The copyright information if the default HL7 \"public domain\" " +
                "copyright shouldn't be used"
            )]
        public string Copyright { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The URI of a value set in v2 that the codes are mapped to (binding = code list only). see 
        /// http://hl7.org/implement/standards/fhir/terminologies-v2.htm for valid values
        /// </summary>
        ///
        /// <value>The v 2.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "v2",
            displayName: "Code List v2 Mapping URI",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The URI of a value set in v2 that the codes are mapped to (binding = code list only). see " +
                "http://hl7.org/implement/standards/fhir/terminologies-v2.htm for valid values"
            )]
        public string V2 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// the URI of a value set in v3 that the codes are mapped to (binding = code list only). see 
        /// http://hl7.org/implement/standards/fhir/terminologies-v3.htm for valid values
        /// </summary>
        ///
        /// <value>The v 3.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "v3",
            displayName: "Code List v3 Mapping URI",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "the URI of a value set in v3 that the codes are mapped to (binding = code list only). see " +
                "http://hl7.org/implement/standards/fhir/terminologies-v3.htm for valid values"
            )]
        public string V3 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Additional notes about the selected set of codes - not published
        /// </summary>
        ///
        /// <value>The committee notes.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Committee Notes",
            displayName: "Committee Notes",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Additional notes about the selected set of codes - not published"
            )]
        public string CommitteeNotes { get; set; }
    }
}
