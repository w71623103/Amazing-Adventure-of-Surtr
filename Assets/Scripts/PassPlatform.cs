using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatform : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private bool startDeActivate = false;
    //[SerializeField] private float timer = 0.1f;
    //[SerializeField] private bool fallingKeyPressed;
    [SerializeField] private float detectTimer = 0f;
    [SerializeField] private float sensorCD = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectTimer = sensorCD;

        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCore>().model.playerRB.velocity.y <= 0f && !startDeActivate)
        {

            startDeActivate = false;
            box.SetActive(true);

        }
        else if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCore>().model.playerRB.velocity.y > 0f && !startDeActivate)
        {
            box.SetActive(false);

        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (detectTimer < 0f)
        {
            //Debug.Log("I'm leaving");
            if (collision.gameObject.tag == "Player")
            {
                startDeActivate = true;
            //timer = 0.3f;
        }
    }*/

}

