using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Transform[] PlaceForBall;
    private List<GameObject> BallInBasket = new List<GameObject>();
    private GameObject[] AllBasket;
    public GameObject SelectedBall;
    public bool ItIsFilledBasketInStart;
    public GameObject PrefBall;
    private bool OneColorFilled;
    private GameObject GeneratorNewRound;
    private void Start()
    {
        GeneratorNewRound = GameObject.FindGameObjectWithTag("GeneratorNewRound");
    }
    public void GenerateBalls()
    {
        if (ItIsFilledBasketInStart == true)
        {          
            for (int i = 0; i < 4; i++) 
            {
                GameObject ball = Instantiate(PrefBall, PlaceForBall[4].position, Quaternion.identity);
                ball.name = "Ball" +(i +1);
                SelectedBall = ball;               
                SelectedBall.GetComponent<Ball>().Move = true;
                AddBallInBasket();
            }
        }
        AllBasket = GameObject.FindGameObjectsWithTag("Basket");
    }
    private void Update()
    {
        if (OneColorFilled == false && BallInBasket.Count == 4)
        {
            if (BallInBasket[0].GetComponent<Renderer>().material.color == BallInBasket[1].GetComponent<Renderer>().material.color)
            {
                if (BallInBasket[1].GetComponent<Renderer>().material.color == BallInBasket[2].GetComponent<Renderer>().material.color)
                {
                    if (BallInBasket[2].GetComponent<Renderer>().material.color == BallInBasket[3].GetComponent<Renderer>().material.color)
                    {
                        OneColorFilled = true;
                        GeneratorNewRound.GetComponent<GeneratorNewRound>().BasketsOneColorFilled.Add(this.gameObject);
                    }                    
                }                
            }
        }
        if (BallInBasket.Count < 4 && OneColorFilled == true)
        {
            OneColorFilled = false;
            GeneratorNewRound.GetComponent<GeneratorNewRound>().BasketsOneColorFilled.Remove(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Manager.BallSelected == false)
        {
            if (BallInBasket.Count != 0)
            {
                GameObject BallToMove = BallInBasket[BallInBasket.Count - 1];
                MinusBallInBasket(BallToMove);
                Manager.BallSelected = true;
                foreach (GameObject basket in AllBasket)
                {
                    basket.GetComponent<Basket>().SelectedBall = BallToMove;                  
                }                              
            }
        }
        else 
        {
            AddBallInBasket();            
        }       
    }
    private void AddBallInBasket() 
    {
        if (BallInBasket.Count < 4)
        {
            SelectedBall.GetComponent<Ball>().progressup = 0;
            SelectedBall.GetComponent<Ball>().Move = true;           
            SelectedBall.GetComponent<Ball>().MoveUp = true;
            SelectedBall.GetComponent<Ball>().MoveToUp = PlaceForBall[4];
            FindBallPlace();
            BallInBasket.Add(SelectedBall);
            Manager.BallSelected = false;
        }
    }
    public void MinusBallInBasket(GameObject ball) 
    {
        ball.GetComponent<Ball>().MoveUp = true;
        ball.GetComponent<Ball>().MoveToUp = PlaceForBall[4];
        BallInBasket.Remove(ball);
    }
    private void FindBallPlace()
    {
        switch (BallInBasket.Count)
        {
            case 0:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBall[0];
                break;
            case 1:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBall[1];
                break;
            case 2:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBall[2];
                break;
            case 3:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBall[3];
                break;
        }
    }   
}
