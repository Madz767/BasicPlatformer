using UnityEngine;

public class JetBoots_Collectable : MonoBehaviour
{
    private GameObject JetBoots;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
