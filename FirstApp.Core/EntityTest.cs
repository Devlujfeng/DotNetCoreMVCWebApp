using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstApp.Core
{
    public class EntityTest : TableEntity
    {
        [Key]
        public int id_internal { get; set; }
        public int entity_type { get; set; }

        public ICollection<RelationshipTest> RelationshipTest { get; set; }
    }
}
