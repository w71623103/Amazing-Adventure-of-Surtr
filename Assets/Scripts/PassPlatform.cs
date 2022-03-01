using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatform : MonoBehaviour
{
    public GameObject box;
    public bool startDeActivate = false;
    public float timer = 0.1f;
    public bool fallingKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startDeActivate) timer -= Time.deltaTime;
        if(timer < 0) box.SetActive(false);
        //fallingKeyPressed = Input.GetKey(KeyCode.S)/* && Input.GetKeyDown(KeyCode.K)*/;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent <PlayerCore>().model.playerRB.velocity.y <= 0f && !fallingKeyPressed)
        {
            startDeActivate = false;
            box.SetActive(true);
            timer = 0.1f;
        }

        /*if (collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            //Debug.Log("CanFall");
            if (*//*Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.K)Input.GetKeyDown(KeyCode.Tab)*//*fallingKeyPressed)
            {
                startDeActivate = true;
                timer = 0.05f;
            }
        }*/
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            //Debug.Log("CanFall");
            if (*//*Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.K)Input.GetKeyDown(KeyCode.Tab)*//*fallingKeyPressed)
            {
                startDeActivate = true;
                timer = 0.05f;
            }
        }
        
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            startDeActivate = true;
            timer = 0.5f;
        }
    }


}
