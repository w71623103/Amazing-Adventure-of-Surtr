using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackEffect : MonoBehaviour
{
    [SerializeField] private float atk = 1;

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
        if (collision.gameObject.tag == "Enemy")
        {
            //isHitting = true;
            Debug.Log(atk + "damage");
            collision.gameObject.GetComponent<EnemyCore>().takeDamage(atk, transform.position.x);
        }
    }

}
