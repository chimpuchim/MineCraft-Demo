using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : GameManager
{
    [Header("Type")]
        [SerializeField] private BlockType type;
        public BlockType Type { get => type; set => type = value;}
        [SerializeField] private float timeBreakBlock;
        public float TimeBreakBlock { get => timeBreakBlock; set => timeBreakBlock = value; }
}
