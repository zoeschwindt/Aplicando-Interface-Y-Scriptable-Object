using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float detectionRadius = 3f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R)) Interactuar();
        if (Input.GetKeyDown(KeyCode.E)) Atacar();
    }

    void Interactuar()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        float minDist = float.MaxValue;
        IPresentacion closest = null;

        foreach (var col in colliders)
        {
            IPresentacion presentable = col.GetComponent<IPresentacion>();
            if (presentable != null)
            {
                float dist = Vector2.Distance(transform.position, col.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = presentable;
                }
            }
        }

        closest?.Accion();
    }

    void Atacar()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var col in colliders)
        {
            ITakeDamage enemigo = col.GetComponent<ITakeDamage>();
            if (enemigo != null)
            {
                enemigo.RecibirDanio(1);
                break;
            }
        }
    }
}
