using UnityEngine;
using System.Collections;

public class RPGStatsDefault : RPGStatContainer {
    private const int STARTING_VALUES = 50;

    protected override void ConfigureStats() {
        var constitution = CreateOrGetStat<RPGAttribute>(RPGStatType.Attribute_Constitution);
        constitution.StatName = "Constitution";
        constitution.StatBaseValue = STARTING_VALUES;



        var meleeDefence = CreateOrGetStat<RPGSkill>(RPGStatType.Skill_Melee_Defence);
        meleeDefence.StatName = "Melee Defence";
        meleeDefence.StatBaseValue = STARTING_VALUES;
        meleeDefence.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Constitution), 0.5f));


        var health = CreateOrGetStat<RPGVital>(RPGStatType.Vital_Health);
        health.StatName = "Health";
        health.StatBaseValue = STARTING_VALUES;
        health.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Constitution), 2f));
        health.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Skill_Melee_Defence), 1f));
    }
}
