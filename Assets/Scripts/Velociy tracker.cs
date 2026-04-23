using UnityEngine;
using System.Collections.Generic;

public class Velociytracker : MonoBehaviour
{

    public Player_Controller countTracker;
    public int countRequired = 13;

    private Vector3 lastPosition;
    private float distanceTraveled;
    private float averageVelocity;
   
    private bool hasCalculated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if(!hasCalculated && countTracker.count >= countRequired)
        {
            averageVelocity = distanceTraveled / countRequired;
            hasCalculated = true;

            Debug.Log("averageVelocity:" + averageVelocity);
        }
    }
}
