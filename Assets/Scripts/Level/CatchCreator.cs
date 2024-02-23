using System;
using Services.Constants;
using Services.PoolObjectSystem.Pool;
using UnityEngine;

namespace Level
{
    [Serializable]
    public abstract class CatchCreator
    {
        [SerializeField] protected GameObject _prefab;
        [SerializeField] protected Transform _container;
        
        public abstract void CreatePool(ref ObjectPool pool);
    }
}