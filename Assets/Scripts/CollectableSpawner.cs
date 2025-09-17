using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    //hello from the other side...
    public GameObject lowestYSpawn;
    public GameObject highestYSpawn;
    //the code is learning...
    public GameObject fusciaCollectable;
    public GameObject greenCollectable;
    
    //the time for random numbers has arrived
    private int randomPrefab;

    //which collectable to spawn
    private GameObject collectableToSpawn;

    private float time;

    public float delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            spawnObject();
            time = 0f;


        }
    }

    private void spawnObject()
    {
        //this will return a number from 1-2
        randomPrefab = Random.Range(0, 2);
        if (randomPrefab == 0 )
        {
            collectableToSpawn = Instantiate(greenCollectable);
        }
        else if (randomPrefab == 1 )
        {
            collectableToSpawn = Instantiate(fusciaCollectable);
        }

        collectableToSpawn.transform.position = new Vector2(lowestYSpawn.transform.position.x, Random.Range(lowestYSpawn.transform.position.y, highestYSpawn.transform.position.y));
    }

}
