using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] private float atk = 10f;

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
        /*Debug.Log("1");*/
        if (collision.gameObject.tag == "Player")
        {
            //isHitting = true;
            Debug.Log(atk + "damage");
            collision.gameObject.GetComponent<PlayerCore>().model.hp -= atk;
        }
    }

}