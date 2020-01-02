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

    public class TabOperations
    {
        public string Name { get; set; }

        public string Use { get; set; }

        public const string UseSystem = "system";
        public const string UseType = "type";
        public const string UseInstance = "instance";

        public string OperationType { get; set; }

        public string Title { get; set; }

        public string Documentation { get; set; }

        public string Footer { get; set; }


        public List<OperationParameter> Parameters { get; set; }

    }
}
