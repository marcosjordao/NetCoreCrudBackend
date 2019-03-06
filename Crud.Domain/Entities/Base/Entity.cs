using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (this.Id == 0)
                return base.GetHashCode();
            else
                return this.Id.GetHashCode() ^ 31;
        }

    }
}
