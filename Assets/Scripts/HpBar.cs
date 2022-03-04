using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private GameObject show;
    private float hpPer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        hpPer = show.GetComponent<Core>().getHpPer();

        transform.localScale = new Vector3(hpPer, transform.localScale.y, transform.localScale.z);
        
    }
}
