using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatformBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerCore>().model.playerRB.velocity.y > 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
