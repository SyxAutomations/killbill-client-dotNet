using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace JavaTransformer
{
    class Program
    {
        private static string modelNameSpace = "namespace Killbill_Client.model {";

        public static void Main(string[] args)
        {
            var directory =
                @"C:\Users\i853985\Documents\visual studio 2015\Projects\Killbill-Client\Killbill-Client\model2\";
            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                var contents = ReadFile(file);
                if(contents != null)
                    SaveFile(file, Transform(contents));
                Console.WriteLine("processed: " + file);
            }
        }

        private static string[] ReadFile(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static void SaveFile(string file, string[] transformedLines)
        {
            var fileInfo = new FileInfo(file);
            var extension = fileInfo.Extension;
            var newName = fileInfo.FullName.Replace(extension, ".cs");
            File.WriteAllLines(newName, transformedLines);
        }

        private static string[] Transform(string[] contents)
        {
            return changeIntegerToInt64(
                lowercaseString(
                    capitalizeAppend(
                        changeHashCodeToGetHashCode(
                            changeBooleanToBool(
                                changeUUID_To_Guid(
                                    removeFinal(
                                        PackageToNamespace(
                                            removeImports(
                                                removeOverride(
                                                    changeToString(
                                                        contents.AsEnumerable()))))))))))).ToArray();
        }

        private static IEnumerable<string> changeToString(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace("toString()", "ToString()"));
        }

        private static IEnumerable<string> removeOverride(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Contains("@Override ") ? "" : line);
        }

        private static IEnumerable<string> removeImports(IEnumerable<string> lines)
        {
            return lines.Select(line => line.StartsWith("import ") ? "" : line);
        }

        private static IEnumerable<string> PackageToNamespace(IEnumerable<string> lines)
        {
            return lines.Select(line => line.StartsWith("package ") ? modelNameSpace : line);
        }

        private static IEnumerable<string> removeFinal(IEnumerable<string> lines)
        {
            var x = lines.Select(line => line.Replace(" final ", " "));
            return x.Select(line => line.Replace("(final ", "("));
        }

        private static IEnumerable<string> changeUUID_To_Guid(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace("UUID ", "Guid "));
        }

        private static IEnumerable<string> changeBooleanToBool(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace("boolean ", "bool ", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> changeHashCodeToGetHashCode(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace("hashCode()", "GetHashCode()", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> capitalizeAppend(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace(".append", ".Append", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> lowercaseString(IEnumerable<string> lines)
        {
            var x = lines.Select(line => line.Replace(" String ", " string ", StringComparison.OrdinalIgnoreCase));
            return x.Select(line => line.Replace("(String ", "(string ", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> changeIntegerToInt64(IEnumerable<string> lines)
        {
            var x =  lines.Select(line => line.Replace(" Integer ", " Int64 ", StringComparison.OrdinalIgnoreCase));
            return x.Select(line => line.Replace("(Integer ", "(Int64 ", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> removeJsonCreator(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Replace("@JsonCreator", ""));
        }
    }
}
