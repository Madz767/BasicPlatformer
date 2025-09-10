using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    private int maxNumJumps = 1;
    private int numJumps;
    public float jumpPower;
    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello from PlayerMovement");
        rb = GetComponent<Rigidbody2D>();
        numJumps = maxNumJumps;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        // used to move the player from left to right based on left to right
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        flipPlayerSprite(inputHorizontal);
        rb.linearVelocity = new Vector2(movementSpeed*inputHorizontal, rb.linearVelocity.y);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps == 1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            numJumps = 0;
        }

    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        //this will be used to flip the sprites of the player
        //works off of a 0 to 1 value to determine which way the player is facing
        if (inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if(inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        //==============================================
        //this allows for only one jump from the ground
        //==============================================
        if (col.gameObject.CompareTag("Ground"))
        {
            numJumps = maxNumJumps;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            string fromPink = collision.gameObject.GetComponent<PinkCollectable>().getTestString();
            Debug.Log(fromPink);
        }
    }

}
