﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CalcAPI.Model.Base
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
