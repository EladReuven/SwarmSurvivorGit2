using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int points = 0;

    private void Awake()
    {
        instance = this; 
    }




}
