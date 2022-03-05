using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public EnemyModel model;

    public EnemyController(EnemyModel newMod)
    {
        model = newMod;
    }

    //control player sprite facing left/right
    public void scaleControl()
    {
        if (model.attackState == model.atkStateDefault)
        {
            if (model.horizontalMovement < 0)
                model.isLeft = true;
            else if (model.horizontalMovement > 0)
                model.isLeft = false;
        }
    }

    public void hMovement()
    {
        model.characterRB.velocity = new Vector2(model.horizontalMovement, model.characterRB.velocity.y);
    }

    public bool isInSight(EnemyCore em)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(em.transform.position.x, em.transform.position.y -0.1f, em.transform.position.z), new Vector2(em.transform.localScale.x, 0), 0.3f, LayerMask.GetMask("Player"));
        Debug.DrawRay(new Vector3(em.transform.position.x, em.transform.position.y - 0.1f, em.transform.position.z), new Vector2(em.transform.localScale.x, 0), Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                model.direction = (int) em.transform.localScale.x;
                if((hit.collider.transform.position - em.transform.position).magnitude < 0.5f)
                    return true;
            }
        }
        return false;
    }
}
