using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Blueprint
    {
        public int Cost;
        public GameObject Prefab;
        public GameObject Effect;
    }
}
