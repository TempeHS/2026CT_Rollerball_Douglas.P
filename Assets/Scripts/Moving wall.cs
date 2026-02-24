using UnityEngine;

public class Movingwall : MonoBehaviour
{
    public float speed = 0;
    private float movementX;
    private float movementY;
    private Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(movementX, 0.0f,movementY);

        rb.AddForce(movement * speed);  
         transform.Translate(new Vector3(5, 0, 0) * Time.deltaTime);
         rb.AddForce(movement * speed);
    }
}
    