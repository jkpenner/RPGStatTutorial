using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class RPGStatContainer : MonoBehaviour{
    private Dictionary<RPGStatType, RPGStat> _stats;

    public event System.EventHandler OnStatValueChange;

    protected abstract void ConfigureStats();

    private void Awake() {
        if (_stats == null) {
            _stats = new Dictionary<RPGStatType, RPGStat>();
        }
        ConfigureStats();
    }

    private void OnStatValueChanged(object sender, EventArgs e) {
        if (OnStatValueChange != null) {
            OnStatValueChange(sender, e);
        }
    }

    public void AddModifier(RPGStatModifier mod) {
        if (_stats.ContainsKey(mod.StatType)) {
            var stat = GetStat<RPGStatModifiable>(mod.StatType);
            if (stat != null) {
                stat.AddModifier(mod);
                stat.UpdateModifierValue();
            }
        }
    }

    public void RemoveModifer(RPGStatModifier mod) {
        if (_stats.ContainsKey(mod.StatType)) {
            var stat = GetStat<RPGStatModifiable>(mod.StatType);
            if (stat != null) {
                stat.RemoveModifier(mod);
                stat.UpdateModifierValue();
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
            return CreateStat<T>(type);
        }
    }

    protected T CreateStat<T>(RPGStatType type) where T : RPGStat {
        T t = Activator.CreateInstance<T>();
        _stats.Add(type, t);
        var change = t as IStatValueChange;
        if (change != null) {
            change.OnValueChange += OnStatValueChanged;
        }
        return t;
    }

    public bool Contains(RPGStatType type) {
        return _stats.ContainsKey(type);
    }
}
