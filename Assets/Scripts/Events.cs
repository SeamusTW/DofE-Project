using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Transform tPlayer;
    public Rigidbody rPlayer;
    public float fowardforce = 2000f;
    public float sidewaysforce = 500f;
    
    public float offset;
    public Object[] Obstacle;
    public float waittime = .1f;
    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    public GameObject ThirdPersonCam;
    public GameObject FirstPersonCam;
    public int CamMode;
    public bool printVelo = false;
    void Start()
    {
        StartCoroutine(CalcVelocity());
        rPlayer.AddForce(0.0f, 0.0f, fowardforce);
        
        coroutine = Generate();
        StartCoroutine(coroutine);
        coroutine2 = waitforseconds();
        StartCoroutine(coroutine2);
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rPlayer.AddForce(sidewaysforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rPlayer.AddForce(-sidewaysforce * Time.deltaTime, 0, 0);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else { 
                CamMode = 1; ;
            }
            StartCoroutine(CameraChange());
        }
        
    }
    IEnumerator CameraChange() {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            FirstPersonCam.SetActive(false);
            ThirdPersonCam.SetActive(true);
        }
        else {
            ThirdPersonCam.SetActive(false);
            FirstPersonCam.SetActive(true);
        }
    }
    IEnumerator CalcVelocity()
    {
        while (true)
        {
            float prevPos = tPlayer.position.z;
            yield return new WaitForEndOfFrame();
            float velocity = (tPlayer.position.z - prevPos) / Time.deltaTime;
            if(printVelo)
                Debug.Log(velocity);

        }
    }
    IEnumerator Generate()
    {
        //Random.Range(-7.5f, 7.5f), 1, Random.Range(player.position.z, player.position.z + 50.0f)
        while (true)
        {
            int obst = Random.Range(1, 4);
            Instantiate(Obstacle[obst], new Vector3(Random.Range(-2.5f, 2.5f), 1, tPlayer.position.z + offset), Quaternion.Euler(0f,180f,0f));
            
            //Debug.Log("object spawned");
            yield return new WaitForSeconds(waittime);
        }
    }
   
    IEnumerator waitforseconds()
    {
        yield return new WaitForSeconds(2);
    }
}
