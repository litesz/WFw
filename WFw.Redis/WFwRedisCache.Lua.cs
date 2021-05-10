using Microsoft.Extensions.Options;
using WFw.Cache;
using WFw.Redis.Options;
using System.Linq;
using CSRedis;

namespace WFw.Redis
{
    /// <summary>
    /// lua
    /// </summary>
    public partial class WFwRedisCache : IRedisCache
    {
        /// <summary>
        /// 使用 Lua 解释器执行脚本。
        /// </summary>
        /// <param name="script"> Lua 脚本</param>
        /// <param name="key">用于定位分区节点，不含prefix前辍</param>
        /// <param name="args">附加参数，在 Lua 中通过全局变量 ARGV 数组访问，访问的形式和 KEYS 变量类似( ARGV[1] 、 ARGV[2] ，诸如此类)</param>
        /// <returns></returns>
        public object Eval(string script, string key, params object[] args) => RedisHelper.Eval(script, key, args);

        /// <summary>
        /// 根据给定的 sha1 校验码，执行缓存在服务器中的脚本。
        /// 将脚本缓存到服务器的操作可以通过 SCRIPT LOAD 命令进行。
        /// </summary>
        /// <param name="sha1"> 通过 SCRIPT LOAD 生成的 sha1 校验码。</param>
        /// <param name="key">用于定位分区节点，不含prefix前辍</param>
        /// <param name="args"></param>
        /// <returns>附加参数，在 Lua 中通过全局变量 ARGV 数组访问，访问的形式和 KEYS 变量类似( ARGV[1] 、 ARGV[2] ，诸如此类)</returns>
        public object EvalSHA(string sha1, string key, params object[] args) => RedisHelper.EvalSHA(sha1, key, args);

        /// <summary>
        /// 用于校验指定的脚本是否已经被保存在缓存当中。
        /// </summary>
        /// <param name="sha1s">通过 SCRIPT LOAD 生成的 sha1 校验码。</param>
        /// <returns> 一个列表，包含 0 和 1 ，前者表示脚本不存在于缓存，后者表示脚本已经在缓存里面了。
        /// 列表中的元素和给定的 SHA1 校验和保持对应关系，比如列表的第三个元素的值就表示第三个 SHA1 校验和所指定的脚本在缓存中的状态。 </returns>
        public bool[] ScriptExists(params string[] sha1s) => RedisHelper.ScriptExists(sha1s);

        /// <summary>
        /// 清除所有 Lua 脚本缓存。
        /// </summary>
        public void ScriptFlush() => RedisHelper.ScriptFlush();

        /// <summary>
        /// 杀死当前正在运行的 Lua 脚本，当且仅当这个脚本没有执行过任何写操作时，这个命令才生效。
        /// 这个命令主要用于终止运行时间过长的脚本，比如一个因为 BUG 而发生无限循环的脚本。
        /// SCRIPT KILL 执行之后，当前正在运行的脚本会被杀死，执行这个脚本的客户端会从 EVAL 命令的阻塞当中退出，并收到一个错误作为返回值。 
        /// </summary>
        public void ScriptKill() => RedisHelper.ScriptKill();

        /// <summary>
        /// 用于将脚本 script 添加到脚本缓存中，但并不立即执行这个脚本。
        /// EVAL 命令也会将脚本添加到脚本缓存中，但是它会立即对输入的脚本进行求值。
        /// 如果给定的脚本已经在缓存里面了，那么不执行任何操作。
        /// 在脚本被加入到缓存之后，通过 EVALSHA 命令，可以使用脚本的 SHA1 校验和来调用这个脚本。
        /// 脚本可以在缓存中保留无限长的时间，直到执行 SCRIPT FLUSH 为止。 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public string ScriptLoad(string script) => RedisHelper.ScriptLoad(script);


    }
}
