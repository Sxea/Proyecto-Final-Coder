using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Gameobjects/GameObjectData")]
public class GameObjectData : ScriptableObject
{
    [SerializeField] public float healt;
    [SerializeField] public float speed;
    [SerializeField] public float damage;

    
}
