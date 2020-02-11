using fhir_spec_lib.IO;
using fhir_spec_lib.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace fhir_spec_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Change to command line parsing

            string fhirRootDir = "c:\\git\\fhir";

            string fhirSourceDir = Path.Combine(fhirRootDir, "source");

            // **** load the XMLs ****

            LoadAllXmls(fhirSourceDir);
        }

        static void LoadAllXmls(string sourceDir)
        {
            // **** make sure the source directory exists ****

            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine($"Source Directory not found! {sourceDir}");
                return;
            }

            string[] excludedDirectories =
            {
                Path.Combine(sourceDir, "templates")
            };

            // **** traverse the XML files in the datatypes directory (exclude primitives) ****

            string[] files = Directory.GetFiles(sourceDir, "*-spreadsheet.xml", SearchOption.AllDirectories);

            bool skipping = false;

            int fileIndex = 0;
            for (fileIndex = 0; fileIndex < files.Length; fileIndex++)
            {
                string filename = files[fileIndex];

                // **** check for files with required orders ****

                if (filename.StartsWith(excludedDirectories[0]))
                {
                    // **** skip ****

                    continue;
                }

                // **** load this XML ****

                LoadXml(
                    filename, 
                    fileIndex,
                    out int knownTabCount,
                    out int unknownTabCount,
                    out int ignoredTabCount
                    );

                if (unknownTabCount > 0)
                {
                    skipping = false;
                }

                // **** check for continue ****

                bool done = false;
                while ((!done) & (!skipping))
                {
                    string input = Console.ReadLine();

                    if (input.Length == 0)
                    {
                        done = true;
                        continue;
                    }

                    switch (input[0])
                    {
                        case 'o':
                        case 'O':

                            // **** open in Excel ****

                            Process process = new Process();
                            process.StartInfo.FileName = "excel";
                            process.StartInfo.Arguments = filename;
                            process.StartInfo.CreateNoWindow = false;
                            process.StartInfo.UseShellExecute = true;
                            process.Start();

                            break;

                        case 'p':
                        case 'P':
                            fileIndex -= 2;
                            done = true;
                            break;

                        case '#':
                            done = int.TryParse(input.Substring(1), out fileIndex);
                            break;

                        case 'r':
                        case 'R':
                            fileIndex--;
                            done = true;
                            break;

                        case 's':
                        case 'S':
                            skipping = true;
                            done = true;
                            break;

                        default:

                            done = true;
                            break;
                    }
                }
            }
        }

        static void LoadXml(
                            string xmlFilename, 
                            int index, 
                            out int knownTabCount, 
                            out int unknownTabCount,
                            out int ignoredTabCount
                            )
        {
            // **** tell the user what's going on ****

            Console.WriteLine($"#{index, -4} - {xmlFilename}");

            // **** ****

            if (!ExcelXmlReader.ParseFile(xmlFilename, out DataSet ds, true, true))
            {
                Console.WriteLine($"Failed to parse the file: {xmlFilename}.");

                // **** nothing else to do ****

                knownTabCount = 0;
                unknownTabCount = 0;
                ignoredTabCount = 0;

                return;
            }

            // **** create our spreadsheet object ****

            FhirSpreadsheet sheet = new FhirSpreadsheet(xmlFilename, ds);

            knownTabCount = sheet.KnownTabs.Count;
            unknownTabCount = sheet.UnknownTabs.Count;
            ignoredTabCount = sheet.IgnoredTabs.Count;
        }
    }
}
