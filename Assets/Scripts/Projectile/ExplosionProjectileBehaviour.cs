using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectileBehaviour : MonoBehaviour
{
    public GameObject explosionImpactEffect;
    public GameObject explosionGroundEffect;
    public GameObject explosionCollider;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);
            Instantiate(explosionImpactEffect, transform.position, explosionImpactEffect.transform.rotation);
            Instantiate(explosionCollider, transform.position, explosionCollider.transform.rotation);
            FindObjectOfType<AudioManager>().Play("explosion");
            if (Physics.Raycast(downRay, out hit))
            {
                Instantiate(explosionGroundEffect, hit.point, explosionGroundEffect.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
