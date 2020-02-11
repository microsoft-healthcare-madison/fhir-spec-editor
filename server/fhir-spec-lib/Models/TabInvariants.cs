using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// This tab defines constraints that apply to a resource (or to one of the structures defined 
    /// within a profile. All constraints defined must be evaluatable within the context of the instance, 
    /// not taking into account any external state information (date, previously received data, other 
    /// resources, etc.)
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "This tab defines constraints that apply to a resource (or to one of the structures defined " +
            "within a profile. All constraints defined must be evaluatable within the context of the instance, " +
            "not taking into account any external state information (date, previously received data, other " +
            "resources, etc.)"
        )]
    public class TabInvariants : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is a unique identifier for the constraint within the Resource/Data Type/Profile. It is used 
        /// to reference the constraint from data elements whose appearance is controlled by the 
        /// constraint (if any).
        /// </summary>
        ///
        /// <value>The identifier.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Id",
            displayName: "Invariant ID",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This is a unique identifier for the constraint within the Resource/Data Type/Profile. It is used " +
                "to reference the constraint from data elements whose appearance is controlled by the " +
                "constraint (if any)."
            )]
        public string Id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is a short descriptive name for the constraint. It is used in OCL, Schematron and certain 
        /// other technologies to display information about the constraint
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Short Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This is a short descriptive name for the constraint. It is used in OCL, Schematron and certain " +
                "other technologies to display information about the constraint"
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// 'error', 'warning' or 'best-practice' (the latter being a specialized type of warning)
        /// </summary>
        ///
        /// <value>The severity.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Severity",
            displayName: "Failure Severity",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "'error', 'warning' or 'best-practice' (the latter being a specialized type of warning)"
            )]
        public string Severity { get; set; }

        public const string SeverityError = "error";
        public const string SeverityWarning = "warning";
        public const string SeverityBestPractice = "best-practice";

        public static readonly string[] Serverities =
        {
            SeverityBestPractice,
            SeverityError,
            SeverityWarning
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This indicates the scope (or scopes) in which the constraint should be applied. For data types 
        /// or resources, this should be the full element path name. E.g. Patient.contact.name. For 
        /// extensions, this should be the full URI of the extension (i.e. the base URI + "#" plus the 
        /// extension code.) The context determines what the root node is when evaluating the formal 
        /// expression of the constraint.
        /// </summary>
        ///
        /// <value>The context.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Context",
            displayName: "Context",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This indicates the scope (or scopes) in which the constraint should be applied. For data types " +
                "or resources, this should be the full element path name. E.g. Patient.contact.name. For " +
                "extensions, this should be the full URI of the extension (i.e. the base URI + \"#\" plus the " +
                "extension code.) The context determines what the root node is when evaluating the formal " +
                "expression of the constraint."
            )]
        public string Context { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is the human-friendly expression of the constraint. It should ideally be appropriate to 
        /// expose to the end-user (human) of an interacting system.
        /// </summary>
        ///
        /// <value>The human-friendly expression of the constraint.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "English",
            displayName: "Constraint Description",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "This is the human-friendly expression of the constraint. It should ideally be appropriate to " +
                "expose to the end-user (human) of an interacting system."
            )]
        public string Description { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is required for "best-practice" invariants. It indicates the rationale for the rule
        /// </summary>
        ///
        /// <value>The explanation.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Explanation",
            displayName: "Explanation (rationale)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "This is required for \"best - practice-\" invariants. It indicates the rationale for the rule"
            )]
        public string Explanation { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// This is the FHIRPath representation of the constraint. (Required)
        /// </summary>
        ///
        /// <value>The FHIRPath representation of this constraint.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Expression",
            displayName: "FHIRPath Expression",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "This is the FHIRPath representation of the constraint. (Required)"
            )]
        public string FhirPathExpression { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// (Optional)This is the formal expression of the constraint expressed using XPath 2.0. There are 
        /// two namespace prefixes defined: "f:" for fhir and "h:" for xhtml. If you're not familiar with 
        /// XPath 2, ask Lloyd to write it for you . . .
        /// </summary>
        ///
        /// <value>The XPath representation of this constraint.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "XPath",
            displayName: "XPath 2.0 Expression",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "(Optional)This is the formal expression of the constraint expressed using XPath 2.0. There are " +
                "two namespace prefixes defined: \"f:\" for fhir and \"h:\" for xhtml. If you're not familiar with " +
                "XPath 2, ask Lloyd to write it for you . . ."
            )]
        public string XPath { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// (Optional) This indicates an expression of the constraint using the OCL language
        /// </summary>
        ///
        /// <value>The OCL representation of this constraint</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "OCL",
            displayName: "OCL",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "(Optional) This indicates an expression of the constraint using the OCL language"
            )]
        public string OCL { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// (Optional) This indicates an expression of the constraint using RDF
        /// </summary>
        ///
        /// <value>The RDF representation of this constraint.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "RDF",
            displayName: "RDF",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "(Optional) This indicates an expression of the constraint using RDF"
            )]
        public string RDF { get; set; }
    }
}