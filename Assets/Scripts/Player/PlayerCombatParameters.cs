using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatParameters : MonoBehaviour
{
    public static PlayerCombatParameters instance;

    public GameObject[] ProjectilePrefabArr;
    public GameObject youDied;
    private bool lvl1 = false;
    private bool lvl2 = false;

    public int hp = 10; 
    public int level = 1;

    [Header("IFrame stuff")]
    public float iframesDuration = 0.5f;
    public Collider triggerCollider;
    public Material regularColor;
    public Material flashColor;
    public GameObject playerbody;



    private void Awake()
    {
        instance = this;   
        youDied.SetActive(false);
    }

    private void Update()
    {
        if(GameManager.instance.enemiesDead >= 10 && lvl1 == false)
        {
            Debug.Log("LEVELED UP 1");
            LevelUp();
        }
        else if(GameManager.instance.enemiesDead >= 25 && lvl2 == false)
        {
            Debug.Log("LEVELED UP UPDATE");

            LevelUp();
        }

        if(IsDead())
        {
            Score.instance.updateHighScore();
            gameObject.SetActive(false);
            youDied.SetActive(true);
        }
    }


    public void LevelUp()
    {
        FindObjectOfType<AudioManager>().Play("pokemonLevelUp");
        if (GameManager.instance.enemiesDead >= 10 && lvl1 == false)
        {
            GetComponent<ProjectileLauncher>().minRotation = 0;
            GetComponent<ProjectileLauncher>().maxRotation = 0;
            lvl1 = true;
            level++;
        }
        else if(GameManager.instance.enemiesDead >= 25 && lvl2 == false)
        {
            Debug.Log("LEVELED UP method");
            level++;
            lvl2 = true;
        }
    }


    private bool IsDead()
    {
        return hp <= 0;
    }


    public void HitColor()
    {
        playerbody.GetComponent<MeshRenderer>().material = flashColor;
    }

    public void RegularColor()
    {
        playerbody.GetComponent<MeshRenderer>().material = regularColor;

    }

}
