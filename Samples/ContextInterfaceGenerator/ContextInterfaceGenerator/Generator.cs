using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ContextInterfaceGenerator
{
    public class Generator
    {
        private readonly ContextDefinition _definition;
        private readonly IEnumerable<ContextType> _types;
        private readonly IEnumerable<ContextFunction> _functions;

        public Generator(ContextDefinition definition, IEnumerable<ContextType> types, IEnumerable<ContextFunction> functions)
        {
            _definition = definition;
            _types = types;
            _functions = functions;
        }

        private int _tabCount;
        private string _outputFile;

        private TextWriter _writer;
        public TextWriter Writer
        {
            get
            {
                if (_writer == null)
                    _writer = new StreamWriter(_outputFile);
                return _writer;
            }
            set { _writer = value; }
        }

        private string InterfaceName
        {
            get { return "I" + _definition.ClassName; }
        }

        private string ProxyName
        {
            get { return _definition.ClassName + "Proxy"; }
        }

        private string ClassName
        {
            get { return _definition.ClassName; }
        }

        public void GenerateContext(string outputFile)
        {
            _outputFile = outputFile;

            OutputNamespace();

            GenerateInterface();

            GenerateProxy();

            CloseBrace();

            Writer.Close();
            Writer = null;
        }

        private void GenerateProxy()
        {
            WriteProxyHeader();
            WriteProxyConstructor();
            WriteProxyBasics();
            WriteProxyTypes();
            WriteProxyFunctions();
            CloseBrace();
        }

        private void WriteProxyTypes()
        {
            foreach(ContextType type in _types)
            {
                WriteProxyType(type);
            }
        }

        private void WriteProxyType(ContextType type)
        {
            Writer.WriteLine();
            Writer.WriteLine(Tabs + string.Format("public ITable<{0}> {1}", type.ClassName, type.MemberName));
            OpenBrace();
            Writer.WriteLine(Tabs + string.Format("get {{ return new TableProxy<{0}>(_context.{1}); }}", type.ClassName, type.MemberName));
            CloseBrace();
        }

        private void WriteProxyBasics()
        {
            WriteProxyMethod("CreateDatabase");
            WriteProxyMethod("DatabaseExists", "bool");
            WriteProxyMethod("DeleteDatabase");
            WriteProxyMethod("Dispose");
            WriteProxyMethod("ExecuteCommand", "int", "string command, params object[] parameters", "command, parameters");
            WriteProxyMethod("ExecuteQuery<TResult>", "IEnumerable<TResult>", "string query, params object[] parameters", "query, parameters");
            WriteProxyMethod("ExecuteQuery", "IEnumerable", "Type elementType, string query, params object[] parameters", "elementType, query, parameters");
            WriteProxyMethod("GetChangeSet", "ChangeSet");
            WriteProxyMethod("GetCommand", "DbCommand", "IQueryable query", "query");
            WriteGetTableMethod();
            WriteProxyMethod("GetTable", "ITable", "Type type", "type");
            WriteProxyMethod("Refresh", "RefreshMode mode, params object[] entities", "mode, entities");
            WriteProxyMethod("Refresh", "RefreshMode mode, IEnumerable entities", "mode, entities");
            WriteProxyMethod("Refresh", "RefreshMode mode, object entity", "mode, entity");
            WriteProxyMethod("SubmitChanges");
            WriteProxyMethod("SubmitChanges", "ConflictMode failureMode", "failureMode");
            WriteProxyMethod("Translate<TResult>", "IEnumerable<TResult>", "DbDataReader reader", "reader");
            WriteProxyMethod("Translate", "IMultipleResults", "DbDataReader reader", "reader");
            WriteProxyMethod("Translate", "IEnumerable", "Type elementType, DbDataReader reader", "elementType, reader");
            WriteProxyProperty("ChangeConflicts", "ChangeConflictCollection", true, false);
            WriteProxyProperty("CommandTimeout", "int", true, true);
            WriteProxyProperty("Connection", "DbConnection", true, false);
            WriteProxyProperty("DeferredLoadingEnabled", "bool", true, true);
            WriteProxyProperty("LoadOptions", "DataLoadOptions", true, true);
            WriteProxyProperty("Log", "TextWriter", true, true);
            WriteProxyProperty("Mapping", "MetaModel", true, false);
            WriteProxyProperty("ObjectTrackingEnabled", "bool", true, true);
            WriteProxyProperty("Transaction", "DbTransaction", true, true);
        }

        private void WriteGetTableMethod()
        {
            Writer.WriteLine();
            Writer.WriteLine(Tabs + "public ITable<TEntity> GetTable<TEntity>() where TEntity : class");
            OpenBrace();
            Writer.WriteLine(Tabs + "return new TableProxy<TEntity>(_context.GetTable<TEntity>());");
            CloseBrace();
        }

        private void WriteProxyProperty(string Method, string Return, bool hasGet, bool hasSet)
        {
            Writer.WriteLine();
            Writer.WriteLine(Tabs + string.Format("public {0} {1}", Return, Method));
            OpenBrace();
            
            if (hasGet)
                Writer.WriteLine(Tabs + string.Format("get {{ return _context.{0}; }}", Method));

            if (hasSet)
                Writer.WriteLine(Tabs + string.Format("set {{ _context.{0} = value; }}", Method));
            
            CloseBrace();
        }

        private void WriteProxyMethod(string Method, string Return, string Signature, string Call)
        {
            Writer.WriteLine();
            Writer.WriteLine(Tabs + string.Format("public {0} {1}({2})", Return, Method, Signature));
            OpenBrace();
            Writer.WriteLine(Tabs + string.Format("{0}_context.{1}({2});", 
                Return == "void" ? string.Empty : "return ",
                Method, Call));
            CloseBrace();
        }

        private void WriteProxyMethod(string Method, string Signature, string Call)
        {
            WriteProxyMethod(Method, "void", Signature, Call);
        }

        private void WriteProxyMethod(string Method)
        {
            WriteProxyMethod(Method, "void", string.Empty, string.Empty);
        }

        private void WriteProxyMethod(string Method, string Return)
        {
            WriteProxyMethod(Method, Return, string.Empty, string.Empty);
        }

        private void WriteProxyConstructor()
        {
            Writer.WriteLine(Tabs + string.Format("private readonly {0} _context;", ClassName));
            Writer.WriteLine();
            Writer.WriteLine(Tabs + string.Format("public {0}({1} context)", ProxyName, ClassName));
            OpenBrace();
            Writer.WriteLine(Tabs + "_context = context;");
            CloseBrace();
        }

        private void WriteProxyHeader()
        {
            Writer.WriteLine();
            Writer.WriteLine(Tabs + string.Format("public partial class {0} : {1}", ProxyName, InterfaceName));
            OpenBrace();
        }

        private void WriteInterfaceHeader()
        {
            Writer.WriteLine(Tabs + string.Format("public partial interface {0}", InterfaceName));
            OpenBrace();
        }

        private void GenerateInterface()
        {
            WriteInterfaceHeader();
            WriteInterfaceBasics();
            WriteInterfaceTypes();
            WriteInterfaceFunctions();
            CloseBrace();
        }

        private void WriteInterfaceBasics()
        {
            Writer.WriteLine(Tabs + "void CreateDatabase();");
            Writer.WriteLine(Tabs + "bool DatabaseExists();");
            Writer.WriteLine(Tabs + "void DeleteDatabase();");
            Writer.WriteLine(Tabs + "void Dispose();");
            Writer.WriteLine(Tabs + "int ExecuteCommand(string command, params object[] parameters);");
            Writer.WriteLine(Tabs + "IEnumerable<TResult> ExecuteQuery<TResult>(string query, params object[] parameters);");
            Writer.WriteLine(Tabs + "IEnumerable ExecuteQuery(Type elementType, string query, params object[] parameters);");
            Writer.WriteLine(Tabs + "ChangeSet GetChangeSet();");
            Writer.WriteLine(Tabs + "DbCommand GetCommand(IQueryable query);");
            Writer.WriteLine(Tabs + "ITable<TEntity> GetTable<TEntity>() where TEntity : class;");
            Writer.WriteLine(Tabs + "ITable GetTable(Type type);");
            Writer.WriteLine(Tabs + "void Refresh(RefreshMode mode, params object[] entities);");
            Writer.WriteLine(Tabs + "void Refresh(RefreshMode mode, IEnumerable entities);");
            Writer.WriteLine(Tabs + "void Refresh(RefreshMode mode, object entity);");
            Writer.WriteLine(Tabs + "void SubmitChanges();");
            Writer.WriteLine(Tabs + "void SubmitChanges(ConflictMode failureMode);");
            Writer.WriteLine(Tabs + "IEnumerable<TResult> Translate<TResult>(DbDataReader reader);");
            Writer.WriteLine(Tabs + "IMultipleResults Translate(DbDataReader reader);");
            Writer.WriteLine(Tabs + "IEnumerable Translate(Type elementType, DbDataReader reader);");
            Writer.WriteLine(Tabs + "ChangeConflictCollection ChangeConflicts { get; }");
            Writer.WriteLine(Tabs + "int CommandTimeout { get; set; }");
            Writer.WriteLine(Tabs + "DbConnection Connection { get; }");
            Writer.WriteLine(Tabs + "bool DeferredLoadingEnabled { get; set; }");
            Writer.WriteLine(Tabs + "DataLoadOptions LoadOptions { get; set; }");
            Writer.WriteLine(Tabs + "TextWriter Log { get; set; }");
            Writer.WriteLine(Tabs + "MetaModel Mapping { get; }");
            Writer.WriteLine(Tabs + "bool ObjectTrackingEnabled { get; set; }");
            Writer.WriteLine(Tabs + "DbTransaction Transaction { get; set; }");
        }

        //Functions
        //If there is no return type --
        //If the IsComposable is true, then return IQueryable<#ElementType#> and not ISingleResult
        //public ISingleResult<#ElementType#> #Method# (#ParameterType# #ParameterName#)
        //{
        //  return _context.#Method#(#ParameterName);
        //}
        //If Direction is InOut then ref parameter
        //All parameters for functions are nullable.

        private void WriteProxyFunctions()
        {
            foreach (ContextFunction function in _functions)
            {
                WriteProxyFunction(function);
            }
        }

        private void WriteProxyFunction(ContextFunction function)
        {
            Writer.WriteLine();
            if (!string.IsNullOrEmpty(function.ReturnType))
                Writer.WriteLine(Tabs + string.Format("public {0}{3} {1}({2})", function.ReturnType, function.MethodName,
                    function.GetSignature(), function.IsComposable ? "?" : string.Empty));
            else
                Writer.WriteLine(Tabs + string.Format("public {0}<{1}> {2}({3})",
                                                      function.IsComposable ? "IQueryable" : "ISingleResult",
                                                      function.ReturnElement, function.MethodName,
                                                      function.GetSignature()));
            OpenBrace();
            Writer.WriteLine(Tabs + string.Format("return _context.{0}({1});", function.MethodName, function.GetCall()));
            CloseBrace();
        }

        private void WriteInterfaceFunctions()
        {
            foreach(ContextFunction function in _functions)
            {
                WriteInterfaceFunction(function);
            }
        }

        private void WriteInterfaceFunction(ContextFunction function)
        {
            if (!string.IsNullOrEmpty(function.ReturnType))
                Writer.WriteLine(Tabs + string.Format("{0}{3} {1}({2});", function.ReturnType, function.MethodName,
                    function.GetSignature(), function.IsComposable ? "?" : string.Empty));
            else
                Writer.WriteLine(Tabs + string.Format("{0}<{1}> {2}({3});",
                                                      function.IsComposable ? "IQueryable" : "ISingleResult",
                                                      function.ReturnElement, function.MethodName,
                                                      function.GetSignature()));
        }

        private void WriteInterfaceTypes()
        {
            foreach (ContextType type in _types)
            {
                WriteInterfaceType(type);
            }
        }

        private void WriteInterfaceType(ContextType type)
        {
            Writer.WriteLine(Tabs + string.Format("ITable<{0}> {1} {{ get; }}", type.ClassName, type.MemberName));
        }

        private void OutputNamespace()
        {
            Writer.WriteLine("using System;");
            Writer.WriteLine("using System.Data.Linq;");
            Writer.WriteLine("using System.Collections;");
            Writer.WriteLine("using System.Collections.Generic;");
            Writer.WriteLine("using System.Data.Common;");
            Writer.WriteLine("using System.Data.Linq.Mapping;");
            Writer.WriteLine("using System.IO;");
            Writer.WriteLine("using System.Linq;");
            Writer.WriteLine("");
            Writer.WriteLine("namespace " + _definition.EntityNamespace);
            OpenBrace();
        }

        private void OpenBrace()
        {
            Writer.WriteLine(Tabs + "{");
            _tabCount++;
        }

        private void CloseBrace()
        {
            _tabCount--;
            Writer.WriteLine(Tabs + "}");
        }

        private string Tabs
        {
            get { return _tabCount > 0 ? new string('\t', _tabCount) : string.Empty; }
        }

        //public partial interface I***DataContext
        //
        //

        //public partial class DataContextProxy : I***DataContext
        //
        //

        //Tables
        //Interface:
        //ITable<#ClassName#> #MemberName { get; }
        //
        //Class:
        //public ITable<#ClassName#> #MemberName#
        //{
        //  get
        //  {
        //      return new TableProxy<#ClassName#>(_context.#MemberName#);
        //  }
        //}


    }
}
