using UnityEngine;
using System.Collections;
using System;

public class TestRPGStats : MonoBehaviour {
    public RPGStatContainer entityStats;

	// Use this for initialization
	void Start () {
        entityStats.OnStatValueChange += OnStatChange;

        DisplayStats();

        var conMod = new RPGStatModifier(RPGStatType.Attribute_Constitution, RPGStatModifier.Types.BaseValueAdd, 20);
        var defMod = new RPGStatModifier(RPGStatType.Skill_Melee_Defence, RPGStatModifier.Types.BaseValuePercent, 2f);

        entityStats.AddModifier(conMod);
        entityStats.AddModifier(defMod);
        entityStats.RemoveModifer(conMod);
        entityStats.RemoveModifer(defMod);
	}

    void DisplayStats() {
        Array statTypes = Enum.GetValues(typeof(RPGStatType));
        foreach(int i in statTypes) {
            var stat = entityStats.GetStat((RPGStatType)i);
            if (stat != null) {
                Debug.Log(string.Format("[RPGEntity.EntityStats] {0} value is {1}", stat.StatName, stat.StatValue));
            }
        }
    }

    void OnStatChange(object sender, EventArgs e) {
        RPGStat stat = sender as RPGStat;
        Debug.Log(string.Format("[RPGEntity.EntityStats] {0} value is {1}", stat.StatName, stat.StatValue));
    }
}
