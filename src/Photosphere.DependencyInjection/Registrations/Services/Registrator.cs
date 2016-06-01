﻿using Photosphere.DependencyInjection.Lifetimes;
using Photosphere.DependencyInjection.Registrations.ValueObjects;

namespace Photosphere.DependencyInjection.Registrations.Services
{
    internal class Registrator : IRegistrator
    {
        private readonly IRegistry _registry;
        private readonly IRegistrationFactory _registrationFactory;

        public Registrator(
            IRegistry registry,
            IRegistrationFactory registrationFactory)
        {
            _registry = registry;
            _registrationFactory = registrationFactory;
        }

        public IRegistrator Register<TService>(Lifetime lifetime = Lifetime.PerRequest)
        {
            var registration = _registrationFactory.Get<TService>(lifetime);
            _registry.Add(registration);
            return this;
        }
    }
}