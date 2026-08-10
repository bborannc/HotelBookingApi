using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApi.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
