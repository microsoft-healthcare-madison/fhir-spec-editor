using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// In case the Binding is of type "code list", the column "Reference" must contain the name of 
    /// another tab containing the valueset for this binding, prefixed by '#'.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/10/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "CodeList",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "In case the Binding is of type \"code list\", the column \"Reference\" must contain the name of " +
            "another tab containing the valueset for this binding, prefixed by '#'."
        )]
    public class TabCodeList : ExcelTabBase
    {
        /// <summary>The property attributes.</summary>
        public static Dictionary<string, ExcelFieldAttribute> PropertyAttributesDict;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string - the code that identifies the concept
        /// </summary>
        ///
        /// <value>The code.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Code",
            displayName: "Code",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "a string - the code that identifies the concept"
            )]
        public string Code { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - a number - used for internal references to create subsumption heirarchies.
        /// </summary>
        ///
        /// <value>The identifier.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Id",
            displayName: "Id",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - a number - used for internal references to create subsumption heirarchies."
            )]
        public string Id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - a string - used to refer to codes from external systems (use the URI published in the 
        /// FHIR ballot. if the URI is not published, consult the core project team).
        /// note: provide either an ID or a system, but not both
        /// </summary>
        ///
        /// <value>The external system.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "System",
            displayName: "External System",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - a string - used to refer to codes from external systems (use the URI published in the " +
                "FHIR ballot. if the URI is not published, consult the core project team)." +
                "note: provide either an ID or a system, but not both"
            )]
        public string ExternalSystem { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string - expressed as "#" followed by the Id value of the code that is the parent of this code 
        /// (i.e. whose meaning encompasses the meaning of this code)
        /// </summary>
        ///
        /// <value>The parent.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Parent",
            displayName: "Parent Code ID",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "a string - expressed as \"#\" followed by the Id value of the code that is the parent of this code" +
                "(i.e. whose meaning encompasses the meaning of this code)"
            )]
        public string Parent { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string to display this concept to a user. If the code is external, you *should* provide a 
        /// display so the publishing tools can publish one for user convenience
        /// </summary>
        ///
        /// <value>The display.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Display",
            displayName: "Display (description)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "a string to display this concept to a user. If the code is external, you *should* provide a " +
                "display so the publishing tools can publish one for user convenience"
            )]
        public string Display { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string - mandatory if the code is an internal code. Recommended if the code is external, so 
        /// the tools can publish it for use convenience.
        /// </summary>
        ///
        /// <value>The definition.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Definition",
            displayName: "Definition",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "a string - mandatory if the code is an internal code. Recommended if the code is external, so " +
                "the tools can publish it for use convenience."
            )]
        public string Definition { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// v2 and v3 - v2 and v3 mappings, if there are mappings defined in the bindings tab (else ignored)
        /// 
        /// - the syntax consists of a set of map statements, separated by "," (no spaces)
        /// 
        /// - a map statement consists of a single character equivalence, then the table number of code 
        ///   system name, then a ".", and then the code, optionally with a comment in brackets following
        /// 
        /// - the equivalent character is "=" - exact. "~" - equivalent. ">" - narrower(i.e. the v2/v3 code 
        ///   is narrower than the FHIR code). "<" - wider
        ///   
        /// - e.g. ~0190.H - this code is equivalent to "H" in table 0190
        /// 
        /// - e.g. >EntityNameUse.BAD(not sure about old) - this code maps to "BAD" in EntityNameUse, but 
        ///   the definition of "BAD" is narrower.the comment is an explanation of the issue (probably 
        ///   shouldn't be as cryptic as this comment). When you use the equivalence "<", you must make a 
        ///   comment
        /// </summary>
        ///
        /// <value>The v2.</value>
        ///-------------------------------------------------------------------------------------------------

       [ExcelField(
            fieldName: "V2",
            displayName: "V2 Mapping",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "v2 and v3 - v2 and v3 mappings, if there are mappings defined in the bindings tab (else ignored)\n" +
                "\n" +
                "- the syntax consists of a set of map statements, separated by \",\" (no spaces)\n" +
                "\n" +
                "- a map statement consists of a single character equivalence, then the table number of code " +
                "  system name, then a \".\", and then the code, optionally with a comment in brackets following\n" +
                "\n" +
                "- the equivalent character is \"=\" - exact. \"~\" - equivalent. \">\" - narrower(i.e. the v2/v3 code " +
                "  is narrower than the FHIR code). \"<\" - wider\n" +
                "\n" +
                "- e.g. ~0190.H - this code is equivalent to \"H\" in table 0190\n" +
                "\n" +
                "- e.g. >EntityNameUse.BAD(not sure about old) - this code maps to \"BAD\" in EntityNameUse, but " +
                "  the definition of \"BAD\" is narrower.the comment is an explanation of the issue (probably " +
                "  shouldn't be as cryptic as this comment). When you use the equivalence \"<\", you must make a " +
                "  comment"
            )]
        public string V2 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// v2 and v3 - v2 and v3 mappings, if there are mappings defined in the bindings tab (else ignored)
        /// 
        /// - the syntax consists of a set of map statements, separated by "," (no spaces)
        /// 
        /// - a map statement consists of a single character equivalence, then the table number of code 
        ///   system name, then a ".", and then the code, optionally with a comment in brackets following
        /// 
        /// - the equivalent character is "=" - exact. "~" - equivalent. ">" - narrower(i.e. the v2/v3 code 
        ///   is narrower than the FHIR code). "<" - wider
        ///   
        /// - e.g. ~0190.H - this code is equivalent to "H" in table 0190
        /// 
        /// - e.g. >EntityNameUse.BAD(not sure about old) - this code maps to "BAD" in EntityNameUse, but 
        ///   the definition of "BAD" is narrower.the comment is an explanation of the issue (probably 
        ///   shouldn't be as cryptic as this comment). When you use the equivalence "<", you must make a 
        ///   comment
        /// </summary>
        ///
        /// <value>The v3.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "V3",
            displayName: "V3 Mapping",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "v2 and v3 - v2 and v3 mappings, if there are mappings defined in the bindings tab (else ignored)\n" +
                "\n" +
                "- the syntax consists of a set of map statements, separated by \",\" (no spaces)\n" +
                "\n" +
                "- a map statement consists of a single character equivalence, then the table number of code " +
                "  system name, then a \".\", and then the code, optionally with a comment in brackets following\n" +
                "\n" +
                "- the equivalent character is \"=\" - exact. \"~\" - equivalent. \">\" - narrower(i.e. the v2/v3 code " +
                "  is narrower than the FHIR code). \"<\" - wider\n" +
                "\n" +
                "- e.g. ~0190.H - this code is equivalent to \"H\" in table 0190\n" +
                "\n" +
                "- e.g. >EntityNameUse.BAD(not sure about old) - this code maps to \"BAD\" in EntityNameUse, but " +
                "  the definition of \"BAD\" is narrower.the comment is an explanation of the issue (probably " +
                "  shouldn't be as cryptic as this comment). When you use the equivalence \"<\", you must make a " +
                "  comment"
            )]
        public string V3 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// a string - optional. usage guidance..
        /// </summary>
        ///
        /// <value>The committe notes.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Committee Notes",
            displayName: "Committee Notes",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "a string - optional. usage guidance.."
            )]
        public string CommitteNotes { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// any column with a title starting with "Display:" must have a ISO language code in the title - 
        /// e.g. "Display:fr", and a french equivalent for the Display in the cell for each code
        /// </summary>
        ///
        /// <value>The display translations.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Display:*",
            displayName: "Display (Translated):*",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Any column with a title starting with \"Display:\" must have a ISO language code in the title - " +
                "e.g. \"Display:fr\", and a french equivalent for the Display in the cell for each code"
            )]
        public List<string> DisplayTranslations { get; set; }
    }
}
