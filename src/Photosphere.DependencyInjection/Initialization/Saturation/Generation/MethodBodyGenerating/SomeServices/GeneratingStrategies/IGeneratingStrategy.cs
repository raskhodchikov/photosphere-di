﻿using System.Reflection.Emit;
using Photosphere.DependencyInjection.Initialization.Saturation.Generation.MethodBodyGenerating.ValueObjects;

namespace Photosphere.DependencyInjection.Initialization.Saturation.Generation.MethodBodyGenerating.SomeServices.GeneratingStrategies
{
    internal interface IGeneratingStrategy
    {
        LocalBuilder Generate(GeneratingDesign design);
    }
}