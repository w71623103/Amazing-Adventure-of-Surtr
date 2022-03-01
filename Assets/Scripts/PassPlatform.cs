using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatform : MonoBehaviour
{
    public GameObject box;
    public bool startDeActivate = false;
    public float timer = 0.1f;
    public bool fallingKeyPressed;
    public float detectTimer = 0f;
    public float sensorCD = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectTimer -= Time.deltaTime;
        if(startDeActivate) timer -= Time.deltaTime;
        if (timer < 0)
        {
            box.SetActive(false);
            startDeActivate = false;
            timer = 0.3f;
        }
        fallingKeyPressed = Input.GetKey(KeyCode.S)/* && Input.GetKeyDown(KeyCode.K)*/;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectTimer = sensorCD;
        //Debug.Log("llllllllllllanding");
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent <PlayerCore>().model.playerRB.velocity.y < 0f && !startDeActivate)
        {
            
            startDeActivate = false;
            box.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (detectTimer < 0f)
        {
            Debug.Log("I'm leaving");
            if (collision.gameObject.tag == "Player")
            {
                startDeActivate = true;
                timer = 0.3f;
            }
        }
        
    }


}
