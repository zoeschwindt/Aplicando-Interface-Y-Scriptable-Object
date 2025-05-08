using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemyParameters", menuName = "Enemy/EnemyParameters")]
public class EnemyParameters : ScriptableObject
{
    public string nombre;
    public int vida;
    public string saludo;
}