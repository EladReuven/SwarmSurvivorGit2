using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatParameters : MonoBehaviour
{
    public static PlayerCombatParameters instance;

    public GameObject[] ProjectilePrefabArr;
    public GameObject youDied;
    private bool lvlUp = false;

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
        if(GameManager.instance.enemiesDead > 25 && lvlUp == false)
        {
            Debug.Log("LEVELED UP");
            LevelUp();
            lvlUp = true;
        }

        if(IsDead())
        {
            gameObject.SetActive(false);
            youDied.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("oof");
            hp--;
            StartCoroutine(IFrames());
        }
    }

    public void LevelUp()
    {
        level++;
    }

    public void UpgradeAbility()
    {
        Time.timeScale = 0;
    }

    private bool IsDead()
    {
        return hp <= 0;
    }

    private IEnumerator IFrames()
    {
        playerbody.GetComponent<MeshRenderer>().material = flashColor;
        //triggerCollider.enabled = false;
        yield return new WaitForSeconds(iframesDuration);
        //triggerCollider.enabled = true;
        playerbody.GetComponent<MeshRenderer>().material = regularColor;

    }
}
