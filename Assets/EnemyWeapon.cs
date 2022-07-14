using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float rayLength = 1f;
    public float hitDelay = 0.5f;
    public float flashDuration = 0.2f;
    public bool isHit;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);    
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, rayLength))
        {
            if(!isHit)
            {
                PlayerCombatParameters.instance.hp--;
                StartCoroutine(HitDelay());
                StartCoroutine(ColorFlash());
            }
        }
    }

    IEnumerator ColorFlash()
    {
        PlayerCombatParameters.instance.HitColor();
        yield return new WaitForSeconds(flashDuration);
        PlayerCombatParameters.instance.RegularColor();
    }
    IEnumerator HitDelay()
    {
        isHit = true;
        FindObjectOfType<AudioManager>().Play("oof");
        yield return new WaitForSeconds(hitDelay);
        isHit = false;

    }

}
