using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class initializer : MonoBehaviour
{
    [SerializeField] private GameObject cm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(1.15999997f, 0.213f, 0);
            cm.GetComponent<CinemachineVirtualCamera>().Follow = collision.gameObject.transform;
            Destroy(gameObject);
        }
    }
}
