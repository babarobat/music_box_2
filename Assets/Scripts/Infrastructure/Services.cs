using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class Services
    {
        private static readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        public static void Register<TService>(TService service) where TService: IService
        {
            var type = typeof(TService);
            if (_services.ContainsKey(type))
            {
                throw new Exception($"{typeof(TService)} already registered");
            }

            _services[type] = service;
        }
        public static TService Get<TService>() where TService: IService
        {
            if (_services.TryGetValue(typeof(TService), out var result))
            {
                return (TService)result;
            }
            throw new Exception($"{typeof(TService)} is not registered");
        }
    
    }
}