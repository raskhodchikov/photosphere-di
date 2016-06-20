using System.Linq;

namespace Photosphere.DependencyInjection.Generators.MethodBodyGenerating.Strategies
{
    internal class EnumerableProvidingGeneratingStrategy : GeneratingStrategyBase, IEnumerableProvidingGeneratingStrategy
    {
        protected override void GenerateInstantiating(GeneratingDesign design)
        {
            var parameters = design.ObjectGraph.Children.Select(og => og.GeneratingStrategy.Generate(new GeneratingDesign
            {
                Designer = design.Designer,
                ObjectGraph = og
            })).ToList();
            var elementType = design.ObjectGraph.ImplementationType.GetElementType();

            design.Designer
                .CreateNewArray(elementType, parameters.Count)
                .FillArray(parameters);
        }
    }
}