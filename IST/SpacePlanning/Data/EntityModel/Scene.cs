using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Scene
    {
        public Scene()
        {
            Layer = new HashSet<Layer>();
            Lock = new HashSet<Lock>();
        }

        public Guid SceneId { get; set; }
        public Guid PlanId { get; set; }
        public Guid SceneTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Description { get; set; }

        public Plan Plan { get; set; }
        public SceneType SceneType { get; set; }
        public ICollection<Layer> Layer { get; set; }
        public ICollection<Lock> Lock { get; set; }
    }
}
