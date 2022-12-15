﻿using BaseProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Domain.EntityModels.BaseModels
{
    public class BaseEntityModel
    {
        public BaseEntityModel()
        {
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            CreatedBy = -1;
            LastModifiedBy = -1;
            ObjectStatus = ObjectStatus.NonDeleted;
            Status = Status.Active;
        }
        [Key]
        public Guid ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int LastModifiedBy { get; set; }

        public ObjectStatus ObjectStatus { get; set; }

        public Status Status { get; set; }
    }
}
