using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Extensions are defined on the Extensions tab.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    [ExcelTab(
        pageName: "Extensions",
        fieldStructure: ExcelTabAttribute.FieldNameStructures.Columns,
        allowedForProfile: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForResource: ExcelTabAttribute.PageAllowedLevels.Allowed,
        allowedForDataType: ExcelTabAttribute.PageAllowedLevels.Allowed,
        description:
            "Extensions are defined on the Extensions tab."
        )]
    public class TabExtensions : CommonElementFields
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// String - required. This is the string that must be sent after the extension.uri and the '#' in 
        /// an instance when identifying this particular extension. E.g. For the extension 
        /// "http://hl7.org/fhir/Profile/iso-21090#nullFlavor", the "code" would be "nullFlavor". These 
        /// should generally be lower-camel-case strings. If the extension is part of another extension, the 
        /// convention is to use string concatenation. E.g. "relationParent.type" as the code for the "type" 
        /// characteristic of the "relationParent" extension.
        /// 
        /// Following is an example of a definition of a complex extension:
        /// +------------------------+--------------+----------------------+-------+
        /// | Code                   | Context Type | Context              | Card. |
        /// +------------------------+--------------+----------------------+-------+
        /// | complexExtension       | Resource     | SomeResource.element | 0..1  |
        /// +------------------------+--------------+----------------------+-------+
        /// | complexExtension.node1 |              |                      | 1..1  |
        /// +------------------------+--------------+----------------------+-------+
        /// | complexExtension.node2 |              |                      | 0..*  |
        /// +------------------------+--------------+----------------------+-------+
        /// </summary>
        ///
        /// <value>The code.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Code",
            displayName: "Code",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "String - required. This is the string that must be sent after the extension.uri and the '#' in " +
                "an instance when identifying this particular extension. E.g. For the extension " +
                "\"http://hl7.org/fhir/Profile/iso-21090#nullFlavor\", the \"code\" would be \"nullFlavor\". These " +
                "should generally be lower-camel-case strings. If the extension is part of another extension, the " +
                "convention is to use string concatenation. E.g. \"relationParent.type\" as the code for the \"type\" " +
                "characteristic of the \"relationParent\" extension.\n" +
                "\n" +
                "Following is an example of a definition of a complex extension:\n" +
                "+------------------------+--------------+----------------------+-------+\n" +
                "| Code                   | Context Type | Context              | Card. |\n" +
                "+------------------------+--------------+----------------------+-------+\n" +
                "| complexExtension       | Resource     | SomeResource.element | 0..1  |\n" +
                "+------------------------+--------------+----------------------+-------+\n" +
                "| complexExtension.node1 |              |                      | 1..1  |\n" +
                "+------------------------+--------------+----------------------+-------+\n" +
                "| complexExtension.node2 |              |                      | 0..*  |\n" +
                "+------------------------+--------------+----------------------+-------+\n"
            )]
        public string Code { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// string - condiditional. This will be one of 3 values: "Resource", "DataType" or "Extension" 
        /// indicating where the extension is allowed to be used.
        /// 
        /// - "Resource" means the extension can be associated with any element in any resource (or any set 
        /// of elements from one or more resources), including both the root element and complex structures 
        /// within the resource. (It can also apply to leaf-level nodes within a resource or even to 
        /// components of a data type, so long as the full context is rooted in a resource.)
        /// 
        /// - "DataType" means the extension can be associated with any element that is part of a data type 
        /// (including the root node of simple data types).
        /// 
        /// - "Extension" means the extension can be associated with the root node or some descendant node 
        /// of a particular extension.Context only needs to be defined for the root node of an extension. 
        /// Nested extensions (those whose code contains ".") automatically have a context of the parent 
        /// extension.
        /// 
        /// - Note that it is not possible to define an extension whose context can be some combination of 
        /// resource, data type and extension - multiple extensions must be defined.
        /// </summary>
        ///
        /// <value>The context type.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Context Type",
            displayName: "Context Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "string - condiditional. This will be one of 3 values: \"Resource\", \"DataType\" or \"Extension\" " +
                "indicating where the extension is allowed to be used.\n" +
                "\n" +
                "- \"Resource\" means the extension can be associated with any element in any resource (or any set " +
                "of elements from one or more resources), including both the root element and complex structures " +
                "within the resource. (It can also apply to leaf-level nodes within a resource or even to " +
                "components of a data type, so long as the full context is rooted in a resource.)\n" +
                "\n" +
                "- \"DataType\" means the extension can be associated with any element that is part of a data type " +
                "(including the root node of simple data types).\n" +
                "\n" +
                "- \"Extension\" means the extension can be associated with the root node or some descendant node " +
                "of a particular extension.Context only needs to be defined for the root node of an extension. " +
                "Nested extensions (those whose code contains \".\") automatically have a context of the parent " +
                "extension.\n" +
                "\n" +
                "- Note that it is not possible to define an extension whose context can be some combination of " +
                "resource, data type and extension - multiple extensions must be defined."
            )]
        public string ContextType { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// String - conditional. This is the list of resource elements, data type elements or extensions 
        /// this particular extension is allowed to appear in. For resources and data types, this is the 
        /// full path name of the element. E.g. "Observation.value[x]". For extensions, this is the full 
        /// path to the corresponding extension this extension is allowed to appear within. Context must be 
        /// specified (and may only be specified) if Context Type is present.
        /// </summary>
        ///
        /// <value>The context.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Context",
            displayName: "Context",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "String - conditional. This is the list of resource elements, data type elements or extensions " +
                "this particular extension is allowed to appear in. For resources and data types, this is the " +
                "full path name of the element. E.g. \"Observation.value[x]\". For extensions, this is the full " +
                "path to the corresponding extension this extension is allowed to appear within. Context must be " +
                "specified (and may only be specified) if Context Type is present."
            )]
        public string Context { get; set; }
    }
}
