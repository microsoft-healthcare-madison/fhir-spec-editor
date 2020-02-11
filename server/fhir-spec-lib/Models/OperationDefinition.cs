using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    public class  OperationDefinition
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - The name of the operation (the name by which it will be invoked). Must be a token, 
        /// starting with a lower-case letter.
        /// </summary>
        ///
        /// <value>The name.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Name",
            displayName: "Operation Name",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - The name of the operation (the name by which it will be invoked). Must be a token, " +
                "starting with a lower-case letter."
            )]
        public string Name { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - One or more of the following values, if more than one, separate with vertical bars "|".
        /// - system:   The operation can be invoked at the system level, independent of any particular resource
        /// - type:     The operation can be invoked at the level of a resource type, independent of a specific resource instance
        /// - instance: The operation can be invoked on a specific resource instance.
        /// </summary>
        ///
        /// <value>The use.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Use",
            displayName: "Operation Use (level)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - One or more of the following values, if more than one, separate with vertical bars \"|\"." +
                "- system:   The operation can be invoked at the system level, independent of any particular resource" +
                "- type:     The operation can be invoked at the level of a resource type, independent of a specific resource instance" +
                "- instance: The operation can be invoked on a specific resource instance."
            )]
        public string OperationUse { get; set; }

        public const string UseSystem = "system";
        public const string UseType = "type";
        public const string UseInstance = "instance";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - Either "query" if the operation is a named query or "operation" if it is another type 
        /// of operation. (Refer to the OperationDefinition resource for further explanation.)
        /// </summary>
        ///
        /// <value>The type of the operation.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Type",
            displayName: "Operation Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - Either \"query\" if the operation is a named query or \"operation\" if it is another type " +
                "of operation. (Refer to the OperationDefinition resource for further explanation.)"
            )]
        public string OperationType { get; set; }

        public const string OperationTypeQuery = "query";
        public const string OperationTypeOperation = "operation";

        public static readonly string[] OperationTypes =
        {
            OperationTypeQuery,
            OperationTypeOperation
        };
        
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - The descriptive name for the operation - how it's described in the spec.
        /// </summary>
        ///
        /// <value>The title.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Title",
            displayName: "Title",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - The descriptive name for the operation - how it's described in the spec."
            )]
        public string Title { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required - detailed description of how the operation functions. This element may be expressed 
        /// using mark down to allow hyperlinking to other elements in the specification, including bullets 
        /// and other formatting.
        /// </summary>
        ///
        /// <value>The documentation.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Documentation",
            displayName: "Documentation",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required - detailed description of how the operation functions. This element may be expressed " +
                "using MarkDown to allow hyperlinking to other elements in the specification, including bullets " +
                "and other formatting."
            )]
        public string Documentation { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - Additional information about how the operation is to be used (will appear in the 
        /// publication after the formal definition of the operation). This element may be expressed using 
        /// MarkDown to allow hyperlinking to other elements in the specification, including bullets and 
        /// other formatting.
        /// </summary>
        ///
        /// <value>The footer.</value>
        ///-------------------------------------------------------------------------------------------------

        [ExcelField(
            fieldName: "Footer",
            displayName: "Footer",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - Additional information about how the operation is to be used (will appear in the " +
                "publication after the formal definition of the operation). This element may be expressed using " +
                "MarkDown to allow hyperlinking to other elements in the specification, including bullets and " +
                "other formatting."
            )]
        public string Footer { get; set; }

    }
}
