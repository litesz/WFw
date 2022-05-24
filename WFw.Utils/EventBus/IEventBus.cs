using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Utils.EventBus
{
    /// <summary>
    /// 简易事件总线
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 获得频道
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        EventBusChannel Get(string name);

        /// <summary>
        /// 获得频道
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        EventBusChannel this[string name] { get; }
    }

    /// <summary>
    /// 简易事件总线实现
    /// </summary>
    public class DefaultEventBus : IEventBus
    {
        readonly Dictionary<string, EventBusChannel> channels = new Dictionary<string, EventBusChannel>();
        /// <summary>
        /// 获得频道
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventBusChannel Get(string name)
        {
            if (channels.ContainsKey(name))
            {
                return channels[name];
            }
            var it = new EventBusChannel();
            channels.Add(name, it);
            return it;
        }

        /// <summary>
        /// 获得频道
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventBusChannel this[string name] => Get(name);
    }


    /// <summary>
    /// 建议事件总线频道
    /// </summary>
    public class EventBusChannel
    {
        Action<EventBusArgs> actions;

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public EventBusChannel Register(Action<EventBusArgs> a)
        {
            actions += a;
            return this;
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public EventBusChannel Unregister(Action<EventBusArgs> a)
        {
            actions -= a;
            return this;
        }
        /// <summary>
        /// 投递
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public EventBusChannel Post(EventBusArgs args)
        {
            actions?.Invoke(args);
            return this;
        }

    }

    /// <summary>
    /// 建议事件总线参数
    /// </summary>
    public class EventBusArgs : EventArgs
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public EventBusArgs(object data) : this("default", data)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public EventBusArgs(string type, object data)
        {
            Data = data;
            Id = Guid.NewGuid().ToString("N");
            CreateTime = DateTime.Now;
            Type = type;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class EventBusChannelExtensions
    {
        /// <summary>
        /// 投递
        /// </summary>
        /// <param name="ebc"></param>
        /// <param name="data"></param>
        public static void Post(this EventBusChannel ebc, object data)
        {
            ebc.Post(new EventBusArgs(data));
        }

        /// <summary>
        /// 投递
        /// </summary>
        /// <param name="ebc"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public static void Post(this EventBusChannel ebc, string type, object data)
        {
            ebc.Post(new EventBusArgs(type, data));
        }

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T GetAs<T>(this EventBusArgs args)
        {
            if (args.Data == null)
            {
                return default;
            }
            return (T)args.Data;
        }


    }


    /// <summary>
    /// 
    /// </summary>
    public static class EventBusExtensions
    {
        /// <summary>
        /// 添加建议时间总线
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWFwEventBus(this IServiceCollection services)
        {
            services.TryAddSingleton<IEventBus, DefaultEventBus>();
            return services;
        }

    }
}
