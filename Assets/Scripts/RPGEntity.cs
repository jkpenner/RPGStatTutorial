using UnityEngine;
using System;
using System.Collections;

public class RPGEntity : MonoBehaviour {
    public event EventHandler<RPGEventLevelArgs> OnEntityLevelChange;
    public event EventHandler<RPGEventModifierArgs> OnEntityModifierChange;

    private string _entityName;

    private int _entityLevel;
    private int _expCurrent;
    private int _expRequired;

    private RPGStats _entityStats;

    public string EntityName {
		get { return _entityName; }
		set { _entityName = value; }
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
        _entityStats = new RPGStatsDefault(this);
    }

    void Update() {
        _entityStats.Update(this);
    }

    #region Leveling
    public int ExpCurrent {
        get { return _expCurrent; }
        set { SetCurrentExperience(value); }
    }

    public int ExpRequired {
        get { return _expRequired; }
    }

    public void ModifyExp(int amount) {
        SetCurrentExperience(_expCurrent + amount);
    }

    private void SetCurrentExperience(int value) {
        _expCurrent = value;
        CheckCurrentExp();
    }

    private void CheckCurrentExp() {
        if (_expCurrent > _expRequired) {
            _expCurrent -= _expRequired;
            IncreaseCurrentLevel();
            UpdateRequiredExp();
            CheckCurrentExp();
        } else if (_expCurrent < 0) {
            if (EntityLevel > 1) {
                DecreaseCurrentLevel();
                UpdateRequiredExp();
                _expCurrent += _expRequired;
                CheckCurrentExp();
            } else {
                _expCurrent = 0;
            }
        }
    }

    private void IncreaseCurrentLevel() {
        _entityLevel += 1;
        OnEntityLevelChange(this, new RPGEventLevelArgs(_entityLevel, _entityLevel - 1));
    }

    private void DecreaseCurrentLevel() {
        _entityLevel = Mathf.Max(0, _entityLevel - 1);
        OnEntityLevelChange(this, new RPGEventLevelArgs(_entityLevel, _entityLevel + 1));
    }

    private void UpdateRequiredExp() {
        _expRequired = GetRequiredExpToLevel(EntityLevel);
    }

    protected virtual int GetRequiredExpToLevel(int level) {
        return 10 * level;
    }

    #endregion Leveling
}
