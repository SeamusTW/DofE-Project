using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rPlayer;
    public Transform tPlayer;
    public Vector3 RespawnPosition = new Vector3(0.0f, 1.0f, 0.0f);
    public float fowardforce = 2000f;
    
    //public GameObject obstacle;
    void Start()
    {
        
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.collider.tag == "Obstacle")
        {
            StartCoroutine(Respawn());
        }
    }
    void Update()
    {
        if (tPlayer.position.x > 8.0f || tPlayer.position.x < -8.0f)
        {
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        Debug.Log("respawning");

       
        tPlayer.position = new Vector3(0.0f, 1.0f, 0.0f);
        rPlayer.velocity = Vector3.zero;
        rPlayer.angularVelocity = Vector3.zero;
        tPlayer.rotation = Quaternion.identity;
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Skeleton" || obj.name == "Zombie" || obj.name == "Creeper" || obj.name == "Tree")
            {
                //Debug.Log("prefab saved!");
            }
            else
            {
                Destroy(obj);
            }
        }
        yield return new WaitForSecondsRealtime(1.0f);
        rPlayer.AddForce(0.0f, 0.0f, fowardforce);
    }
    
}
