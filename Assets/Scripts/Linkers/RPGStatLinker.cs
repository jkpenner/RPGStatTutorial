using UnityEngine;
using System.Collections;
using System;

public abstract class RPGStatLinker {
    private RPGStat _stat;
    
    public event EventHandler OnValueChanged;

    public RPGStat Stat { get { return _stat; } }

    public abstract int Value { get; }

    public RPGStatLinker(RPGStat stat) {
        _stat = stat;
        IStatValueChange valueChange = stat as IStatValueChange;
        if (valueChange != null) {
            valueChange.OnValueChange += OnStatValueChange;
        }
    }

    private void OnStatValueChange(object sender, EventArgs e) {
        if (OnValueChanged != null) {
            OnValueChanged(this, e);
        }
    }
}
