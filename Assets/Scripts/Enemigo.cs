using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion, ITakeDamage
{
    public EnemyParameters data;

    public void Accion()
    {
        Debug.Log($"Soy {data.nombre}, tengo {data.vida} de vida. {data.saludo}");
    }

    public void RecibirDanio(int cantidad)
    {
        data.vida -= cantidad;
        Debug.Log($"{data.nombre} recibió {cantidad} de daño. Vida restante: {data.vida}");

        if (data.vida <= 0)
        {
            Debug.Log($"{data.nombre} ha sido derrotado.");
            Destroy(gameObject);
        }
    }
}