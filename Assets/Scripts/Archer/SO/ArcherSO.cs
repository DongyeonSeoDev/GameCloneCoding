using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Archer Data", menuName = "Scriptable Object/Archer Data", order = int.MaxValue)]
public class ArcherSO : ScriptableObject
{
    public int strength;
    public float arrowSpeed;
    public float attackDelay;

    public float moveSpeed;

    public Vector2 scale;

    //public Sprite sprite;
}
