using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
  
    
    public float fowardforce = 2000f;
    public float sidewaysforce = 500f;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(CalcVelocity());
        rb.AddForce(0.0f, 0.0f, fowardforce);

    }
    void FixedUpdate()
    {

       
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0);
        }
    }
    IEnumerator CalcVelocity()
    {
        while (true)
        {
            float prevPos = player.position.z;
            yield return new WaitForEndOfFrame();
            float velocity = (player.position.z-prevPos) / Time.deltaTime;
            Debug.Log(velocity);

        }
    }
}
