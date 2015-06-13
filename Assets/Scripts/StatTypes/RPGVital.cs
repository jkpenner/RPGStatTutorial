using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGVital : RPGStatModifiable, IStatLinkable {
    private int _currentValue;
    private int _statLinkerValue;
    private List<RPGStatLinker> _linkers;

    public int StatLinkerValue {
        get { return _statLinkerValue; }
    }

    public int StatValueCurrent {
        get {
            if (_currentValue > StatValue) {
                _currentValue = StatValue;
            } else if (_currentValue < 0) {
                _currentValue = 0;
            }
            return _currentValue;
        }
        set {
            _currentValue = value;
        }
    }

    public override int StatBaseValue {
        get { return base.StatBaseValue + StatLinkerValue; }
        set { base.StatBaseValue = value; }
    }

    public RPGVital() {
        _currentValue = StatValue;
        ValidateLinkers();
        _statLinkerValue = 0;
    }

    public void SetCurrentToMax() {
        StatValueCurrent = StatValue;
    }

    public void AddLinker(RPGStatLinker linker) {
        _linkers.Add(linker);
        linker.OnValueChanged += OnLinkerValueChange;
        UpdateLinkerValue();
    }

    public void RemoveLinker(RPGStatLinker linker) {
        if (_linkers.Contains(linker)) {
            linker.OnValueChanged -= OnLinkerValueChange;
            _linkers.Remove(linker);
            UpdateLinkerValue();
        }
    }

    public void ClearLinkers() {
        _linkers.Clear();
    }

    public void UpdateLinkerValue() {
        ValidateLinkers();
        _statLinkerValue = 0;
        foreach (RPGStatLinker link in _linkers) {
            _statLinkerValue += link.Value;
        }
        ValueChange();
    }

    public void OnLinkerValueChange(object sender, System.EventArgs e) {
        UpdateLinkerValue();
    }

    public void ValidateLinkers() {
        if (_linkers == null) {
            _linkers = new List<RPGStatLinker>();
        }
    }    
}