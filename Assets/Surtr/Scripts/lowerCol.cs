using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowerCol : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.S)/*Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S) canFall*/)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("passPlatforms"));
            Debug.DrawRay(transform.position, Vector2.down, Color.red);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("ground"))
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "passPlatform")
        {
            collision.gameObject.transform.Find("box").gameObject.SetActive(false);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerCore>().model.isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerCore>().model.isGrounded = true;
            transform.parent.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.1f, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerCore>().model.isGrounded = false;
        }
    }
}
