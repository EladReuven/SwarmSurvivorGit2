using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public NavMeshEnemyAI enemyToSpawn;
    public NavMeshEnemyAI[] enemyArr;
    public NavMeshEnemyAI[] pausedEnemyArr;
    public MeshRenderer[] spawnLocationsList;
    public GameObject menuTemplate;
    public GameObject menu;

    public int timeBetweenWaves = 5;
    public int enemiesPerWave;
    public int enemiesAlive = 0;
    public int enemiesDead = 0;

    private int locationIndex;

    

    private void Start()
    {
        Debug.Log("started");
        FindObjectOfType<AudioManager>().Play("gameMusic");
        instance = this;
        SpawnEnemyRandomly(enemiesPerWave);
        menu = Instantiate(menuTemplate);
        menu.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            FindObjectOfType<AudioManager>().Play("menuMusic");
            FindObjectOfType<AudioManager>().Pause("gameMusic");
            //FillPausedEnemyTransform();
            //DestroyEnemies();
            menu.SetActive(true);
        }

        if(enemiesAlive <=0)
        {
            StartCoroutine(CountdownBetweenWaves(timeBetweenWaves));
            SpawnEnemyRandomly(enemiesPerWave);
            enemiesPerWave = (int)((float)enemiesPerWave * 1.1f);
        }
    }

    private void FillPausedEnemyTransform()
    {
        pausedEnemyArr = new NavMeshEnemyAI[enemyArr.Length];
        
        for(int i = 0; i < enemyArr.Length; i++)
        {
             pausedEnemyArr[i] = enemyArr[i];
        }

    }

    public void SpawnEnemyAfterPause()
    {
        for(int i = 0; i < enemyArr.Length; i++)
        {
            if(pausedEnemyArr[i] != null)
            {

                //Vector3 spawnPosition = pausedEnemyArr[i].transform.position;
                NavMeshEnemyAI instadEnemyMeshAI = Instantiate(pausedEnemyArr[i]);
                instadEnemyMeshAI.movePositionTransform = player.transform;
                enemyArr[i] = instadEnemyMeshAI;
            }
        }
    }

    private void SpawnEnemyRandomly(int num)
    {
        enemyArr = new NavMeshEnemyAI[num];
        for (int i = 0; i < num; i++)

        {

            locationIndex = Random.Range(0, spawnLocationsList.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(spawnLocationsList[locationIndex].bounds.min.x, spawnLocationsList[locationIndex].bounds.max.x),
                spawnLocationsList[locationIndex].bounds.max.y, Random.Range(spawnLocationsList[locationIndex].bounds.min.z, spawnLocationsList[locationIndex].bounds.max.z));
            NavMeshEnemyAI instadEnemyMeshAI = Instantiate(enemyToSpawn, spawnPosition, enemyToSpawn.transform.rotation);
            instadEnemyMeshAI.movePositionTransform = player.transform;
            enemyArr[i] = instadEnemyMeshAI;
            enemiesAlive++;
        }
    }

    IEnumerator CountdownBetweenWaves(int sec)
    {
        yield return new WaitForSeconds(sec);
    }



    [ContextMenu("Destroy Enemy Array")]
    public void DestroyEnemies()
    {
        foreach (NavMeshEnemyAI enemy in enemyArr)
        {
            if (enemy != null)
            {
                Destroy(enemy);
                Debug.Log("Enemy Destroyed");
            }
            else
            {
                Debug.Log("Enemy Already Dead");
            }
        }
    }
}
