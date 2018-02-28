/**
 *  Author(s):  SemperVic@GitHub
 *  Website:    //datarx.org
 *  Date:       02/28/2018
 *  Version:    1.0.0 (Alpha)
 * */

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace DataRx.SDK.Common
{
    /// <summary>
    /// The StringHelper class provides string formatting features that assist in 
    /// standardizing coding and naming conventions.
    /// </summary>
    public static class StringHelper
    {
        private static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// Used to convert string to IDEF1X naming convention
        /// </summary>
        /// <param name="inDefString">String to format</param>
        /// <returns>IDEF1X Formatted String</returns>
        public static String IDefinitionFormat(String inDefString)
        {
            String returnString = inDefString.ToUpper().Replace(" ", "_");            
            return returnString;
        }
        /// <summary>
        /// Same as Pascal Case. Words created by concatenating capitalized words. 
        /// DromedaryCase restriction requires that the first letter must be upper 
        /// case. Uses MS Cultural TextInfo object to perform conversion.
        /// Example: Pascal Case becomes PascalCase. 
        /// </summary>
        /// <param name="iDefName">String to be formated</param>
        /// <returns>Formated string</returns>
        public static String ToDromedaryCase(String iDefName)
        {
            String[] arraySplit = iDefName.Split('_');
            StringBuilder sb = new StringBuilder(String.Empty);
            foreach (String word in arraySplit)
            {
                sb.Append(toTitleCase(word.ToLower()) + " ");
            }
            return sb.ToString().Trim();
        }
        /// <summary>
        /// Applies (EN-US) MS Cultural TextInfo Formatting
        /// </summary>
        /// <param name="value">String to format</param>
        /// <returns>Formatted string</returns>
        private static string toTitleCase(string value)
        {
            value = value.ToLower();
            return textInfo.ToTitleCase(value);
        }
        /// <summary>
        /// Same as Camel Case w/restrictions.  MedialCasing is the practice of 
        /// writing compound words or phrases such that the first word of the string is 
        /// all lower case and each word or abbreviation in the middle of the phrase 
        /// begins with a capital letter, with no intervening spaces or punctuation.
        /// </summary>
        /// <param name="value">String to format</param>
        /// <returns>Formated String</returns>
        public static string ToMedialCase(string value)
        {
            string[] arraySplit = value.Split('_');
            StringBuilder sb = new StringBuilder(String.Empty);
            for (int i = 0; arraySplit.Length > i; i++)
            {                
                if (i.Equals(0))
                {
                    sb.Append(arraySplit[0].ToLower());
                }
                else
                {
                    sb.Append(toTitleCase(arraySplit[i].ToLower()));
                }                
            }
            return sb.ToString();
        }
    }    
}
