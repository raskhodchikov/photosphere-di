﻿using System;
using System.Collections.Generic;
using Photosphere.DependencyInjection.Initialization.Registrations.ValueObjects;
using Photosphere.DependencyInjection.LifetimeManagement;

namespace Photosphere.DependencyInjection.Resolving
{
    internal class Resolver : IResolver
    {
        private readonly IRegistry _registry;
        private readonly IScopeKeeper _scopeKeeper;

        public Resolver(IRegistry registry, IScopeKeeper scopeKeeper)
        {
            _registry = registry;
            _scopeKeeper = scopeKeeper;
        }

        public TService GetInstance<TService>()
        {
            return Get<TService>();
        }

        public object GetInstance(Type type)
        {
            return Get(type);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return Get<IEnumerable<TService>>();
        }

        private T Get<T>()
        {
            var registration = _registry[typeof(T)];
            var instantiateFunction = (Func<object[], T>) registration.InstanceProvidingFunction;
            return instantiateFunction.Invoke(_scopeKeeper.PerContainerScope.AvailableInstances);
        }

        private object Get(Type type)
        {
            var registration = _registry[type];
            var instantiateFunction = (Func<object[], object>) registration.InstanceProvidingFunction;
            return instantiateFunction.Invoke(_scopeKeeper.PerContainerScope.AvailableInstances);
        }
    }
}