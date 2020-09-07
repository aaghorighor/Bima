namespace Suftnet.Co.Bima.Core
{
    using System;
    using System.Collections.Generic;
  
    public class Singleton<T> : Singleton
    {
        static T _instance;
    
        public static T Instance
        {
            get =>  _instance;
            set
            {
                _instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    public class Singleton
    {
        static Singleton()
        {
            _allSingletons = new Dictionary<Type, object>();
        }

        private static readonly IDictionary<Type, object> _allSingletons;

        public static IDictionary<Type, object> AllSingletons
        {
            get => _allSingletons;
        }
    }

    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }
       
        public new static IList<T> Instance
        {
            get => Singleton<IList<T>>.Instance; 
        }
    }

    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }
       
        public new static IDictionary<TKey, TValue> Instance
        {
            get => Singleton<Dictionary<TKey, TValue>>.Instance; 
        }
    }

}
