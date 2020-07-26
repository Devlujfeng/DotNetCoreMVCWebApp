using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace FirstApp.Core
{
    public class RelationshipTest : TableEntity
    {
        [Key]
        public int guid { get; set; }


        public int id_internal { get; set; }

        [ForeignKey("id_internal")]
        public EntityTest entityTest { get; set; }

        public int id_internal_ref { get; set; }
        public int typeRelationship { get; set; }
    }
}
