using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class RPGStats {
    private Dictionary<RPGStatType, RPGStat> _stats;

    public RPGStats() {
        Initialize();
    }

    public void Initialize() {
        ValidateStats();
        ConfigureStats();
        InitializeStats();
    }

    private void ValidateStats() {
        if (_stats == null) {
            _stats = new Dictionary<RPGStatType, RPGStat>();
        }
    }

    private void InitializeStats() {
        foreach (KeyValuePair<RPGStatType, RPGStat> pair in _stats) {
            // Check if the stat need to be intialized 
            // if it does we inialize it.
        }
    }

    protected abstract void ConfigureStats();

    public RPGStat GetStat(RPGStatType type) {
        RPGStat stat;
        if(_stats.TryGetValue(type, out stat)) {
            return stat;
        }
        return null;
    }

    public T GetStat<T>(RPGStatType type) where T : RPGStat {
        return GetStat(type) as T;
    }

    protected T CreateOrGetStat<T>(RPGStatType type) where T : RPGStat {
        if (Contains(type)) {
            return GetStat<T>(type);
        } else {
            T stat = CreateStat<T>(type);
            _stats.Add(type, stat);
            return stat;
        }
    }

    protected T CreateStat<T>(RPGStatType type) where T : RPGStat {
        T t = Activator.CreateInstance<T>();
        return t;
    }

    public bool Contains(RPGStatType type) {
        return _stats.ContainsKey(type);
    }
}
