using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Velociytracker : MonoBehaviour
{
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI enemyDistance;
    public Player_Controller countTracker;
    public int countRequired = 13;
    public GameObject VelocityTextObject;
    public GameObject EnemyDistanceObject;
    public Transform Enemy;


    private Vector3 lastPosition;
    private float distanceTraveled;
    private float averageVelocity;
    private float EnemyDistance;
    private float AvEnemyDistance;
    private float totalEdistance = 0f;
    private float timer = 0f;

    private bool timerRunning = true;
    private bool hasCalculated = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
        VelocityTextObject.SetActive(false);
        EnemyDistanceObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;

        }
        if (Enemy != null)
        {
            EnemyDistance = Vector3.Distance(Enemy.position, transform.position);
            totalEdistance += EnemyDistance;
        }
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if(!hasCalculated && countTracker.count >= countRequired)
        {
            timerRunning = false;
            averageVelocity = Mathf.Round(distanceTraveled / timer);
            AvEnemyDistance = Mathf.Round(totalEdistance / timer);
            AvEnemyDistance = Mathf.Floor((AvEnemyDistance / 2) / 10);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            hasCalculated = true;

            VelocityTextObject.SetActive(true);
            velocityText.text = "average velocity: " + averageVelocity.ToString() + " M/S";
            EnemyDistanceObject.SetActive(true);
            enemyDistance.text = "average enemy distance: " + AvEnemyDistance.ToString() + "M";

            Debug.Log("time:" + timer);
        }
        
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timerRunning = false;
            averageVelocity = Mathf.Round(distanceTraveled / timer);
            AvEnemyDistance = Mathf.Round(totalEdistance / timer);
            AvEnemyDistance = Mathf.Floor((AvEnemyDistance / 2) / 10);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            hasCalculated = true;

            VelocityTextObject.SetActive(true);
            velocityText.text = "average velocity: " + averageVelocity.ToString() + " M/S";
            EnemyDistanceObject.SetActive(true);
            enemyDistance.text = "average enemy distance: " + AvEnemyDistance.ToString() + "M";

            Debug.Log("time:" + timer);
        }
    }
}
