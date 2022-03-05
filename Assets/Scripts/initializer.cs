using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initializer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(1.15999997f, 0.213f, 0);
            Destroy(gameObject);
        }
    }
}
