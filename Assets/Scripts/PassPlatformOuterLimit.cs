using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatformOuterLimit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.transform.Find("box").gameObject.SetActive(true);
        }
    }
}
