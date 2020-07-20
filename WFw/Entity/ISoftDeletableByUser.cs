namespace WFw.Entity
{
    public interface ISoftDeletableByUser<TUserId> : ISoftDeletable
    {
        TUserId DeletedUserId { get; set; }

     
    }

}
