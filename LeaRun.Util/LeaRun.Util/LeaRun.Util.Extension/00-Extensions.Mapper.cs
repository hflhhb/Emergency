using AutoMapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Util.Extension
{
    /// <summary>
    /// Mapper
    /// </summary>
    public static partial class Extensions
    {
        private static ConcurrentDictionary<Type, ConcurrentDictionary<Type, IMapper>> TypeMappers { get; } = new ConcurrentDictionary<Type, ConcurrentDictionary<Type, IMapper>>();
        public static T Map<T>(this object me, T target = default(T), Action<T> afterMap = null)
        {
            var typeMappers = TypeMappers;
            var sourceType = me.GetType();
            var destinationType = typeof(T);
            if (typeMappers.TryGetValue(sourceType, out var mappers) == false)
            {
                typeMappers.AddOrUpdate(sourceType, key => mappers = new ConcurrentDictionary<Type, IMapper>(), (key, value) => mappers = value);
            }

            if (mappers.TryGetValue(destinationType, out var mapper) == false)
            {
                mappers.AddOrUpdate(destinationType, key =>
                {
                    var config = new MapperConfiguration(expression =>
                    {
                        expression.CreateMissingTypeMaps = true;
                        expression.AllowNullCollections = true;
                        expression.CreateMap(sourceType, destinationType).ForAllMembers(opts =>
                        {
                            opts.Condition((source, destination, sourceMember, destinationMember, context) =>
                                sourceMember != null
                            );
                        });
                    });

                    return mapper = config.CreateMapper();
                }, (key, value) => mapper = value);
            }

            T returnValue;
            if (target == null)
            {
                returnValue = (T)mapper.Map(me, sourceType, destinationType);
            }
            else
            {
                returnValue = (T)mapper.Map(me, target, sourceType, destinationType);
            }

            afterMap?.Invoke(returnValue);

            return returnValue;
        }

        /// <summary>
        /// 需要提前初始化
        /// </summary>
        /// <typeparam name="TSrc"></typeparam>
        /// <typeparam name="TDesc"></typeparam>
        /// <param name="me"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static TDesc Map<TSrc, TDesc>(this TSrc me, TDesc target = default(TDesc))
        {
            if (target == null)
            {
                return Mapper.Map<TSrc, TDesc>(me);
            }
            else
            {
                return Mapper.Map<TSrc, TDesc>(me, target);
            }

        }

    }
}
