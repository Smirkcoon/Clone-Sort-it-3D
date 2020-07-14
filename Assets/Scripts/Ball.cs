using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool MoveUp = false;
    public bool Move = false;

    public float progressup;
    public Transform MoveToUp;

    private float progress;
    public Transform MoveTo;

    public float step;
   
   
    [HideInInspector]
    public bool AlreadyGetColor = false;
    void FixedUpdate()
    {
        if (MoveTo != null)
        {
            if (MoveUp == true)
            {
                transform.position = Vector3.Lerp(transform.position, MoveToUp.position, step);
                progressup += step;
            }
            if (Move == true && progressup >= 3)
            {
                transform.position = Vector3.Lerp(transform.position, MoveTo.position, step);
                progress += step;               
                MoveUp = false;
            }
            if (progress >= 3)
            {
                Move = false;
                progress = 0;
                progressup = 0;
            }
        }
    }
}
