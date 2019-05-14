using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    Rigidbody rb;

    public float time = 1; 
    bool started = false;
    bool gameOver = false;
    bool spinStart = false;
    public GameObject platform;
    public GameObject particle;

     void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start () {
       
	}
	
	void Update () {
        // Debug.Log("Time: " + " " + Time.deltaTime * time);

        if (time > 5 && time < 10 && speed < maxSpeed)
        {
            speed = 5.5f;
        }
        if (time > 10 && time < 20 && speed < maxSpeed)
        {
            speed = 6f;
        }
        if (time > 20 && time < 30 && speed < maxSpeed)
        {
            speed = 6.5f;
        }
        if (time > 30 && time < 40 && speed < maxSpeed)
        {
            speed = 7f;
        }
        if (time > 40 && time < 50 && speed < maxSpeed)
        {
            speed = 7.5f;
        }


        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                Manager.instance.StartGame();
                spinStart = true;
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.useGravity = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            platform.gameObject.GetComponent<PlatformSpawner>().gameOver = true;
            Destroy(this.gameObject, 1f);
          //  UnityAdManager.instance.ShowAd();
            Manager.instance.GameOver();
            Manager.instance.gameOver = true;
        }
  
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
        if(started && !gameOver){
            time += Time.deltaTime;
        }
        if (spinStart)
        {
            transform.Rotate(new Vector3(speed, 0, speed));
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed,0,0);
        } else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameObject part =  Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
            ScoreManager.instance.score += 5;
        }
    }
}
