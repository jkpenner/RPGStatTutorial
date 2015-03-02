using UnityEngine;
using System.Collections;
using System;

public class TestRPGStats : MonoBehaviour {
    public RPGEntity entity;


	// Use this for initialization
	void Start () {
        entity = GetComponent<RPGEntity>();
        entity.OnEntityLevelChange += OnEntityLevelChanged;


        DisplayStats();
	}

    void DisplayStats() {
        Array statTypes = Enum.GetValues(typeof(RPGStatType));
        foreach(int i in statTypes) {
            var stat = entity.EntityStats.GetStat((RPGStatType)i);
            if (stat != null) {
                Debug.Log(string.Format("[RPGEntity.EntityStats] {0} value is {1}", stat.StatName, stat.StatValue));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        entity.ModifyExp(10);
	}

    void OnEntityLevelChanged(object sender, RPGEventLevelArgs args) {
        DisplayStats();
    }
}
