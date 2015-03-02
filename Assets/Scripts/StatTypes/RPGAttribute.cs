using UnityEngine;
using System.Collections;

public class RPGAttribute : RPGStatModifiable, IStatProgressable {
    private int _statLevelValue;

    public int StatLevelValue {
        get { return _statLevelValue; }
    }

    public override int StatValue {
        get { return base.StatValue + _statLevelValue; }
    }

    public virtual void UpdateStat(int level) {
        _statLevelValue = level;
    }
}
