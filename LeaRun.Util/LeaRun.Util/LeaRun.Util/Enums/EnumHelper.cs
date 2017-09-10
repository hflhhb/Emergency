using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Util 
{
    public class ReadEnum
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }

    public class EnumHelper
    {
        public static List<ReadEnum> GetEnumList(Type type)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "type");
            }            
            Array enumValues = Enum.GetValues(type);
            List<ReadEnum> enumDic = new List<ReadEnum>();
            foreach (Enum enumValue in enumValues)
            {
                Int32 key = Convert.ToInt32(enumValue);

                ReadEnum readEnum = new ReadEnum();
                readEnum.Value = key.ToString();
                readEnum.Name= Enum.GetName(type, enumValue);

                FieldInfo field = type.GetField(readEnum.Name);
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                readEnum.Description=  attribute == null ? string.Empty : attribute.Description;             
            } 
            return enumDic;
        }

        public static string GetEnumName<T>(string value)
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return string.Empty;
            }
            return name;
        }

        public static string GetEnumName<T>(short value)
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return string.Empty;
            }
            return name;
        }

        public static string GetEnumName<T>(int value)
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return string.Empty;
            }
            return name;
        }

        public static string GetEnumName<T>(object value)
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return string.Empty;
            }
            return name;
        }

        public static string GetEnumDesc<T>(string value)
        {
            return EnumHelper.GetEnumDescByValue<T>(value);
        }

        public static string GetEnumDesc<T>(short value)
        {
            return EnumHelper.GetEnumDescByValue<T>(value);
        }

        public static string GetEnumDesc<T>(int value)
        {
            return EnumHelper.GetEnumDescByValue<T>(value);
        }

        public static string GetEnumDesc<T>(object value)
        {
            return EnumHelper.GetEnumDescByValue<T>(value);
        }
        private static string GetEnumDescByValue<T>(object value)
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return string.Empty;
            }

            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? string.Empty : attribute.Description;
        }

        public static string GetOptions<T>(short value)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, string.Empty);
        }
        public static string GetOptions<T>(int value)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, string.Empty);
        }
        public static string GetOptions<T>(object value)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, string.Empty);
        }
        public static string GetOptions<T>(T value)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, string.Empty);
        }
        public static string GetOptions<T>(T value, string defaultText)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, defaultText);
        }
        public static string GetOptions<T>(short value, string defaultText)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, defaultText);
        }
        public static string GetOptions<T>(int value, string defaultText)
        {
            return EnumHelper.GetOptionsByEnum<T>(value, defaultText);
        }
        public static string GetOptions<T>(object value, string defaultText)
        {
            return EnumHelper.GetOptionsByEnum<T>(value,defaultText);
        }

        private static string GetOptionsByEnum<T>(object value, string defaultText)
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "type");
            }
            Array enumValues = Enum.GetValues(type);

            StringBuilder sbOptions = new StringBuilder();
            if (defaultText.Length > 0)
            {
                sbOptions.Append("<option value=''>" + defaultText + "</option>").AppendLine();
            }

            foreach (Enum enumValue in enumValues)
            {
                Int32 key = Convert.ToInt32(enumValue);
                 
                string strValue = key.ToString();
                string strName = Enum.GetName(type, enumValue);

                FieldInfo field = type.GetField(strName);
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                string strDescription = attribute == null ? strName : attribute.Description;
                 
                if (string.Compare(strValue, StringUtil.cEmpty(value),true) == 0)
                {
                    sbOptions.Append("<option value='"+ strName + "' selected='selected'>" + strName +"  -  "+ strDescription + "</option>").AppendLine();
                }else if (string.Compare(strName, StringUtil.cEmpty(value), true) == 0)
                {
                    sbOptions.Append("<option value='" + strName + "' selected='selected'>" + strName + "  -  " + strDescription + "</option>").AppendLine();
                }
                else
                {
                    sbOptions.Append("<option value='" + strName + "'>" + strName + "  -  " + strDescription + "</option>").AppendLine();
                }
            }
            return sbOptions.ToString();
        }
    }
}
