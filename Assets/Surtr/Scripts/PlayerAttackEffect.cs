using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    [SerializeField] private float atk = 1f;
    /*[SerializeField] private bool isHitting = false;
    [SerializeField] public bool canHit = true;*/

    /*private void Awake()
    {
        canHit = true;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isHitting && gameObject.activeInHierarchy && canHit)
        {
            Debug.Log(atk + "damage");
            canHit = false;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log("1");*/
        if (collision.gameObject.tag == "Enemy")
        {
            //isHitting = true;
            Debug.Log(atk + "damage");
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isHitting = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isHitting = false;
        }
    }*/
}
