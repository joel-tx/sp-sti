using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPhysicalElement
    {
        static Random _random = new Random();

        public static PhysicalElement RandomCreate()
        {
            return new PhysicalElement()
            {
                PhysicalElementId = Guid.NewGuid(),
                Element = FactoryElement.RandomCreate(),
                Layer = FactoryLayer.RandomCreate(), 
                Startx = _random.Next(),
                Starty = _random.Next(),
                Endx = _random.Next(),
                Endy = _random.Next(),
                Zorder = _random.Next(),
                Rotation = _random.Next(),
                Color = nameof(PhysicalElement.Startx),
                Label = nameof(PhysicalElement.Startx),
                Description = nameof(PhysicalElement.Startx),
                Barcode = nameof(PhysicalElement.Startx)
            };
        }
   }
}