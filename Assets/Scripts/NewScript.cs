using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tPlayer;
    public Rigidbody rPlayer;
    void Start()
    {
        rPlayer.AddForce(0.0f, 0.0f, 2000f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
