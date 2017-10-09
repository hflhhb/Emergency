using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LeaRun.Definitions
{
    public static class EnumExtensions
    {

        /// <summary>
        /// 获取DisplayAttribute上指定的Name
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDisplay(this Enum value)
        {
            var info = value.GetType().GetField(value.ToString());
            var attribute = (DisplayAttribute)info.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        /// <summary>
        ///  获取DescriptionAttribute上指定的Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            return EnumHelper.GetEnumDescription(value);
        }

        /// <summary>
        /// 把值转换为相应的枚举类型,转化不成功为默认值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="str">值</param>
        /// <param name="defVal">默认值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str, T defVal = default(T)) where T : struct
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            return EnumHelper.ConvertToEnum<T>(str, defVal);
        }

        /// <summary>
        ///  转化为枚举类型，转化不成功为默认值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value, T defVal = default(T)) where T : struct
        {
            return EnumHelper.ConvertToEnum<T>(value.ToString(), defVal);
        }

        /// <summary>
        ///  转化为枚举类型，转化不成功为默认值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int? value, T defVal = default(T)) where T : struct
        {
            return EnumHelper.ConvertToEnum<T>(value.ToString(), defVal);
        }

        /// <summary>
        ///  转化为枚举类型，转化不成功null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToNullableEnum<T>(this string value) where T : struct
        {
            return EnumHelper.ConvertToNullableEnum<T>(value);
        }
        /// <summary>
        ///  转化为枚举类型，转化不成功null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToNullableEnum<T>(this int value) where T : struct
        {
            return EnumHelper.ConvertToNullableEnum<T>(value.ToString());
        }
        /// <summary>
        ///  转化为枚举类型，转化不成功null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToNullableEnum<T>(this int? value) where T : struct
        {
            return EnumHelper.ConvertToNullableEnum<T>(value.ToString());
        }

        /// <summary>
        /// 获取DisplayAttribute上指定的Name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defVal">defVal</param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum value, string defVal = "")
        {
            var attribute = EnumHelper.GetEnumDisplayAttributs(value).FirstOrDefault();
            return attribute == null ? defVal : attribute.GetName();
        }

        /// <summary>
        /// 获取DisplayAttribute上指定的ShortName
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defVal">defVal</param>
        /// <returns></returns>
        public static string GetDisplayShortName(this Enum value, string defVal = "")
        {
            var attribute = EnumHelper.GetEnumDisplayAttributs(value).FirstOrDefault();
            return attribute == null ? defVal : attribute.GetShortName();
        }

        /// <summary>
        /// 获取DisplayAttribute上指定的Desc
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defVal">defVal</param>
        /// <returns></returns>
        public static string GetDisplayDesc(this Enum value, string defVal = "")
        {
            var attribute = EnumHelper.GetEnumDisplayAttributs(value).FirstOrDefault();
            return attribute == null ? defVal : attribute.GetDescription();
        }
    }
}
