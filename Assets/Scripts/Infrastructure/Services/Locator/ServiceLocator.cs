using System;
using System.Collections.Generic;

namespace Infrastructure.Services.Locator
{
    public class ServiceLocator
    {
        public static ServiceLocator Container => _container ??= new ServiceLocator();
        private static ServiceLocator _container;
        
        private readonly Dictionary<Type, IService> _services = new();
        
        public void Register<TService>(TService service) where TService: IService
        {
            var type = typeof(TService);
            if (_services.ContainsKey(type))
            {
                throw new Exception($"{typeof(TService)} already registered");
            }

            _services[type] = service;
        }
        
        public TService Get<TService>() where TService: IService
        {
            if (_services.TryGetValue(typeof(TService), out var result))
            {
                return (TService)result;
            }
            throw new Exception($"{typeof(TService)} is not registered");
        }
    }
}