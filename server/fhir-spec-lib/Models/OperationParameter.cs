using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    public class OperationParameter
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - The name of a particular operation parameter. This is expressed as the name of the 
        /// operation followed by "." followed by the parameter name. Parameter names must be tokens 
        /// starting with a lower-case character
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Parameter Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - The name of a particular operation parameter. This is expressed as the name of the " +
                "operation followed by \".\" followed by the parameter name. Parameter names must be tokens " +
                "starting with a lower-case character"
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - Must be "in" for input parameters and "out" for output parameters.
        /// </summary>
        ///
        /// <value>The use.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Use",
            displayName: "Parameter Use (direction)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - Must be \"in\" for input parameters and \"out\" for output parameters."
            )]
        public string ParameterUse { get; set; }

        public const string UseIn = "in";
        public const string UseOut = "out";

        public static readonly string[] ParameterUses =
        {
            UseIn,
            UseOut
        };

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - A non-negative integer indicating the minimum number of repetitions for the parameter 
        /// (as input or output).
        /// </summary>
        ///
        /// <value>The minimum value.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Min",
            displayName: "Min",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - A non-negative integer indicating the minimum number of repetitions for the parameter " +
                "(as input or output)."
            )]
        public int Min { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - Either "*" or a positive integer indicating the maximum number of repetitions for the 
        /// parameter (as input or output)
        /// </summary>
        ///
        /// <value>The maximum value.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Max",
            displayName: "Max",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - Either \"*\" or a positive integer indicating the maximum number of repetitions for the " +
                "parameter (as input or output)"
            )]
        public int? Max { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - Indicates the FHIR data type or search type associated with the parameter (can also 
        /// be "Resource(xxx|yyy|etc.)").
        /// </summary>
        ///
        /// <value>The type of the parameter.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Type",
            displayName: "Parameter Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - Indicates the FHIR data type or search type associated with the parameter (can also " +
                "be \"Resource(xxx|yyy|etc.)\")."
            )]
        public string ParameterType { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// The full URL of the profile that applies to the parameter.
        /// </summary>
        ///
        /// <value>The profile.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Profile",
            displayName: "Profile URL",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "The full URL of the profile that applies to the parameter."
            )]
        public Uri Profile { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// An explanation of the intended content of the parameter. This element may be expressed using 
        /// MarkDown to allow hyperlinking to other elements in the specification, including bullets and 
        /// other formatting.
        /// </summary>
        ///
        /// <value>The documentation.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Documentation",
            displayName: "Documentation",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "An explanation of the intended content of the parameter. This element may be expressed using " +
                "MarkDown to allow hyperlinking to other elements in the specification, including bullets and " +
                "other formatting."
            )]
        public string Documentation { get; set; }
    }
}
