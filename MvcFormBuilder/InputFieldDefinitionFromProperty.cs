using System;
using System.Collections.Generic;
using FormBuilder;

namespace FormBuilder
{
    public class InputFieldDefinitionFromProperty
    {
        private readonly Dictionary<Type, FieldType> typeToFieldTypes;

        public InputFieldDefinitionFromProperty()
        {
            typeToFieldTypes = new Dictionary<Type, FieldType>
                                      {
                                          { typeof(string), FieldType.Input },
                                          { typeof(int), FieldType.Input }
                                      };
        }

        public InputFieldDefinition Get(Type type, string propertyName)
        {
            var t = new PropertyInfoGetter()
                .GetPropertyInfo(type, propertyName)
                .PropertyType;

            if (typeToFieldTypes.ContainsKey(t))
                return new InputFieldDefinition { Type = typeToFieldTypes[t] };

            return null;
        }
    }
}
