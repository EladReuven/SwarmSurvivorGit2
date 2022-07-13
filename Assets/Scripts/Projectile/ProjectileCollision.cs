using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("regularHit");
            GameManager.instance.enemiesAlive--;
            GameManager.instance.enemiesDead++;
            Score.instance.points += 50;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
