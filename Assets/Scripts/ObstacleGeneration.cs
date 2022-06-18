using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public Transform player;
    public float offset;
    public Object Obstacle;
    public float waittime = .1f;
    private IEnumerator coroutine;
   
    
    // Start is called before the first frame update
    void Start()
    {
        coroutine = Generate();
        StartCoroutine(coroutine);
       
        
    }
   
    // Update is called once per frame
    IEnumerator Generate()
    {
        //Random.Range(-7.5f, 7.5f), 1, Random.Range(player.position.z, player.position.z + 50.0f)
        while (true)
        {
            Instantiate(Obstacle, new Vector3(Random.Range(-7.5f, 7.5f), 1,player.position.z + offset), Quaternion.identity);
            Debug.Log("object spawned");
            yield return new WaitForSeconds(waittime);
        }
    }
}


