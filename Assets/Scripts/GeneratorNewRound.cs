using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorNewRound : MonoBehaviour
{
    public Transform[] PositionFor6Basket; // список позиций для корзин, для разного количества
    public Transform[] PositionFor7Basket;
    public Transform[] PositionFor8Basket;
    private List<GameObject> GenerateBasket = new List<GameObject>();
    private int countEmptyBasket;
    private int CountOfBasket;
    private int IndexSettingsMap;
    private int x;
    private GameObject[] Balls;
    private List<Color> colors = new List<Color>();

    public List<GameObject> BasketsOneColorFilled = new List<GameObject>();

    public GameObject YouWinT;

    private void Update()
    {
        if (BasketsOneColorFilled.Count == (CountOfBasket - countEmptyBasket)) 
        {           
            YouWinT.SetActive(true);
        }
        else YouWinT.SetActive(false);      
    }
    private void Awake()
    {
        Camera mainCam = Camera.main;
        SettingsMap();

        colors.Add(Color.cyan);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        colors.Add(Color.black);
        colors.Add(Color.blue);
        colors.Add(Color.gray);
        colors.Add(Color.white);
    }
    void Start()
    {
        FilledBasket();
        Manager.BallSelected = false;
        Balls = GameObject.FindGameObjectsWithTag("Ball");
        SetBallsColor();
    }
    public GameObject prefabBasket;
    public void SettingsMap()
    {
        Camera mainCam = Camera.main;
        IndexSettingsMap = Random.Range(0, 3);
        
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
        
        switch (CountOfBasket)
        {
            case 6:
                for (int i = 0; i < CountOfBasket; i++)
                {
                    GameObject Basket = Instantiate(prefabBasket, PositionFor6Basket[i].position, transform.rotation);
                    GenerateBasket.Add(Basket);
                }
                countEmptyBasket = 1;
                break;

            case 7:
                mainCam.transform.position = new Vector3(0, 0, -2);
                for (int i = 0; i < CountOfBasket; i++)
                {

                    GameObject Basket = Instantiate(prefabBasket, PositionFor7Basket[i].position, transform.rotation);
                    GenerateBasket.Add(Basket);                 
                }
                countEmptyBasket = 2;
                break;

            case 8:
                mainCam.transform.position = new Vector3(0, 0, -2);
                for (int i = 0; i < CountOfBasket; i++)
                {
                    GameObject Basket = Instantiate(prefabBasket, PositionFor8Basket[i].position, transform.rotation);
                    GenerateBasket.Add(Basket);
                }    
                countEmptyBasket = 2;
                break;
        }     
    }
    private void FilledBasket()
    {
        for (int i = 0; i < countEmptyBasket; i++)
        {
            x = Random.Range(0, CountOfBasket);
            if (GenerateBasket[x].transform.GetChild(0).GetComponent<Basket>().ItIsFilledBasketInStart == true)
            {
                GenerateBasket[x].transform.GetChild(0).GetComponent<Basket>().ItIsFilledBasketInStart = false;
            }
            else
            {
                Debug.Log("FilledBasket");
                i -= 1;               
            }
        }
        foreach (GameObject basket in GenerateBasket)
        {
            basket.transform.GetChild(0).GetComponent<Basket>().GenerateBalls();
        }
    }   
    private void SetBallsColor() 
    {
        for (int r = 0; r < (CountOfBasket - countEmptyBasket); r++)
        {
            Color color = colors[Random.Range(0, colors.Count)];
            colors.Remove(color);
            for (int i = 0; i < 4; i++)
            {
                GameObject ball = Balls[Random.Range(0, Balls.Length)];
                if (ball.GetComponent<Ball>().AlreadyGetColor == false)
                {
                    ball.GetComponent<Renderer>().material.color = color;
                    ball.GetComponent<Ball>().AlreadyGetColor = true;
                }
                else i -= 1;
            }
        }
    }
}
