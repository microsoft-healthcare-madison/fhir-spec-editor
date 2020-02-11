using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace fhir_spec_lib.Models
{
    public class ExcelTabBase
    {
        /// <summary>The property attributes.</summary>
        public static Dictionary<string, ExcelFieldAttribute> PropertyAttributesDict;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Table is compatible.</summary>
        ///
        /// <remarks>Gino Canessa, 1/16/2020.</remarks>
        ///
        /// <param name="dt">The dt.</param>
        ///
        /// <returns>True if it succeeds, false if it fails.</returns>
        ///-------------------------------------------------------------------------------------------------

        public static bool TableIsCompatible(DataTable dt)
        {
            // **** traverse the properties we know about ****

            foreach (KeyValuePair<string, ExcelFieldAttribute> kvp in PropertyAttributesDict)
            {
                // **** check if this is required ****

                if (kvp.Value.required == ExcelFieldAttribute.FieldRequiredLevels.Required)
                {
                    // **** check for this field in the table ****

                    if (!dt.Columns.Contains(kvp.Value.fieldName))
                    {
                        Console.WriteLine($"Table: {dt.TableName} is missing field: {kvp.Value.fieldName}");
                        return false;
                    }
                }
            }

            // **** still here means all required fields were found ****

            return true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Loads the properties.</summary>
        ///
        /// <remarks>Gino Canessa, 1/16/2020.</remarks>
        ///-------------------------------------------------------------------------------------------------

        public static void LoadProps()
        {
            TabBindings.PropertyAttributesDict = TabBindings.GetPropsDict<TabBindings>();
            TabCodeList.PropertyAttributesDict = TabCodeList.GetPropsDict<TabCodeList>();
            TabDataElements.GetPropsDict<TabDataElements>();
            TabEvents.GetPropsDict<TabEvents>();
            TabExamples.GetPropsDict<TabExamples>();
            TabExtensions.GetPropsDict<TabExtensions>();
            TabInvariants.GetPropsDict<TabInvariants>();
            TabMetadata.GetPropsDict<TabMetadata>();
            TabOperations.GetPropsDict<TabOperations>();
            TabPackages.GetPropsDict<TabPackages>();
            TabSearch.GetPropsDict<TabSearch>();
            TabStructures.GetPropsDict<TabStructures>();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Loads properties dictionary.</summary>
        ///
        /// <remarks>Gino Canessa, 1/16/2020.</remarks>
        ///
        /// <typeparam name="T">Generic type parameter.</typeparam>
        ///-------------------------------------------------------------------------------------------------

        internal static Dictionary<string, ExcelFieldAttribute> GetPropsDict<T>()
        {
            Dictionary<string, ExcelFieldAttribute> dict = new Dictionary<string, ExcelFieldAttribute>();

            // **** get the fields from this type ****

            PropertyInfo[] properties = typeof(T).GetProperties();

            // **** traverse the fields looking for required ones ****

            foreach (PropertyInfo property in properties)
            {
                // **** get attributes for this field ****

                ExcelFieldAttribute attribute = GetPropertyAttribute<T>(property.Name);

                if (attribute == null)
                {
                    continue;
                }

                // **** add to the dictionary ****

                dict.Add(property.Name, attribute);
            }

            return dict;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets field attribute.</summary>
        ///
        /// <remarks>Gino Canessa, 1/16/2020.</remarks>
        ///
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        ///
        /// <returns>The field attribute.</returns>
        ///-------------------------------------------------------------------------------------------------

        private static ExcelFieldAttribute GetPropertyAttribute<T>(string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);

            if (property == null)
            {
                return null;
            }

            return (ExcelFieldAttribute)property.GetCustomAttribute(typeof(ExcelFieldAttribute));
        }
    }
}
