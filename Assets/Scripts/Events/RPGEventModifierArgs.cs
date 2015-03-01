using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RPGEventModifierArgs : EventArgs {
    private List<RPGStatModifier> _modifiers;

    public RPGEventModifierArgs(List<RPGStatModifier> mods) {
        _modifiers = mods;
    }

    public List<RPGStatModifier> StatModifiers {
        get { return _modifiers; }
    }
}
