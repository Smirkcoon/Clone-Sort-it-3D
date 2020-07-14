using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool Move = false;
    public Transform MoveTo;
    public float step;
    private float progress;
    [HideInInspector]
    public bool AlreadyGetColor = false;

    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (MoveTo != null)
        {
            if (Move == true)
            {
                transform.position = Vector3.Lerp(transform.position, MoveTo.position, step);
                progress += step;
                //Debug.Log(progress);
            }
            if (progress >= 3)
            {
                Move = false;
                progress = 0;
                //Manager.BallSelected = false;
                //Debug.Log("End Move");
            }
        }
    }
}
