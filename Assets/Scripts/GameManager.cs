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

    public float timeBetweenWaves = 5;
    public int enemiesPerWave;
    public int enemiesAlive = 0;
    public int enemiesDead = 0;
    public bool ready4NextWave = false;

    private int locationIndex;
    private float currentTimeBetweenWaves;

    

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("gameMusic");
        instance = this;
        SpawnEnemyRandomly(enemiesPerWave);
        menu = Instantiate(menuTemplate);
        menu.SetActive(false);
        currentTimeBetweenWaves = timeBetweenWaves;
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
            if(currentTimeBetweenWaves <= 0)
            {
                SpawnEnemyRandomly(enemiesPerWave);
                currentTimeBetweenWaves = timeBetweenWaves;
            }
            else
            {
                currentTimeBetweenWaves -= Time.deltaTime;
                Debug.Log(currentTimeBetweenWaves);
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
        enemiesPerWave = (int)((float)enemiesPerWave * 1.1f);
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
