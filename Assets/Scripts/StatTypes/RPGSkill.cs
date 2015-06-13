using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGSkill : RPGStatModifiable, IStatLinkable {
    private bool _known;
    private int _statLinkerValue;
    private List<RPGStatLinker> _linkers;

    public bool Known {
        get { return _known; }
        set { _known = value; }
    }

    public int StatLinkerValue {
        get { return _statLinkerValue; }
    }

    public override int StatBaseValue {
        get { return base.StatBaseValue + StatLinkerValue; }
        set { base.StatBaseValue = value; }
    }

    public RPGSkill() {
        _known = false;
        ValidateLinkers();
        _statLinkerValue = 0;
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
