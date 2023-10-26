namespace AccountingSubsystem.SeedWork.Domain;

public abstract class Entity
{
    private int? _requestedHashCode;
    private Guid? _Id;

    public virtual Guid? Id { get => _Id; private set => _Id = value; }
    public virtual DateTime CreateDate { get; private set; }
    public virtual DateTime UpdateDate { get; private set; }
    [JsonIgnore]
    public virtual bool IsDeleted { get; private set; }
    [JsonIgnore]
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();


    private List<INotification>? _domainEvents;

    protected Entity(Guid id)
    {
        _Id = id /*?? throw new ArgumentNullException(nameof(id))*/;
    }

    protected Entity(Guid id, DateTime createDate, DateTime updateTime)
    {
        _Id = id /*?? throw new ArgumentNullException(nameof(id))*/;
        CreateDate = createDate;
        UpdateDate = updateTime;
    }
    protected Entity()
    {
    }


    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return Equals(Id, default(string));
    }
    public bool Equals(Entity? other)
    {
        if (other is null || Id is null )
            return false;
        else
            return Id.Equals(other.Id);
    }
    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is Entity))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        if (item.IsTransient() || IsTransient())
            return false;
        else
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return item._Id.Equals(_Id); //item.Id == this.Id;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public override int GetHashCode()
    {
        if (!IsTransient() && _Id != null)
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/intelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (Equals(left, null))
            return Equals(right, null) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }


    public virtual void Update()
    {
        UpdateDate = DateTime.Now;
    }
    public virtual void UpdateById(Guid id)
    {
        _Id = id;
        UpdateDate = DateTime.Now;
        IsDeleted = false;
    }
    public virtual void Delete()
    {
        IsDeleted = true;
        UpdateDate = DateTime.Now;
    }
    public virtual void Create()
    {
        _Id = default;
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        IsDeleted = false;
    }

    //public bool Equals(Entity<OperatorId> other)
    //{
    //    throw new NotImplementedException();
    //}
}



