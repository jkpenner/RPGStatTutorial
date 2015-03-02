using UnityEngine;
using System.Collections;

public class RPGStatsDefault : RPGStats {
    private const int STARTING_VALUES = 50;

    public RPGStatsDefault() : base(null) { }
    public RPGStatsDefault(RPGEntity entity) : base(entity) { }

    protected override void ConfigureStats() {
        var constitution = CreateOrGetStat<RPGAttribute>(RPGStatType.Attribute_Constitution);
        constitution.StatName = "Constitution";
        constitution.StatBaseValue = STARTING_VALUES;

        var speed = CreateOrGetStat<RPGAttribute>(RPGStatType.Attribute_Speed);
        speed.StatName = "Speed";
        speed.StatBaseValue = STARTING_VALUES;

        var willpower = CreateOrGetStat<RPGAttribute>(RPGStatType.Attribute_Willpower);
        willpower.StatName = "Willpower";
        willpower.StatBaseValue = STARTING_VALUES;


        var meleeDefence = CreateOrGetStat<RPGSkill>(RPGStatType.Skill_Magic_Defence);
        meleeDefence.StatName = "Melee Defence";
        meleeDefence.StatBaseValue = STARTING_VALUES;
        meleeDefence.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Constitution), 0.4f));

        var rangeDefence  = CreateOrGetStat<RPGSkill>(RPGStatType.Skill_Range_Defence);
        rangeDefence.StatName = "Range Defence";
        rangeDefence.StatBaseValue = STARTING_VALUES;
        rangeDefence.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Speed), 0.6f));

        var magicDefence = CreateOrGetStat<RPGSkill>(RPGStatType.Skill_Magic_Defence);
        magicDefence.StatName = "Magic Defence";
        magicDefence.StatBaseValue = STARTING_VALUES;
        magicDefence.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Willpower), 0.3f));


        var health = CreateOrGetStat<RPGVital>(RPGStatType.Vital_Health);
        health.StatName = "Health";
        health.StatBaseValue = STARTING_VALUES;
        health.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Constitution), 2f));

        var mana = CreateOrGetStat<RPGVital>(RPGStatType.Vital_Mana);
        mana.StatName = "Mana";
        mana.StatBaseValue = STARTING_VALUES;
        mana.AddLinker(new RPGStatLinkerBasic(GetStat(RPGStatType.Attribute_Willpower), 5f));
    }
}
