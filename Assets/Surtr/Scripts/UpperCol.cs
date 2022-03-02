using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperCol : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.parent.transform.position, Vector2.up, Mathf.Infinity, LayerMask.GetMask("passPlatforms"));
        Debug.DrawRay(transform.position, Vector2.up, Color.blue);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("ground"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && collision.gameObject.layer == LayerMask.GetMask("passPlatforms"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && collision.gameObject.layer == LayerMask.GetMask("passPlatforms"))
        {
            collision.gameObject.SetActive(false);
        }
    }*/
}
