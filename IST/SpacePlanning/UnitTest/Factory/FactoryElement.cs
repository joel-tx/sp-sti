using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    // TODO Create Abstract Factory 
    public static class FactoryElement
    {
        public static Element RandomCreate()
        {
            return new Element()
            {
                ElementId = Guid.NewGuid(),
                Graphic = FactoryGraphic.RandomCreate(),
                ElementType = FactoryElementType.RandomCreate(),
                Label = nameof(Element.Label),
                Description = nameof(Element.Description),
            };
        }
   }
}
