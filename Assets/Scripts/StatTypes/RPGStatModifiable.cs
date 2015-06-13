using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGStatModifiable : RPGStat, IStatModifiable, IStatValueChange {
    private int _statModValue;
    private List<RPGStatModifier> _statMods;
    
    public override int StatValue {
        get { return StatBaseValue + StatModifierValue; }
    }

    public int StatModifierValue {
        get { return _statModValue; }
    }
    
    public RPGStatModifiable() {
        _statModValue = 0;
        _statMods = new List<RPGStatModifier>();
    }

    public void AddModifier(RPGStatModifier mod) {
        _statMods.Add(mod);
    }

    public void RemoveModifier(RPGStatModifier mod) {
        _statMods.Remove(mod);
    }

    public void ClearModifiers() {
        _statMods.Clear();
    }

    public void UpdateModifierValue() {
        _statModValue = 0;
        float statModBaseValueAdd = 0;
        float statModBaseValuePercent = 0;
        float statModTotalValueAdd = 0;
        float statModTotalValuePercent = 0;

        foreach (RPGStatModifier mod in _statMods) {
            switch (mod.Type) {
                case RPGStatModifier.Types.BaseValueAdd:
                    statModBaseValueAdd += mod.Value;
                    break;
                case RPGStatModifier.Types.BaseValuePercent:
                    statModBaseValuePercent += mod.Value;
                    break;
                case RPGStatModifier.Types.TotalValueAdd:
                    statModTotalValueAdd += mod.Value;
                    break;
                case RPGStatModifier.Types.TotalValuePercent:
                    statModTotalValuePercent += mod.Value;
                    break;
            }
        }

        _statModValue = (int)((StatBaseValue * statModBaseValuePercent) + statModBaseValueAdd);
        _statModValue += (int)((StatValue * statModTotalValuePercent) + statModTotalValueAdd);

        ValueChange();
    }

    public event System.EventHandler OnValueChange;
    public void ValueChange() {
        if (OnValueChange != null) {
            OnValueChange(this, new System.EventArgs());
        }
    }
}
