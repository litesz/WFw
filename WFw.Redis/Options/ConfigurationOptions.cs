using System.Text;

namespace WFw.Redis.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// IP:PORT
        /// </summary>
        public string Server { get; set; } = "127.0.0.1:6379";
        /// <summary>
        /// Redis server password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Redis server database
        /// </summary>
        public int DefaultDatabase { get; set; }
        /// <summary>
        /// The asynchronous method automatically uses pipeline, and the 10W concurrent time is 450ms (welcome to feedback)
        /// </summary>
        public bool AsyncPipeline { get; set; }
        /// <summary>
        /// Connection pool size
        /// </summary>
        public int Poolsize { get; set; } = 50;
        /// <summary>
        /// Idle time of elements in the connection pool (MS), suitable for connecting to remote redis server
        /// </summary>
        public int IdleTimeout { get; set; } = 20000;
        /// <summary>
        /// Connection timeout (MS)
        /// </summary>
        public int ConnectTimeout { get; set; } = 5000;
        /// <summary>
        /// Send / receive timeout (MS)
        /// </summary>
        public int SyncTimeout { get; set; } = 10000;
        /// <summary>
        /// Preheat connections, receive values such as preheat = 5 preheat 5 connections
        /// </summary>
        public int Preheat { get; set; } = 5;
        /// <summary>
        /// Follow system exit event to release automatically
        /// </summary>
        public bool AutoDispose { get; set; } = true;
        /// <summary>
        /// Enable encrypted transmission
        /// </summary>
        public bool SSL { get; set; }
        /// <summary>
        /// 是否尝试集群模式，阿里云、腾讯云集群需要设置此选项为 false
        /// </summary>
        public bool Testcluster { get; set; } = true;
        /// <summary>
        /// Execution error, retry attempts
        /// </summary>
        public int Tryit { get; set; }
        /// <summary>
        /// Connection name, use client list command to view
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// key前辍，所有方法都会附带此前辍
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Server))
            {
                throw new System.ArgumentNullException(nameof(Server));
            }
            sb.Append(Server);
            if (!string.IsNullOrWhiteSpace(Password))
            {
                sb.Append(",password=");
                sb.Append(Password);
            }
            if (DefaultDatabase != 0)
            {
                sb.Append(",defaultDatabase=");
                sb.Append(DefaultDatabase);
            }
            if (AsyncPipeline)
            {
                sb.Append(",asyncPipeline=true");
            }
            if (Poolsize != 50)
            {
                sb.Append(",poolsize=");
                sb.Append(Poolsize);
            }
            if (IdleTimeout != 20000)
            {
                sb.Append(",idleTimeout=");
                sb.Append(IdleTimeout);
            }
            if (ConnectTimeout != 5000)
            {
                sb.Append(",connectTimeout=");
                sb.Append(ConnectTimeout);
            }
            if (SyncTimeout != 10000)
            {
                sb.Append(",syncTimeout=");
                sb.Append(SyncTimeout);
            }
            if (Preheat != 5)
            {
                sb.Append(",preheat=");
                sb.Append(Preheat);
            }
            if (AutoDispose == false)
            {
                sb.Append(",autoDispose=false");
            }
            if (SSL)
            {
                sb.Append(",ssl=true");
            }
            if (Testcluster == false)
            {
                sb.Append(",testcluster=false");
            }
            if (Tryit != 0)
            {
                sb.Append(",tryit=");
                sb.Append(Tryit);
            }
            if (!string.IsNullOrWhiteSpace(Name))
            {
                sb.Append(",name=");
                sb.Append(Name);
            }
            if (!string.IsNullOrWhiteSpace(Prefix))
            {
                sb.Append(",prefix=");
                sb.Append(Prefix);
            }
            return sb.ToString();
        }
    }
}
