using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ObjectPool
{
    public sealed class PoolMono<T> where T : MonoBehaviour
    {
        public T prefab { get;}
        public bool autoExpand { get; set; }
        public Transform container { get; }
        public List<T> Pool;

        public PoolMono(T prefab, int count)
        {
            this.prefab = prefab;
            container = null;
            CreatePool(count);
        }

        public PoolMono(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            Pool = new List<T>();
            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createObject = Object.Instantiate(prefab, container);
            createObject.gameObject.SetActive(isActiveByDefault);
            Pool.Add(createObject);
            return createObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in Pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    mono.gameObject.SetActive(true);
                    element = mono;
                    return true;
                }
            }
            element = null;
            return false;
        }

        public T GetFreeElement(bool isActiveByDefault = false)
        {
            if (HasFreeElement(out var element))
                return element;

            if (autoExpand)
                return CreateObject(isActiveByDefault);

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");
        }
    }
}