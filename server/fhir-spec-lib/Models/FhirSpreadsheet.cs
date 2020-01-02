using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>A FHIR spreadsheet.</summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    public class FhirSpreadsheet
    {
        public enum SpreadsheetTypes
        {
            DataType,
            Resource,
            Profile
        }

        public SpreadsheetTypes SpreadsheetType { get; set; }

        public string Filename { get; set; }

        public int MaturityLevel { get; set; }


        public TabMetadata Metadata { get; set; }

        // TODO: move into UI
        /////-------------------------------------------------------------------------------------------------
        ///// <summary>Set containing the names of fields show/used within the Metadata sheet</summary>
        /////
        ///// <value>The metadata fields.</value>
        /////-------------------------------------------------------------------------------------------------

        //public HashSet<string> MetadataFields { get; set; }


        public TabDataElements DataElements { get; set; }

        // TODO: move into UI
        /////-------------------------------------------------------------------------------------------------
        ///// <summary>Set containing the names of fields shown/used within the DataElements sheet</summary>
        /////
        ///// <value>The data element fields.</value>
        /////-------------------------------------------------------------------------------------------------

        //public HashSet<string> DataElementFields { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>List of other mappings and their definitions - values are in 
        /// DataElements.OtherMappings[name]</summary>
        ///
        /// <value>The data element additional mappings.</value>
        ///-------------------------------------------------------------------------------------------------

        public List<DataElementMappingColumn> DataElementOtherMappings { get; set; }


        public Dictionary<string, TabStructures> Structures { get; set; }


        public Dictionary<string, TabInvariants> Invariants { get; set; }

    }
}
