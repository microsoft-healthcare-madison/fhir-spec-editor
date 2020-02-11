using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Attributes
{

    ///-------------------------------------------------------------------------------------------------
    /// <summary>Attribute for spreadsheet page.</summary>
    ///
    /// <remarks>Gino Canessa, 12/30/2019.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class ExcelTabAttribute : System.Attribute
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>Values that represent field name structures.</summary>
        ///
        /// <remarks>Gino Canessa, 1/2/2020.</remarks>
        ///-------------------------------------------------------------------------------------------------

        public enum FieldNameStructures
        {
            Columns,
            NameValueRows
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Values that represent page allowed levels.</summary>
        ///
        /// <remarks>Gino Canessa, 1/2/2020.</remarks>
        ///-------------------------------------------------------------------------------------------------

        public enum PageAllowedLevels
        {
            NotAllowed,
            Allowed,
            Required
        }

        public string pageName;
        public FieldNameStructures fieldStructure;

        PageAllowedLevels allowedForProfile;
        PageAllowedLevels allowedForResource;
        PageAllowedLevels allowedForDataType;

        public string description;


        ///-------------------------------------------------------------------------------------------------
        /// <summary>Constructor.</summary>
        ///
        /// <remarks>Gino Canessa, 1/2/2020.</remarks>
        ///
        /// <param name="pageName">          Name of the page.</param>
        /// <param name="fieldStructure">    The field structure.</param>
        /// <param name="allowedForProfile"> The allowed for profile.</param>
        /// <param name="allowedForResource">The allowed for resource.</param>
        /// <param name="allowedForDataType">Type of the allowed for data.</param>
        ///-------------------------------------------------------------------------------------------------

        public ExcelTabAttribute(
                                        string pageName,
                                        FieldNameStructures fieldStructure,
                                        PageAllowedLevels allowedForProfile,
                                        PageAllowedLevels allowedForResource,
                                        PageAllowedLevels allowedForDataType,
                                        string description
                                        )
        {
            this.pageName = pageName;
            this.fieldStructure = fieldStructure;
            this.allowedForProfile = allowedForProfile;
            this.allowedForResource = allowedForResource;
            this.allowedForDataType = allowedForDataType;
            this.description = description;
        }
    }
}
