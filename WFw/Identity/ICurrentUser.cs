namespace WFw.Identity
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; set; }
        string GroupId { get; }
        string UserId { get; }
        string[] Roles { get; }
        
        string Phone { get; }

        T UserIdAs<T>();
        T GroupIdAs<T>();
        T Get<T>(string key);
        string Get(string key);

        int GetInt(string key);

        void AddClaim(string key, string value);

        string this[string key] { get; }

        bool ContainRole(string role);

    }
}
