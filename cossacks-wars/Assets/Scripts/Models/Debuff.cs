using Assets.Scripts.Enums;
using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Debuff
    {
        public DebuffType Type;

        public float Duration;

        public float Value;

        [HideInInspector]
        public float StartTime;
    }
}
