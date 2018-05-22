using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class SceneType
    {
        public SceneType()
        {
            Scene = new HashSet<Scene>();
        }

        public Guid SceneTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Scene> Scene { get; set; }
    }
}
