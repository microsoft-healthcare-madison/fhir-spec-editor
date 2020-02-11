using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// (Profile only)
    /// When defining resources or data types, you'll use the Data Elements tab. When defining profiles, 
    /// you'll use a "structure" tab (or possibly several structure tabs). Structures that are 
    /// referenced from the metadata tab (as a "Published.structure") will appear as "published" 
    /// structures that are externally referencable. Those that are not referenced from the metadata 
    /// tab (but only from other structures) will show up as "non-published". Structure tabs that are 
    /// not reachable by traversing references from one of the published structures will be ignored.
    ///
    /// The name of a Structure is the name of the structure tab.The maximum length of an Excel tab name 
    /// is 31 (go figure). Because an invariant tab will need to be associated with the structure and 
    /// the invariant tab name is "[structureName]-Inv", that means that structure names need to be 27 
    /// characters or less.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.NotAllowed,
        description:
            "(Profile only)" +
            "When defining resources or data types, you'll use the Data Elements tab. When defining profiles, " +
            "you'll use a \"structure\" tab (or possibly several structure tabs). Structures that are " +
            "referenced from the metadata tab (as a \"Published.structure\") will appear as \"published\" " +
            "structures that are externally referencable. Those that are not referenced from the metadata " +
            "tab (but only from other structures) will show up as \"non-published\". Structure tabs that are " +
            "not reachable by traversing references from one of the published structures will be ignored.\n" +
            "\n" +
            "The name of a Structure is the name of the structure tab.The maximum length of an Excel tab name " +
            "is 31 (go figure). Because an invariant tab will need to be associated with the structure and " +
            "the invariant tab name is \"[structureName]-Inv\", that means that structure names need to be 27 " +
            "characters or less."
        )]
    public class TabStructures : CommonElementFields
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// String - optional. This is a unique name within the structure for a particular row. It only 
        /// needs to be populated for rows that are defining a 'slice' (see below) or where the element is 
        /// defining a type whose set of constraints needs to be referenced elsewhere (using the Type column 
        /// with "@"). However, it may also be populated in other circumstances. If code is generated from a 
        /// profile, property names will be taken from the Profile name. For that reason, names need to 
        /// avoid white-space or other characters that would cause code-generation issues.
        /// </summary>
        ///
        /// <value>The name of the profile.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Profile Name",
            displayName: "Profile Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "String - optional. This is a unique name within the structure for a particular row. It only " +
                "needs to be populated for rows that are defining a 'slice' (see below) or where the element is " +
                "defining a type whose set of constraints needs to be referenced elsewhere (using the Type column " +
                "with \"@\"). However, it may also be populated in other circumstances. If code is generated from a " +
                "profile, property names will be taken from the Profile name. For that reason, names need to " +
                "avoid white-space or other characters that would cause code-generation issues."
            )]
        public string ProfileName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// String - conditional. This can only be specified for elements that have a Profile Name. It must 
        /// be specified on the *first* slice for a given element path (unless Slice Description is present). 
        /// E.g. If you were slicing contained observations into three different patterns, the discriminator 
        /// would be declared on the first slice. This defines the slicing rules for all following sibling 
        /// elements with the same path. The column conveys three pieces of information: discriminator path, 
        /// whether slice order matters and the slicing rules. All 3 aspects are separated by "|"
        /// 
        /// - The discriminator path is the relative path from the current element to the descendant element 
        /// that is used to disambiguate between slices.This might be in the same resource or may refer to 
        /// elements within contained elements or even referenced resources.The path is expressed using 
        /// dot-notation.E.g. "related.target.name". If there are multiple values, separate them with ",". 
        /// For guidance on more complex slicing names(e.g.slicing by type or profile, slicing within 
        /// references, etc.), refer to the spec.
        /// 
        /// - The second value is either "true" or "false" with a default of "false". If true, it means 
        /// that in the instance, slices must appear in the order indicated
        /// 
        /// - The final value indicates the rules for slicing.The value may be one of the following:
        /// 
        ///   - open: (default) - indicates that additional repetitions not matching any of the specified 
        ///   slices may be included in the instance or defined in derived profiles
        /// 
        ///   - openAtEnd: The same as open, but any repetitions that don't meet the specified slices must 
        ///   appear after the slices defined in this profile
        /// 
        ///   - closed: Indicates that only the specified slices are permitted. Additional 
        ///   repetitions/down-stream slices are not allowed
        ///   
        /// - E.g. "supportingInformation.type|true|openAtEnd"
        /// </summary>
        ///
        /// <value>The discriminator.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Discriminator",
            displayName: "Discriminator",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "String - conditional. This can only be specified for elements that have a Profile Name. It must " +
                "be specified on the *first* slice for a given element path (unless Slice Description is present). " +
                "E.g. If you were slicing contained observations into three different patterns, the discriminator " +
                "would be declared on the first slice. This defines the slicing rules for all following sibling " +
                "elements with the same path. The column conveys three pieces of information: discriminator path, " +
                "whether slice order matters and the slicing rules. All 3 aspects are separated by \"|\"\n" +
                "\n" +
                "- The discriminator path is the relative path from the current element to the descendant element " +
                "that is used to disambiguate between slices.This might be in the same resource or may refer to " +
                "elements within contained elements or even referenced resources.The path is expressed using " +
                "dot-notation.E.g. \"related.target.name\". If there are multiple values, separate them with \",\". " +
                "For guidance on more complex slicing names(e.g.slicing by type or profile, slicing within " +
                "references, etc.), refer to the spec.\n" +
                "\n" +
                "- The second value is either \"true\" or \"false\" with a default of \"false\". If true, it means " +
                "that in the instance, slices must appear in the order indicated\n" +
                "\n" +
                "- The final value indicates the rules for slicing.The value may be one of the following:\n" +
                "\n" +
                "  - open: (default) - indicates that additional repetitions not matching any of the specified " +
                "  slices may be included in the instance or defined in derived profiles\n" +
                "\n" +
                "  - openAtEnd: The same as open, but any repetitions that don't meet the specified slices must " +
                "  appear after the slices defined in this profile\n" +
                "\n" +
                "  - closed: Indicates that only the specified slices are permitted. Additional " +
                "  repetitions/down-stream slices are not allowed\n" +
                "\n" +
                "- E.g. \"supportingInformation.type|true|openAtEnd\"" 
            )]
        public string Discriminator { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional. This must be present if slicing and Discriminator isn't specified
        /// </summary>
        ///
        /// <value>Information describing the slice.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Slice Description",
            displayName: "Slice Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional. This must be present if slicing and Discriminator isn't specified"
            )]
        public string SliceDescription { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This can be either "Y" or "N". Default is "N". A "Y" indicates that systems that claim to 
        /// conform to the profile structure must "support" the data element - the precise meaning of 
        /// "support" (for both clients and servers) should be defined by the narrative of the profile.
        /// </summary>
        ///
        /// <value>The must support.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Must Support",
            displayName: "Must Support",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This can be either \"Y\" or \"N\". Default is \"N\". A \"Y\" indicates that systems that claim to " +
                "conform to the profile structure must \"support\" the data element - the precise meaning of " +
                "\"support\" (for both clients and servers) should be defined by the narrative of the profile."
            )]
        public bool? MustSupport { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This specifies a fixed value for the element. It may be declared for both simple and complex 
        /// types. For complex types, the value must be declared as inline XML. Note that the expectation is 
        /// that valid instances will match the specified XML exactly (no extra elements, extensions or 
        /// properties.)
        /// 
        /// - E.g. for complex type codeableConcept element 
        /// "<element><coding><system value="system URL"/><version value="ver"/><display value="display"/></coding></element>"
        /// </summary>
        ///
        /// <value>The fixed value.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Value",
            displayName: "Fixed Value",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This specifies a fixed value for the element. It may be declared for both simple and complex " +
                "types. For complex types, the value must be declared as inline XML. Note that the expectation is " +
                "that valid instances will match the specified XML exactly (no extra elements, extensions or " +
                "properties.)\n" +
                "\n" +
                "- E.g. for complex type codeableConcept element " +
                "\"<element>" +
                    "<coding>" +
                        "<system value=\"system URL\"/>" +
                        "<version value=\"ver\"/>" +
                        "<display value=\"display\"/>" +
                    "</coding>" +
                "</element>\""
            )]
        public string FixedValue { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This specifies a set of elements and values that must be present in the instance. It should 
        /// only be present for complex data types and is expressed as XML. Additional elements and values 
        /// not specified in the pattern are still permitted.
        /// </summary>
        ///
        /// <value>The pattern.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Pattern",
            displayName: "Pattern",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This specifies a set of elements and values that must be present in the instance. It should " +
                "only be present for complex data types and is expressed as XML. Additional elements and values " +
                "not specified in the pattern are still permitted."
            )]
        public string Pattern { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates the minimum length that must be supported by all implementers using the element (and 
        /// thus the maximum length that can be safely exchanged).
        /// </summary>
        ///
        /// <value>The maximum length of the.</value>
        ///-------------------------------------------------------------------------------------------------
        
        [ExcelField(
            fieldName: "Max Length",
            displayName: "Max Length",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Indicates the minimum length that must be supported by all implementers using the element (and " +
                "thus the maximum length that can be safely exchanged)."
            )]
        public int? MaxLength { get; set; }
    }
}
