using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BrickGrid", menuName = "Configs/BrickGrid", order = 0)]
    public class BrickGridConfig : ScriptableObject
    {
        public Colums[] colums;

    }
    [Serializable]
    public class Colums
    {
        public Rows[] rows;
    }
    [Serializable]
    public class Rows
    {
        public Color rowColor;
    }
}