using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Transform PlaceForBallDown1, PlaceForBallDown2, PlaceForBallDown3, PlaceForBallDown4, PlaceForBallUp;
    private List<GameObject> BallInBasket = new List<GameObject>();
    private GameObject[] AllBasket;
    public GameObject SelectedBall;
    public bool ItIsFilledBasketInStart;
    public GameObject PrefBall;
    private void Start()
    {
        if (ItIsFilledBasketInStart == true) 
        {           
            for (int i = 0; i < 4; i++) 
            {
                GameObject ball = Instantiate(PrefBall, PlaceForBallUp.position, Quaternion.identity, transform.parent);
                SelectedBall = ball;               
                SelectedBall.GetComponent<Ball>().Move = true;
                FindBallPlace();
                //Invoke("FindBallPlace", 3);
                //PlusBallInBasket();


            }
        }
        AllBasket = GameObject.FindGameObjectsWithTag("Basket");
    }

    private void OnMouseDown()
    {
        if (Manager.BallSelected == false)
        {
            if (BallInBasket.Count != 0)
            {                           
                foreach (GameObject basket in AllBasket)
                {
                    basket.GetComponent<Basket>().SelectedBall = BallInBasket[BallInBasket.Count - 1];

                }
                MinusBallInBasket(BallInBasket[BallInBasket.Count - 1]);
            }
        }
        else 
        {
            PlusBallInBasket();
        }
        
    }
    private void PlusBallInBasket() 
    {
        Debug.Log("PlusBallInBasket");
        if (BallInBasket.Count < 4)
        {
            BallInBasket.Add(SelectedBall);
            SelectedBall.GetComponent<Ball>().Move = true;
            FindBallPlace();
            
        }

    }
    public void MinusBallInBasket(GameObject ball) 
    {
        ball.GetComponent<Ball>().Move = true;
        ball.GetComponent<Ball>().MoveTo = PlaceForBallUp;
        BallInBasket.Remove(ball);
    }
    private void FindBallPlace()
    {
        switch (BallInBasket.Count)
        {
            case 0:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBallDown1;
                break;
            case 1:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBallDown2;
                break;
            case 2:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBallDown3;
                break;
            case 3:
                SelectedBall.GetComponent<Ball>().MoveTo = PlaceForBallDown4;
                break;
        }
    }
    
}
