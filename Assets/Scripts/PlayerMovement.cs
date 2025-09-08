using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello from PlayerMovement");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        //jump();
    }

    private void movePlayerLateral()
    {
        // used to move the player from left to right based on left to right
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movementSpeed*inputHorizontal, rb.linearVelocity.y);
    }    

    //private void jump()
    //{



    //}


}
