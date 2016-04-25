﻿using System;
using System.Linq;
using System.Reflection;

namespace Photosphere.DependencyInjection.Extensions
{
    public static class AssemblyExtensions
    {
        public static Type GetFirstOrDefaultImplementationTypeOf(this Assembly assembly, Type interfaceType)
        {
            return assembly.GetTypes().FirstOrDefault(t => t.IsImplements(interfaceType));
        }
    }
}