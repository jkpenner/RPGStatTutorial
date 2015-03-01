using UnityEngine;
using System;
using System.Collections;

public class RPGEventLevelArgs : EventArgs {
    private int _level;
    private int _levelPrevious;

    public RPGEventLevelArgs(int level, int levelPrev) {
        _level = level;
        _levelPrevious = levelPrev;
    }

    public int Level { get { return _level; } }
    public int LevelPrevious { get { return _level; } }
}
