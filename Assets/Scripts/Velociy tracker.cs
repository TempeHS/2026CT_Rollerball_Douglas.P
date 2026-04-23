using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Velociytracker : MonoBehaviour
{
    public TextMeshProUGUI velocityText;
    public Player_Controller countTracker;
    public int countRequired = 13;
    public GameObject VelocityTextObject;

    private Vector3 lastPosition;
    private float distanceTraveled;
    private float averageVelocity;
   
    private bool hasCalculated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
        VelocityTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if(!hasCalculated && countTracker.count >= countRequired)
        {
            averageVelocity = Mathf.Round(distanceTraveled / countRequired);
            hasCalculated = true;

            
            VelocityTextObject.SetActive(true);
            velocityText.text = "average velocity: " + averageVelocity.ToString () + " M/S";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            averageVelocity = Mathf.Round(distanceTraveled / countRequired);
            hasCalculated = true;

            
            VelocityTextObject.SetActive(true);
            velocityText.text = "average velocity: " + averageVelocity.ToString() + " M/S";
        }
    }
}
