using UnityEngine;
using System.Collections;

public class RPGStatsDefault : RPGStats {
    private const int STARTING_VALUES = 50;

    public RPGStatsDefault() { }

    protected override void ConfigureStats() {
        var constitution = CreateOrGetStat<RPGStat>(RPGStatType.Attribute_Constitution);
        constitution.StatName = "Constitution";
        constitution.StatBaseValue = STARTING_VALUES;

        var speed = CreateOrGetStat<RPGStat>(RPGStatType.Attribute_Speed);
        speed.StatName = "Speed";
        speed.StatBaseValue = STARTING_VALUES;

        var willpower = CreateOrGetStat<RPGStat>(RPGStatType.Attribute_Willpower);
        willpower.StatName = "Willpower";
        willpower.StatBaseValue = STARTING_VALUES;



        var meleeDefence = CreateOrGetStat<RPGStat>(RPGStatType.Skill_Magic_Defence);
        meleeDefence.StatName = "Melee Defence";
        meleeDefence.StatBaseValue = STARTING_VALUES;

        var rangeDefence  = CreateOrGetStat<RPGStat>(RPGStatType.Skill_Range_Defence);
        rangeDefence.StatName = "Range Defence";
        rangeDefence.StatBaseValue = STARTING_VALUES;

        var magicDefence = CreateOrGetStat<RPGStat>(RPGStatType.Skill_Magic_Defence);
        magicDefence.StatName = "Magic Defence";
        magicDefence.StatBaseValue = STARTING_VALUES;


        var health = CreateOrGetStat<RPGStat>(RPGStatType.Vital_Health);
        health.StatName = "Health";
        health.StatBaseValue = STARTING_VALUES;

        var mana = CreateOrGetStat<RPGStat>(RPGStatType.Vital_Mana);
        mana.StatName = "Mana";
        mana.StatBaseValue = STARTING_VALUES;
    }
}
