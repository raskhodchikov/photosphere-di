﻿namespace Photosphere.DependencyInjection.UnitTests.TestObjects.Objects
{
    internal class Qiz : IQiz
    {
        private readonly IBar _bar;
        private readonly IFoo _foo;

        public Qiz(IBar bar, IFoo foo)
        {
            _bar = bar;
            _foo = foo;
        }
    }
}