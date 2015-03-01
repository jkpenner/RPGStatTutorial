using UnityEngine;
using System.Collections;

public class RPGStat {
    /// <summary>
    /// The Name of the RPGStat. Used mostly for UI purposes
    /// </summary>
    private string _statName;

    /// <summary>
    /// The Base value of the stat
    /// </summary>
    private int _statBaseValue;

    /// <summary>
    /// Initializes a new instance of the RPGStat class
    /// </summary>
    public RPGStat() {
        _statName = string.Empty;
        _statBaseValue = 0;
    }

    /// <summary>
    /// Gets or sets the _statName
    /// </summary>
    public string StatName {
        get { return _statName; }
        set { _statName = value; }
    }

    /// <summary>
    /// [Overridable] Gets or sets the _statBaseValue
    /// </summary>
    public virtual int StatBaseValue {
        get { return _statBaseValue; }
        set { _statBaseValue = value; }
    }

    /// <summary>
    /// [Overridable] Gets the stat's value.
    /// </summary>
    public virtual int StatValue {
        get { return StatBaseValue; }
    }
}
