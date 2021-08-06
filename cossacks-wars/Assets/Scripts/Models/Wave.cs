using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Wave
    {
        public GameObject Enemy;

        public int Count;

        public float SpawnRate;
    }
}