using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float movementSpeed;
    public bool horizontalMovement;
    public bool verticalMovement;

    private bool moveLeft;

    void Start()
    {
        moveLeft = true;
    }

    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if (horizontalMovement)
        {
            if(moveLeft)
            {
                //this needs to be multiplied by time.deltatime so that we are moving the platform off of time and not framerate
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                //this needs to be multiplied by time.deltatime so that we are moving the platform off of time and not framerate
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

            }
        }

    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("WallMoveLeftBound"))
        {
            moveLeft = false;
        }
        if (col.gameObject.CompareTag("WallMoveRightBound"))
        {
            moveLeft = true;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(gameObject.transform);
        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(null);
        }

    }
}
