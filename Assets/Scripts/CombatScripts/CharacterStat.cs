

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType {
    Attack,
    Defense,
    Constitution,
    Vitality
}

public class CharacterStat {

    public List<BaseStat> stats;
    // Use this for initialization

    private int skillPoints;

    public CharacterStat() {
        ConstructBaseStats();
    }
    public CharacterStat(int attack, int defense, int constitution, int vitality) {
        stats = new List<BaseStat>();
        stats.Add(new BaseStat(StatType.Attack, attack, "Attack", "attackonly"));
        stats.Add(new BaseStat(StatType.Defense, defense, "Defense", "Defense"));
        stats.Add(new BaseStat(StatType.Constitution, constitution, "Constitution", "Constitution"));
        stats.Add(new BaseStat(StatType.Vitality, vitality, "Vitality", "Vitality"));
    }
    //default values given to the chracter stats
    public void ConstructBaseStats() {
        stats = new List<BaseStat>();
        stats.Add(new BaseStat(StatType.Attack, 1, "Attack", "Attack"));
        stats.Add(new BaseStat(StatType.Defense, 1, "Defense", "Defense"));
        stats.Add(new BaseStat(StatType.Constitution, 1, "Constitution", "Constitution"));
        stats.Add(new BaseStat(StatType.Vitality, 1, "Vitality", "Vitality"));
    }
    public BaseStat GetStat(StatType stat) {
        return this.stats.Find(x => x.type == stat);
    }
    //newBonusStats must follow proper indexing into character stat list
    //ex: newBonusStats[0] = Attack, newBonusStats[1] = defense
    public void AddStatBonus(List<BaseStat> newBonusStats) {
        foreach (BaseStat statBonus in newBonusStats) {
            GetStat(statBonus.type).addBonus(new BonusStat(statBonus.totalValue, statBonus.type, statBonus.discription));
        }
    }
    public void RemoveStatBonus(List<BaseStat> newBonusStats)
    {
        foreach (BaseStat statBonus in newBonusStats)
        {
            GetStat(statBonus.type).removeBonus(new BonusStat(statBonus.totalValue, statBonus.type, statBonus.discription));
        }
    }

        public int GetSkillPoints() { return skillPoints; }
        public void SetSkillPoints(int skillPoints) { this.skillPoints = skillPoints; }
        public void UseSkillPoint()
        {
            if (skillPoints > 0)
                skillPoints--;
        }
        public void GainSkillPoint()
        {
            skillPoints++;
        }

        public List<BaseStat> GetStats()
        {
            return stats;
        }

        public int GetStat(int statNumber)
        {
            return (int)stats[statNumber].getBaseValue();
        }
    }

