using fhir_spec_lib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace fhir_spec_lib.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Generally-defined elements, which may appear on multiple sheets.
    /// </summary>
    ///
    /// <remarks>Gino Canessa, 1/2/2020.</remarks>
    ///-------------------------------------------------------------------------------------------------

    public class CommonElementFields
    {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required. This defines the full-path name for the element row. Nodes within the path 
        /// are separated by ".". E.g. Patient.contact.name. Rows must be listed in the order they will 
        /// appear in the instance. The first row will be the name of the resource or data type. Subsequent 
        /// rows will be prefixed with the resource name. I.e. All elements listed in a given spreadsheet 
        /// tab will start with the same prefix.
        /// 
        /// When creating a profile, all path names *must* correspond to names present in the resource or 
        /// data type being profiled.Note that some paths exist implicitly but aren't listed in the resource 
        /// spreadsheet: "ResourceName".text, "somepath".extension and "somepath".modifierExtension elements 
        /// all exist and can be explicitly referred to when creating a profile.
        /// </summary>
        ///
        /// <value>The element.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Element",
            displayName: "Element Name (full-path)",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required. This defines the full-path name for the element row. Nodes within the path " +
                "are separated by \".\".E.g.Patient.contact.name.Rows must be listed in the order they will " +
                "appear in the instance.The first row will be the name of the resource or data type.Subsequent " +
                "rows will be prefixed with the resource name.I.e.All elements listed in a given spreadsheet " +
                "tab will start with the same prefix.\n" +
                "\n" +
                "When creating a profile, all path names * must * correspond to names present in the resource or " +
                "data type being profiled.Note that some paths exist implicitly but aren't listed in the resource  " +
                "spreadsheet: \"ResourceName\".text, \"somepath\".extension and \"somepath\".modifierExtension elements " +
                "all exist and can be explicitly referred to when creating a profile."
            )]
        public string Element { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This is a list of comma-separated alternate names for the element. These might be 
        /// realm-specific or domain-specific or just other common-practice names used in industry. The names 
        /// here need not have identical scope. The objective is to ensure that someone looking for the 
        /// resource, resource element, extension, etc. will be able to find the appropriate name by matching 
        /// on an alias. These names appear in the Formal Definitions tab. For the root resource node, they 
        /// also appear in the Clinical/Administrative/Infrastructure/Financial tabs
        /// </summary>
        ///
        /// <value>The aliases.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Aliases",
            displayName: "Aliases",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This is a list of comma-separated alternate names for the element. These might be " +
                "realm-specific or domain-specific or just other common-practice names used in industry. The names " +
                "here need not have identical scope. The objective is to ensure that someone looking for the " +
                "resource, resource element, extension, etc. will be able to find the appropriate name by matching " +
                "on an alias. These names appear in the Formal Definitions tab. For the root resource node, they " +
                "also appear in the Clinical/Administrative/Infrastructure/Financial tabs"
            )]
        public string Aliases { get; set; }

        private int? cardinalityMin;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the cardinality minimum, not present is equivalent to a minimum cardinality
        /// of zero (0)
        /// </summary>
        ///
        /// <value>The cardinality minimum.</value>
        ///-------------------------------------------------------------------------------------------------

        public int? CardinalityMin
        {
            get
            {
                return cardinalityMin;
            }
            set
            {
                cardinalityMin = value;
                UpdateCardinality(cardinalityMin, cardinalityMax);
            }
        }

        private int? cardinalityMax;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the cardinality maximum, not present is equivalent to a maximum cardinality 
        /// of * (unlimited).
        /// </summary>
        ///
        /// <value>The cardinality maximum.</value>
        ///-------------------------------------------------------------------------------------------------

        public int? CardinalityMax
        {
            get
            {
                return cardinalityMax;
            }
            set
            {
                cardinalityMax = value;
                UpdateCardinality(cardinalityMin, cardinalityMax);
            }
        }

        [ExcelField(
            fieldName: "Card.",
            displayName: "Cardinality",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required. This indicates the minimum and maximum number of repetitions allowed for the element. " +
                "For resources, this is constrained to 0..1, 0..*, 1..1 or 1..*. For profiles, any cardinality may " +
                "be specified, so long as it is a proper constraint on the underlying resource. To prohibit an " +
                "element, use 0..0."
            )]
        private string cardinality;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required. This indicates the minimum and maximum number of repetitions allowed for the element. 
        /// For resources, this is constrained to 0..1, 0..*, 1..1 or 1..*. For profiles, any cardinality may 
        /// be specified, so long as it is a proper constraint on the underlying resource. To prohibit an 
        /// element, use 0..0.
        /// </summary>
        ///
        /// <value>The cardinality.</value>
        ///-------------------------------------------------------------------------------------------------

        public string Cardinality => cardinality;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This is a reference to an invariant that governs the appearance of this element. 
        /// (I.e. whether the element is allowed to be present or not). It must be one of the values in the 
        /// "id" column from the #Invariants_Tab. If multiple invariants apply to a single element, they can 
        /// be separated with ",".
        /// </summary>
        ///
        /// <value>The invariant names.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Inv.",
            displayName: "Invariant Names",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This is a reference to an invariant that governs the appearance of this element. " +
                "(I.e. whether the element is allowed to be present or not). It must be one of the values in the " +
                "\"id\" column from the #Invariants_Tab. If multiple invariants apply to a single element, they can " +
                "be separated with \",\"."
            )]
        public string InvariantNames { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional. This indicates the data type(s) for this particular element. It must be present on 
        /// the first row of a resource or data element definition (or profile of one) where it indicates 
        /// whether the structure is dealing with a resource or a data type. It must be present for 
        /// leaf-level elements (those with no child elements). For complex elements, this is generally left 
        /// empty, however it may be populated in limited situations
        /// 
        /// - First row of resource/data type: For resources, this will be "Resource". For data types, 
        /// this will be "Structure".
        /// 
        /// - Leaf level elements: The allowed value consists of one or more "type" statements.Each type 
        /// statement includes the defined type(a data type or resource reference). For profiles, it may also 
        /// include a profile to apply to the data type or resource.For profiles when the type is a resource 
        /// reference, it may also include an indication of how that resource is conveyed(aggregated)
        /// 
        ///   - The type is expressed either as the name of a data type(e.g. "string" or "Address"), a 
        ///   reference to one or more resources "Reference(Resource1 | Resource2 | etc.)" or set to "*" to 
        ///   signify that any data type or resource is permitted.
        ///   
        ///   - A profile can be referenced by following the type with "{" some profile reference "}". E.g. 
        ///   "Address{Address-UK}" or "Extension{#SomeLocalExtension}" or 
        ///   "Extension{http://hl7.org/fhir/Profile/SomeProfile#someExtension}" or 
        ///   "Reference(Patient}{Patient-NL}". Note that profiles can *only* be referenced for data types 
        ///   when defining a profile.They can't be referenced when defining a resource or data type. Also, 
        ///   profiles can only be referenced when referencing a single resource. The following would be 
        ///   illegal: "Reference(Patient|Practitioner){Patient-NL)". Instead you'd need to do 
        ///   "Reference(Patient){Patient-NL} | Reference(Practitioner)".
        ///   
        ///   - When working with complex extensions, sometimes it'll be necessary to refer to an element 
        ///   inside a complex extension (in order to constrain or perhaps extend it). To reference a 
        ///   descendant of a complex extension, specify the URL for the extension followed by a hash sign 
        ///   and the relative path. For example to refer to an extension component author.name.primary, 
        ///   you'd say either "{http..../author#name.primary}" or, if the extension were defined in the 
        ///   same spreadsheet, "{#author#name.primary}".
        ///   
        ///   - Aggregations can only be specified if the type is a Reference to some resource and if the 
        ///   element is in a profile definition. Allowed values are "contained", "reference" and "bundle". 
        ///   (If you specify "reference", that implies "bundle" as well.) Multiple aggregation types can be 
        ///   declared.If none are declared, then all are presumed to be permitted.So in practice, only the 
        ///   following options make sense:
        ///     - "<contained>" - reference must be to a contained resource
        ///     - "<reference>" - reference must be to a non-contained resource (in bundle or remote)
        ///     - "<bundle>" - reference must be to a resource found in the bundle
        ///     - "<contained,bundle>" - reference must be to a resource either contained or present in the bundle
        ///     
        /// - For complex structures, the "type" column is used for one purpose
        /// 
        ///   - You can say "=Name" to declare what the class name should be for the complex type. This is useful 
        ///   if you want the class name to be different than the association name (e.g. if the class might be 
        ///   referenced from multiple places)
        ///   
        /// - For complex structures(which includes profiled simple structures with nested elements):
        /// 
        ///   - You can say "@some.complex.element.path" or "@[Element Profile Name]" to say that the type for the 
        ///   element should be a complex structure already defined elsewhere within the resource.
        /// </summary>
        ///
        /// <value>The FHIR type for this element</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Type",
            displayName: "Element Type",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional. This indicates the data type(s) for this particular element. It must be present on " +
                "the first row of a resource or data element definition (or profile of one) where it indicates " +
                "whether the structure is dealing with a resource or a data type. It must be present for " +
                "leaf-level elements (those with no child elements). For complex elements, this is generally left " +
                "empty, however it may be populated in limited situations:\n" +
                "\n" +
                "- First row of resource/data type: For resources, this will be \"Resource\". For data types, " +
                "this will be \"Structure\".\n" +
                "\n" +
                "- Leaf level elements: The allowed value consists of one or more \"type\" statements.Each type " +
                "statement includes the defined type(a data type or resource reference). For profiles, it may also " +
                "include a profile to apply to the data type or resource.For profiles when the type is a resource " +
                "reference, it may also include an indication of how that resource is conveyed(aggregated):\n" +
                "\n" +
                "  - The type is expressed either as the name of a data type(e.g. \"string\" or \"Address\"), a " +
                "  reference to one or more resources \"Reference(Resource1 | Resource2 | etc.)\" or set to \"*\" to " +
                "  signify that any data type or resource is permitted.\n" +
                "\n" +
                "  - A profile can be referenced by following the type with \"{\" some profile reference \"}\". E.g. " +
                "  \"Address{Address-UK}\" or \"Extension{#SomeLocalExtension}\" or " +
                "  \"Extension{http://hl7.org/fhir/Profile/SomeProfile#someExtension}\" or " +
                "  \"Reference(Patient}{Patient-NL}\". Note that profiles can *only* be referenced for data types " +
                "  when defining a profile.They can't be referenced when defining a resource or data type. Also, " +
                "  profiles can only be referenced when referencing a single resource. The following would be " +
                "  illegal: \"Reference(Patient|Practitioner){Patient-NL)\". Instead you'd need to do " +
                "  \"Reference(Patient){Patient-NL} | Reference(Practitioner)\".\n" +
                "\n" +
                "  - When working with complex extensions, sometimes it'll be necessary to refer to an element " +
                "  inside a complex extension (in order to constrain or perhaps extend it). To reference a " +
                "  descendant of a complex extension, specify the URL for the extension followed by a hash sign " +
                "  and the relative path. For example to refer to an extension component author.name.primary, " +
                "  you'd say either \"{http..../author#name.primary}\" or, if the extension were defined in the " +
                "  same spreadsheet, \"{#author#name.primary}\".\n" +
                "\n" +
                "  - Aggregations can only be specified if the type is a Reference to some resource and if the " +
                "  element is in a profile definition. Allowed values are \"contained\", \"reference\" and \"bundle\". " +
                "  (If you specify \"reference\", that implies \"bundle\" as well.) Multiple aggregation types can be " +
                "  declared.If none are declared, then all are presumed to be permitted.So in practice, only the " +
                "  following options make sense:\n" +
                "    - \"<contained>\" - reference must be to a contained resource\n" +
                "    - \"<reference>\" - reference must be to a non-contained resource (in bundle or remote)\n" +
                "    - \"<bundle>\" - reference must be to a resource found in the bundle\n" +
                "    - \"<contained,bundle>\" - reference must be to a resource either contained or present in the bundle\n" +
                "\n" +
                "- For complex structures, the \"type\" column is used for one purpose\n" +
                "\n" +
                "  - You can say \"=Name\" to declare what the class name should be for the complex type. This is useful " +
                "  if you want the class name to be different than the association name (e.g. if the class might be " +
                "  referenced from multiple places)\n" +
                "\n" +
                "- For complex structures(which includes profiled simple structures with nested elements):\n" +
                "\n" +
                "  - You can say \"@some.complex.element.path\" or \"@[Element Profile Name]\" to say that the type for the " +
                "  element should be a complex structure already defined elsewhere within the resource." +
                ""
            )]
        public string FHIRType { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This indicates whether the element is considered to change the meaning of other 
        /// elements in the resource/data type. It must be either "Y" or "N". If unspecified, it will be 
        /// defaulted to "N" by the tool. (Note: This column only exists when defining data types, resources 
        /// and extensions. It cannot be set or modified in profiles.)
        /// </summary>
        ///
        /// <value>The is modifier.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Is Modifier",
            displayName: "Is Modifier",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This indicates whether the element is considered to change the meaning of other " +
                "elements in the resource/data type. It must be either \"Y\" or \"N\". If unspecified, it will be " +
                "defaulted to \"N\" by the tool. (Note: This column only exists when defining data types, resources " +
                "and extensions. It cannot be set or modified in profiles.)"
            )]
        public bool? IsModifier { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This indicates the reason why an element is a modifier.
        /// </summary>
        ///
        /// <value>The modifier reason.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Modifier Reason",
            displayName: "Modifier Reason",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This indicates the reason why an element is a modifier."
            )]
        public string ModifierReason { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional. This must be specified for any data element that allows a type of code, Coding or 
        /// CodeableConcept (including "*"). It should not be present for other elements. It must refer to a 
        /// Binding name from either the #Bindings Tab in the current spreadsheet or one of the other 
        /// resource spreadsheets. (Note - the order in which resources are first loaded into memory is 
        /// controlled by the build/source/fhir.ini file. Resources that define bindings must be listed 
        /// before other resources that use them.
        /// </summary>
        ///
        /// <value>The binding.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Binding",
            displayName: "Binding",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Conditional. This must be specified for any data element that allows a type of code, Coding or " +
                "CodeableConcept (including \"*\"). It should not be present for other elements. It must refer to a " +
                "Binding name from either the #Bindings Tab in the current spreadsheet or one of the other " +
                "resource spreadsheets. (Note - the order in which resources are first loaded into memory is " +
                "controlled by the build/source/fhir.ini file. Resources that define bindings must be listed " +
                "before other resources that use them."

            )]
        public string Binding { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. An example value for the data element. Can only be specified if the type is a single 
        /// type. Examples can be strings for simple types or XML structures for complex types.
        /// </summary>
        ///
        /// <value>The example.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Example",
            displayName: "Example",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. An example value for the data element. Can only be specified if the type is a single " +
                "type. Examples can be strings for simple types or XML structures for complex types."
            )]
        public string Example { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. A default value for this element, if no value is provided.
        /// </summary>
        ///
        /// <value>The default value.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Default Value",
            displayName: "Default Value",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. A default value for this element, if no value is provided."
            )]
        public string DefaultValue { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. What is implied if this element does not contain a value.
        /// </summary>
        ///
        /// <value>The missing meaning.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Missing Meaning",
            displayName: "Missing Meaning",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. What is implied if this element does not contain a value."
            )]
        public string MissingMeaning { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Recommended. This is the definition that appears in the XML form as a comment guiding the 
        /// implementer. If the data type is code, the short name *must* be in the form 
        /// "code1 | code2 | code 3 . . . .". If there are more than 5-6 codes, list the first 5 or 6 and 
        /// then add a "+". E.g "code5 | code6 +". The short name can be omitted if there's absolutely 
        /// *nothing* useful that can be said to expand on the meaning of the element name, but usually 
        /// something should be provided, even if just an example or two. The short name should generally be 
        /// 50 characters or less.
        /// </summary>
        ///
        /// <value>The short label.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Short Label",
            displayName: "Short Label",
            required: ExcelFieldAttribute.FieldRequiredLevels.Recommended,
            description:
                "Recommended. This is the definition that appears in the XML form as a comment guiding the " +
                "implementer. If the data type is code, the short name *must* be in the form " +
                "\"code1 | code2 | code 3 . . . .\". If there are more than 5-6 codes, list the first 5 or 6 and " +
                "then add a \"+\". E.g \"code5 | code6 +\". The short name can be omitted if there's absolutely " +
                "*nothing* useful that can be said to expand on the meaning of the element name, but usually " +
                "something should be provided, even if just an example or two. The short name should generally be " +
                "50 characters or less."
            )]
        public string ShortLabel { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Required. This is the full definition of the element. It should not be redundant with either the 
        /// element name or short name. Examples should be given, if appropriate. This element may be 
        /// expressed using mark down to allow hyperlinking to other elements in the specification, 
        /// including bullets and other formatting.
        /// </summary>
        ///
        /// <value>The definition.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Definition",
            displayName: "Definition",
            required: ExcelFieldAttribute.FieldRequiredLevels.Required,
            description:
                "Required. This is the full definition of the element. It should not be redundant with either the " +
                "element name or short name. Examples should be given, if appropriate. This element may be " +
                "expressed using mark down to allow hyperlinking to other elements in the specification, " +
                "including bullets and other formatting."
            )]
        public string Definition { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This provides explanation about why the resource, data type or data element within the 
        /// resource/data type is necessary and/or why it has been constrained as it has. It is optional - 
        /// only fill it in if the requirements won't be obvious to those with minimal industry experience. 
        /// (E.g. No need to explain why there's a "name" element on Patient, but Patient.multipleBirth[x] 
        /// should probably have some explanation.) This element may be expressed using mark down to allow 
        /// hyperlinking to other elements in the specification, including bullets and other formatting.
        /// </summary>
        ///
        /// <value>The requirements.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Requirements",
            displayName: "Requirements",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This provides explanation about why the resource, data type or data element within the " +
                "resource/data type is necessary and/or why it has been constrained as it has. It is optional - " +
                "only fill it in if the requirements won't be obvious to those with minimal industry experience. " +
                "(E.g. No need to explain why there's a \"name\" element on Patient, but Patient.multipleBirth[x] " +
                "should probably have some explanation.) This element may be expressed using mark down to allow " +
                "hyperlinking to other elements in the specification, including bullets and other formatting."
            )]
        public string Requirements { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This element provides additional usage notes associated with the element that are not 
        /// definitional in nature and don't belong in requirements. These should be element-specific. Usage 
        /// notes that apply across elements or that span more than a couple of paragraphs should be handled 
        /// in the usage notes HTML file for the overall resource. This element may be expressed using mark 
        /// down to allow hyperlinking to other elements in the specification, including bullets and other 
        /// formatting.
        /// </summary>
        ///
        /// <value>The comments.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Comments",
            displayName: "Comments",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This element provides additional usage notes associated with the element that are not " +
                "definitional in nature and don't belong in requirements. These should be element-specific. Usage " +
                "notes that apply across elements or that span more than a couple of paragraphs should be handled " +
                "in the usage notes HTML file for the overall resource. This element may be expressed using mark " +
                "down to allow hyperlinking to other elements in the specification, including bullets and other " +
                "formatting."
            )]
        public string Comments { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This column is for work group convenience. It does not propagate to the resource XML 
        /// definition though does appear in the specification. We may cause warnings to be spit out for 
        /// resources that claim to be at DSTU-level with content in this column. This element may be 
        /// expressed using mark down to allow hyperlinking to other elements in the specification, including 
        /// bullets and other formatting.
        /// </summary>
        ///
        /// <value>to do.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "To Do",
            displayName: "To Do",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This column is for work group convenience. It does not propagate to the resource XML " +
                "definition though does appear in the specification. We may cause warnings to be spit out for " +
                "resources that claim to be at DSTU-level with content in this column. This element may be " +
                "expressed using mark down to allow hyperlinking to other elements in the specification, including " +
                "bullets and other formatting."
            )]
        public string ToDo { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional. This contains the mapping of the resource, data type or element to the V3 RIM. The 
        /// resource level must always be specified, though it can be set to "N/A". If not set to "N/A", all 
        /// subsequent elements must also be specified, though some of those may also be expressed as "N/A". 
        /// If present, mappings are generally expressed as pseudo-xpaths. E.g. 
        /// "Observation[classCode=OBS, moodCode=EVN]". Mappings are expressed relative to the parent element. 
        /// They are intended for human understandability purposes, not for automated processing or mapping.
        /// </summary>
        ///
        /// <value>The HL7 v3 RIM mapping.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "RIM Mapping",
            displayName: "v3 RIM Mapping",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional. This contains the mapping of the resource, data type or element to the V3 RIM. The " +
                "resource level must always be specified, though it can be set to \"N/A\". If not set to \"N/A\", all " +
                "subsequent elements must also be specified, though some of those may also be expressed as \"N/A\". " +
                "If present, mappings are generally expressed as pseudo-xpaths. E.g. " +
                "\"Observation[classCode=OBS, moodCode=EVN]\". Mappings are expressed relative to the parent element. " +
                "They are intended for human understandability purposes, not for automated processing or mapping."
            )]
        public string MappingRIM { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional. This contains the mapping of the resource, data type or element to the V2 
        /// specification (most current release). The resource level must always be specified, though it can 
        /// be set to "N/A". If not set to "N/A", all subsequent elements must also be specified, though some 
        /// of those may also be expressed as "N/A". If present, mappings are generally expressed in dot 
        /// notation. E.g. PID.3.1 They are intended for human understandability purposes, not for automated 
        /// processing or mapping.
        /// </summary>
        ///
        /// <value>The HL7 v2 field mapping.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "v2 Mapping",
            displayName: "v2 Mapping",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Conditional. This contains the mapping of the resource, data type or element to the V2 " +
                "specification (most current release). The resource level must always be specified, though it can " +
                "be set to \"N/A\". If not set to \"N/A\", all subsequent elements must also be specified, though some " +
                "of those may also be expressed as \"N/A\". If present, mappings are generally expressed in dot " +
                "notation. E.g. PID.3.1 They are intended for human understandability purposes, not for automated " +
                "processing or mapping."
            )]
        public string MappingV2 { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>Gets or sets the other mappings.</summary>
        ///
        /// <value>The other mappings.</value>
        ///-------------------------------------------------------------------------------------------------

        public Dictionary<string, string> OtherMappings { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional - This is a set of parameters passed to the narrative generator for this particular 
        /// element. Each parameter is expressed as "[name]:[value]". Parameter settings are separated by 
        /// semi-colon. E.g. "param1:value1;param2:value2". At present, there is only one supported parameter:
        /// 
        /// - default: identifies what the default value is considered to be for this element.If the value in 
        /// an instance matches the default, it will be excluded from the narrative rendering.
        /// </summary>
        ///
        /// <value>The display hint.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Display Hint",
            displayName: "Display Hint",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional - This is a set of parameters passed to the narrative generator for this particular " +
                "element. Each parameter is expressed as \"[name]:[value]\". Parameter settings are separated by " +
                "semi-colon. E.g. \"param1:value1;param2:value2\". At present, there is only one supported parameter:\n" +
                "\n" +
                "- default: identifies what the default value is considered to be for this element.If the value in " +
                "an instance matches the default, it will be excluded from the narrative rendering."
            )]
        public string DisplayHint { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Optional. This column is for work group convenience. It does not propagate to the resource XML 
        /// definition nor into the specification. It might include design notes not intended for publication
        /// </summary>
        ///
        /// <value>The committee notes.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "Committee Notes",
            displayName: "Committee Notes",
            required: ExcelFieldAttribute.FieldRequiredLevels.Optional,
            description:
                "Optional. This column is for work group convenience. It does not propagate to the resource XML " +
                "definition nor into the specification. It might include design notes not intended for publication."
            )]
        public string CommitteeNotes { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Conditional? - Five W's Hint value (e.g., who, what, where, when, why) - see Resource: FiveWs
        /// </summary>
        ///
        /// <value>The five ws.</value>
        ///-------------------------------------------------------------------------------------------------

        [field: ExcelField(
            fieldName: "w5",
            displayName: "Five W's Hint",
            required: ExcelFieldAttribute.FieldRequiredLevels.Conditional,
            description:
                "Five W's Hint value (e.g., who, what, where, when, why) - see Resource: FiveWs"
            )]
        public string FiveWs { get; set; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>Updates the cardinality string based on set Min and Max values</summary>
        ///
        /// <remarks>Gino Canessa, 1/2/2020.</remarks>
        ///
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        ///-------------------------------------------------------------------------------------------------

        private void UpdateCardinality(int? min, int? max)
        {
            string cardMin = (min.HasValue) ? min.ToString() : "0";
            string cardMax = (max.HasValue) ? max.ToString() : "*";

            cardinality = $"{min}..{max}";
        }

    }
}
