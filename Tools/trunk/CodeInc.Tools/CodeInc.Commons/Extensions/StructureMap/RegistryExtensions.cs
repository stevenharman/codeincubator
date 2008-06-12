using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeInc.Commons.Extensions;
using StructureMap.Configuration.DSL;
using StructureMap.Configuration.DSL.Expressions;

namespace CodeInc.Commons.Extensions.StructureMap
{
    public static class RegistryExtensions
    {
        public static void Autowire<PLUGINTYPEBASE, CONCRETETYPEBASE>(this Assembly assembly, Registry registry)
            where CONCRETETYPEBASE : class, PLUGINTYPEBASE
        {
            var viewBindings = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof (CONCRETETYPEBASE)) && t != typeof (CONCRETETYPEBASE))
                .Where(v => v.GetInterfaces().GetSubtypes<PLUGINTYPEBASE>().Any())
                .Select(t =>
                        new
                            {
                                ConcreteType = t,
                                InterfaceType = GetSubtypes<PLUGINTYPEBASE>(t.GetInterfaces()).Single()
                            });

            viewBindings.Each(vbind => registry.Bind(vbind.ConcreteType, vbind.InterfaceType));
        }

        public static void Bind(this Registry registry, Type CONCRETETYPE, Type PLUGINTYPE)
        {
            var expression = typeof (Registry).GetMethod("ForRequestedType")
                .MakeGenericMethod(new[] {PLUGINTYPE})
                .Invoke(registry, new object[0]);

            typeof (CreatePluginFamilyExpression<>).MakeGenericType(new[] {PLUGINTYPE}).GetMethod("TheDefaultIsConcreteType").
                MakeGenericMethod(new[] {CONCRETETYPE})
                .Invoke(expression, new object[0]);
        }

        public static IEnumerable<Type> GetSubtypes<T>(this IEnumerable<Type> types)
        {
            return types.Where(iface => typeof (T).IsAssignableFrom(iface) && iface != typeof (T));
        }
    }
}