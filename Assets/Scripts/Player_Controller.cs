using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player_Controller : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject CounttextObject;

    private Rigidbody rb;
    public int count;
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        CounttextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Orbs collected:" + count.ToString();
        if(count >= 13)
        {
            winTextObject.SetActive(true);
            CounttextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        if (movement.sqrMagnitude > 0.001f)
        {
            float currentSpeed = 5f;
            Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                if (horizontalVelocity.sqrMagnitude > 0.001f)
            {
                Vector3 inputDir = movement.normalized;
                Vector3 velDir = horizontalVelocity.normalized;

                float dot = Vector3.Dot(inputDir, velDir);

                // dot < 0 means opposite directions
                if (dot < 0f)
                {
                    // Boost acceleration when reversing
                    currentSpeed *= 2f; // try 2, 3, etc.
                }
            }
            rb.AddForce(movement * currentSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            CounttextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "haha loser";
            if(count <= 0)
            {
                countText.text = "Orbs collected:" + "wow you really suck";
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        
    }
}
