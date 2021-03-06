﻿using CookComputing.XmlRpc;
using System;

namespace Popcorn.OSDB.Backend
{
    public static class SimpleObjectMapper
    {
        public static T MapToObject<T>(XmlRpcStruct obj) where T : class
        {
            T instance = Activator.CreateInstance<T>();

            var destinationType = typeof(T);
            var members = destinationType.GetFields();

            foreach (var member in members)
            {
                if (obj.ContainsKey(member.Name))
                {
                    member.SetValue(instance, obj[member.Name]);
                }
            }

            return instance;
        }
    }
}