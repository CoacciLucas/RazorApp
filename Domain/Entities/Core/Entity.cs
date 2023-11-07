using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Core;

public class Entity
{
    #region constructor
    protected Entity()
    {
        Id = Guid.NewGuid();
    }


    #endregion constructor

    #region properties

    [Key]
    [DisplayName("Id")]
    [Column(TypeName = "VARCHAR(256)")]
    public Guid Id { get; private set; }

    #endregion properties

    #region methods

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity))
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        return item.Id == Id;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


    #endregion methods

    #region operators

    public static bool operator ==(Entity left, Entity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    #endregion operators
}
