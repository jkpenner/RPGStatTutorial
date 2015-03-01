using UnityEngine;
using System;
using System.Collections;

public class RPGEntity : MonoBehaviour {
    public event EventHandler<RPGEventLevelArgs> OnEntityLevelChange;
    public event EventHandler<RPGEventModifierArgs> OnEntityModifierChange;

    private string _entityName;
    private int _entityLevel;
    private RPGStats _entityStats;

    public string EntityName {
        get { return _entityName; }
    }

    public int EntityLevel {
        get { return _entityLevel; }
        set {
            if (_entityLevel != value) {
                OnEntityLevelChange(this, new RPGEventLevelArgs(value, _entityLevel));
                _entityLevel = value;
            }
        }
    }

    public RPGStats EntityStats {
        get { return _entityStats; }
    }

    void Awake() {
        _entityStats.Initialize(this);
    }

    void Update() {
        _entityStats.Update(this);
    }
}
