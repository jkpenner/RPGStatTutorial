using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class RPGStats {
    private Dictionary<RPGStatType, RPGStat> _stats;

    public RPGStats() {
        Initialize(null);
    }

    public RPGStats(RPGEntity entity) {
        Initialize(entity);
    }

    public void Initialize(RPGEntity entity) {
        entity.OnEntityLevelChange += OnEntityLevelChanged;

        ValidateStats();
        ConfigureStats();
        InitializeStats(entity);
    }

    private void ValidateStats() {
        if (_stats == null) {
            _stats = new Dictionary<RPGStatType, RPGStat>();
        }
    }

    private void InitializeStats(RPGEntity entity) {
        foreach (KeyValuePair<RPGStatType, RPGStat> pair in _stats) {
            var initStat = pair.Value as IStatInitalizable;
            if (initStat != null) {
                initStat.OnInitialize(entity);
            }
        }
    }

    public void Update(RPGEntity entity) {
        foreach (KeyValuePair<RPGStatType, RPGStat> pair in _stats) {
            var updateStat = pair.Value as IStatUpdatable;
            if (updateStat != null) {
                updateStat.OnUpdate(entity);
            }
        }
    }

    protected abstract void ConfigureStats();

    public void OnEntityLevelChanged(object sender, RPGEventLevelArgs args) {
        foreach (KeyValuePair<RPGStatType, RPGStat> pair in _stats) {
            var progStat = pair.Value as IStatProgressable;
            if (progStat != null) {
                progStat.UpdateStat(args.Level);
            }
        }
    }


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
