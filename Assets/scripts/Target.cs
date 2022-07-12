using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody TargetRb;
    private float minspeed=12;
    private float maxspeed=16;
    private float maxTorque=10;
    private float xRange=4;
    private float ySpawnPos=2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        TargetRb=GetComponent<Rigidbody>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        TargetRb.AddForce(RandomForce(), ForceMode.Impulse);
        TargetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position= RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minspeed,maxspeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
      return new Vector3(Random.Range(-xRange,xRange),-ySpawnPos);
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
