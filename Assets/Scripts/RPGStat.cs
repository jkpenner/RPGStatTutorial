using UnityEngine;
using System.Collections;

public class RPGStat {
    private string _statName;
    private int _statBaseValue;

    public RPGStat() {
        _statName = string.Empty;
        _statBaseValue = 0;
    }

    public string StatName {
        get { return _statName; }
        set { _statName = value; }
    }

    public virtual int StatBaseValue {
        get { return _statBaseValue; }
        set { _statBaseValue = value; }
    }

    public virtual int StatValue {
        get { return StatBaseValue; }
    }
}
