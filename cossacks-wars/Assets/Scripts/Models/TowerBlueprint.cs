using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class TowerBlueprint
    {
        public Blueprint Build;
        public GameObject SellEffect;
        public List<Blueprint> Upgrades;

        public int GetSellCost(int upgradeIndex = 0)
        {
            if (upgradeIndex > 0)
            {
                var upgradeCost = Upgrades.Take(upgradeIndex).Select(upgrade => upgrade.Cost / 2).Sum();
                return (Build.Cost / 2) + upgradeCost;
            }

            return Build.Cost / 2;
        }
    }
}