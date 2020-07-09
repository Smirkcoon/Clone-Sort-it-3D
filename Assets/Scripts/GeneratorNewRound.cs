using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorNewRound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Manager.BallSelected = false;
    }

    public GameObject prefabBasket;
    public GameObject prefabBall;


    public void SettingsMap()
    {
        int IndexSettingsMap = Random.Range(0, 2);
        int CountOfBasket = 0;
        switch (IndexSettingsMap)
        {
            case 0:
                CountOfBasket = 6;
                break;
            case 1:
                CountOfBasket = 7;
                break;
            case 2:
                CountOfBasket = 8;
                break;
        }
        for (int i = 0; i < CountOfBasket; i++)
        {

        }
        switch (CountOfBasket) 
        { 
            case 6:
                
                break;
        }
    }
    }
