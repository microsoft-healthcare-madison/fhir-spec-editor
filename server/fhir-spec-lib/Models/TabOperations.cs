using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// The Operations tab defines operations related to the resource as well as their parameters.
    ///
    /// The rows of this tab are used for both defining operations as well as parameters.The first row 
    /// (below the heading row) must define an operation. Subsequent rows define the parameters for that 
    /// operation. Then a second operation can be defined, etc.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Operations",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "The Operations tab defines operations related to the resource as well as their parameters.\n" +
            "\n" +
            "The rows of this tab are used for both defining operations as well as parameters.The first row " +
            "(below the heading row) must define an operation. Subsequent rows define the parameters for that " +
            "operation. Then a second operation can be defined, etc."
        )]
    public class TabOperations : ExcelTabBase
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the operations.</summary>
        ///
        /// <value>The operations.</value>
        ///-------------------------------------------------------------------------------------------------

        public Dictionary<OperationDefinition, List<OperationParameter>> OperationDefinitions { get; set; }
    }
}
