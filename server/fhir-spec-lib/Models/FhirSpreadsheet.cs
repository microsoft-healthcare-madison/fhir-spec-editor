using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
        #region Class Constants . . .

        private static readonly HashSet<string> _ignoredTabs = new HashSet<string>()
        {
            "Instructions",
            "Removed Elements",
            "SomeStructure",
            "SomeStructure-Inv",
            //"Definition-Inv",
            "some-code-list",
            "some-code-list (2)",
        };

        #endregion Class Constants . . .

        #region Class Enums . . .

        public enum SpreadsheetTypes
        {
            DataType,
            Resource,
            Profile
        }

        #endregion Class Enums . . .


        #region Class Variables . . .

        #endregion Class Variables . . .

        #region Instance Variables . . .

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the filename of the file.</summary>
        ///
        /// <value>The filename.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Filename { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the set the loaded data belongs to.</summary>
        ///
        /// <value>The loaded data set.</value>
        ///-------------------------------------------------------------------------------------------------

        public DataSet LoadedDataSet { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the known tabs.</summary>
        ///
        /// <value>The known tabs.</value>
        ///-------------------------------------------------------------------------------------------------

        public HashSet<string> KnownTabs { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the unknown tabs.</summary>
        ///
        /// <value>The unknown tabs.</value>
        ///-------------------------------------------------------------------------------------------------

        public HashSet<string> UnknownTabs { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the ignored tabs.</summary>
        ///
        /// <value>The ignored tabs.</value>
        ///-------------------------------------------------------------------------------------------------

        public HashSet<string> IgnoredTabs { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the type of the spreadsheet.</summary>
        ///
        /// <value>The type of the spreadsheet.</value>
        ///-------------------------------------------------------------------------------------------------

        public SpreadsheetTypes SpreadsheetType { get; set; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the maturity level.</summary>
        ///
        /// <value>The maturity level.</value>
        ///-------------------------------------------------------------------------------------------------

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

        #endregion Instance Variables . . .

        #region Constructors . . .

        static FhirSpreadsheet()
        {
            ExcelTabBase.LoadProps();
        }

        public FhirSpreadsheet(string filename, DataSet ds)
        {

            // **** set fields from parameters ****

            Filename = filename;
            LoadedDataSet = ds;

            // **** ****

            KnownTabs = new HashSet<string>();
            UnknownTabs = new HashSet<string>();
            IgnoredTabs = new HashSet<string>();

            // **** traverse all the tabs ****

            foreach (DataTable dt in ds.Tables)
            {
                if (string.IsNullOrEmpty(dt.TableName))
                {
                    continue;
                }

                if (_ignoredTabs.Contains(dt.TableName))
                {
                    IgnoredTabs.Add(dt.TableName);
                    continue;
                }

                // **** act depending on name ****

                switch (dt.TableName)
                {
                    case "Bindings":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Data Elements":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Events":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Examples":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Extensions":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Instructions":
                        UnknownTabs.Add(dt.TableName);
                        break;

                    case "Invariants":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Metadata":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Operations":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Profiles":
                        KnownTabs.Add(dt.TableName);
                        break;

                    case "Search":
                        KnownTabs.Add(dt.TableName);
                        break;

                    default:
                        
                        // **** check for invariants tab ****

                        if ((dt.TableName.EndsWith("-Inv")) &&
                            (TabInvariants.TableIsCompatible(dt)))
                        {
                            // **** test for invariants tab ****

                            KnownTabs.Add(dt.TableName);
                        }
                        else if ((dt.TableName.EndsWith("-search")) &&
                                 (TabSearch.TableIsCompatible(dt)))
                        {
                            // **** test for search tab ****

                            KnownTabs.Add(dt.TableName);
                        }
                        else if ((char.IsLower(dt.TableName[0])) &&
                                 (TabCodeList.TableIsCompatible(dt)))
                        {
                            // **** test for code list tab ***

                            KnownTabs.Add(dt.TableName);
                        }
                        else if ((char.IsUpper(dt.TableName[0])) &&
                                 (TabProfiles.TableIsCompatible(dt)))
                        {
                            // **** test for profile tab ****

                            KnownTabs.Add(dt.TableName);
                        }
                        else
                        {
                            UnknownTabs.Add(dt.TableName);
                        }

                        break;
                }
            }

            // **** tell the user what's going on ****

            DumpTabs();
        }

        #endregion Constructors . . .

        #region Class Interface . . .

        #endregion Class Interface . . .

        #region Instance Interface . . .

        #endregion Instance Interface . . .

        #region Internal Functions . . .

        private void DumpTabs()
        {
            Console.WriteLine(
                $"---------------  Known  Tabs ---------------|" +
                $"--------------- UNKNOWN Tabs ---------------|" +
                $"--------------- Ignored Tabs ---------------"
                );

            List<string> knownTabs = KnownTabs.ToList<string>();
            List<string> unknownTabs = UnknownTabs.ToList<string>();
            List<string> ignoredTabs = IgnoredTabs.ToList<string>();

            // **** sort the tab lists ****

            knownTabs.Sort();
            unknownTabs.Sort();
            ignoredTabs.Sort();

            int rowCount = Math.Max(knownTabs.Count, unknownTabs.Count);
            rowCount = Math.Max(rowCount, ignoredTabs.Count);

            string known;
            string unknown;
            string ignored;

            for (int i = 0; i < rowCount; i++)
            {
                known = i < knownTabs.Count ? knownTabs[i] : "";
                unknown = i < unknownTabs.Count ? unknownTabs[i] : "";
                ignored = i < ignoredTabs.Count ? ignoredTabs[i] : "";

                Console.WriteLine($" {known, -43}| {unknown, -43}| {ignored, -43}");
            }
        }

        #endregion Internal Functions . . .

    }
}
