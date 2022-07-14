using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollision : MonoBehaviour
{
    public float radius = 2.5f;

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}

    void OnEnable()
    {
        Explosion();
    }
    
    public void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
                Debug.Log(c.gameObject.name);
                GameManager.instance.enemiesAlive--;
                GameManager.instance.enemiesDead++;
                Score.instance.points += 50;
                Destroy(c.transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
