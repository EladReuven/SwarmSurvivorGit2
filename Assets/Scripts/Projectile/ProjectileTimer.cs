using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimer : MonoBehaviour
{
    public float lifeTime = 5f;
    private float lifeTimeLeft;

    private void Awake()
    {
        lifeTimeLeft = lifeTime;
    }

    private void Update()
    {
        lifeTimeLeft -= Time.deltaTime;
        if (lifeTimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
