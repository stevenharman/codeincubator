﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ContextInterfaceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbmlFile = args[0];
            string outputFile = args[1];

            //string dbmlFile = @"C:\Phoenix\trunk\BUSINESS\VRS.VCS.Business\Vcs.dbml";

            if (!File.Exists(dbmlFile))
                throw new ApplicationException("Invalid dbml file specified.");

            ContextDefinition definition = ReadDefinitionFromFile(dbmlFile);

            IList<ContextType> types = ReadTypesFromFile(dbmlFile);

            IList<ContextFunction> functions = ReadFunctionsFromFile(dbmlFile);

            var generator = new Generator(definition, types, functions);
            
            bool foundFile = false;

            FileAttributes savedAttrs = FileAttributes.Normal;

            if (File.Exists(outputFile))
            {
                savedAttrs = File.GetAttributes(outputFile);
                File.SetAttributes(outputFile, FileAttributes.Normal);
                foundFile = true;
            }

            generator.GenerateContext(outputFile);
            Console.WriteLine(outputFile + " written.");

            if (foundFile)
            {
                File.SetAttributes(outputFile, savedAttrs);
            }
        }

        private static ContextDefinition ReadDefinitionFromFile(string file)
        {
            var reader = new StreamReader(file);
            var document = new XmlDocument();
            document.Load(reader);
            XmlNode database = document.GetElementsByTagName("Database").OfType<XmlNode>().FirstOrDefault();

            reader.Close();

            return new ContextDefinition(database);
        }

        private static IList<ContextFunction> ReadFunctionsFromFile(string file)
        {
            var reader = new StreamReader(file);
            var document = new XmlDocument();
            document.Load(reader);
            List<XmlNode> functions = document.GetElementsByTagName("Function").OfType<XmlNode>().ToList();

            reader.Close();

            return functions.Select(node => new ContextFunction(node)).ToList();
        }

        private static IList<ContextType> ReadTypesFromFile(string file)
        {
            var reader = new StreamReader(file);

            var document = new XmlDocument();
            document.Load(reader);
            List<XmlNode> tables = document.GetElementsByTagName("Table").OfType<XmlNode>().ToList();

            reader.Close();

            return tables.Select(node => new ContextType(node)).ToList();
        }
    }
}