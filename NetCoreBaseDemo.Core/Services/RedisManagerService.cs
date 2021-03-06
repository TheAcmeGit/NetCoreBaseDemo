﻿using NetCoreBaseDemo.Core.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Services
{
    public class RedisManagerService : IRedisMangerService
    {

        private readonly IConnectionMultiplexer _redisConnection;

        public RedisManagerService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            //string redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCachingAOP", "ConnectionString" });//获取连接字符串

            //if (string.IsNullOrWhiteSpace(redisConfiguration))
            //{
            //    throw new ArgumentException("redis config is empty", nameof(redisConfiguration));
            //}
            //this.redisConnenctionString = redisConfiguration;
        }

        /// <summary>
        /// 核心代码，获取连接实例
        /// 通过双if 夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        //private ConnectionMultiplexer _redisConnection
        //{
        //    //如果已经连接实例，直接返回
        //    if (this.redisConnection != null && this.redisConnection.IsConnected)
        //    {
        //        return this.redisConnection;
        //    }
        //    //加锁，防止异步编程中，出现单例无效的问题
        //    lock (redisConnectionLock)
        //    {
        //        if (this.redisConnection != null)
        //        {
        //            //释放redis连接
        //            this.redisConnection.Dispose();
        //        }
        //        try
        //        {
        //            var config = new ConfigurationOptions
        //            {
        //                AbortOnConnectFail = false,
        //                AllowAdmin = true,
        //                ConnectTimeout = 15000,//改成15s
        //                SyncTimeout = 5000,
        //                //Password = "Pwd",//Redis数据库密码
        //                EndPoints = { redisConnenctionString }// connectionString 为IP:Port 如”192.168.2.110:6379”
        //            };
        //            this.redisConnection = ConnectionMultiplexer.Connect(config);
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Redis服务未启用，请开启该服务，并且请注意端口号，本项目使用的的6319，而且我的是没有设置密码。");
        //        }
        //    }
        //    return this.redisConnection;
        //}
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            foreach (var endPoint in this._redisConnection.GetEndPoints())
            {
                var server = this._redisConnection.GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    _redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(string key)
        {
            return _redisConnection.GetDatabase().KeyExists(key);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return _redisConnection.GetDatabase().StringGet(key);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get<TEntity>(string key)
        {
            var value = _redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return Newtonsoft.Json.JsonConvert.DeserializeObject <TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _redisConnection.GetDatabase().KeyDelete(key);
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                //序列化，将object值生成RedisValue
                _redisConnection.GetDatabase().StringSet(key, Newtonsoft.Json.JsonConvert.SerializeObject(value), cacheTime);
            }
        }

        /// <summary>
        /// 增加/修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string key, byte[] value)
        {
            return _redisConnection.GetDatabase().StringSet(key, value, TimeSpan.FromSeconds(120));
        }

    }
}
