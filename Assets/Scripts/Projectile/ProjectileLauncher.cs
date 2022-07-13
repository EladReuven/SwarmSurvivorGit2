using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    public Transform projectileSpawnTransform;

    [SerializeField] private GameObject projectilePrefab;

  
    [SerializeField] private float delayBetweenProjectiles;
    [SerializeField] private float projectileLaunchForce;
    
    [SerializeField] private float minRotation, maxRotation;


    private void Start()
    {
        StartCoroutine(BasicProjectilePerDelay());
    }

    //private void Update()
    //{
    //    projectilePrefab = PlayerCombatParameters.instance.ProjectilePrefabArr[PlayerCombatParameters.instance.level - 1];
    //}


    private IEnumerator BasicProjectilePerDelay()
    {
        while (true)
        {
            GameObject projectileInstance = Instantiate(PlayerCombatParameters.instance.ProjectilePrefabArr[PlayerCombatParameters.instance.level - 1], projectileSpawnTransform.position, projectileSpawnTransform.rotation * Quaternion.Euler(0, Random.Range(minRotation, maxRotation),0));
            projectileInstance.GetComponent<Rigidbody>().AddForce(projectileInstance.transform.forward * projectileLaunchForce, ForceMode.VelocityChange);
            yield return new WaitForSeconds(delayBetweenProjectiles);

        }
    }
}
