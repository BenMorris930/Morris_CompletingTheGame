using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;
    private EventManager eventManager;
    [SerializeField] private ParticleSystem expParticleBad;
    [SerializeField] private ParticleSystem expParticleGood;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        targetRB = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(-5, 6), -5);
        targetRB.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        
        if (CompareTag("Bad"))
        {
            eventManager.targetDestroyed?.Invoke(-1);
            Instantiate(expParticleBad, transform.position, expParticleBad.transform.rotation);
        }

        if (CompareTag("Good"))
        {
            eventManager.targetDestroyed?.Invoke(1);
            Instantiate(expParticleGood, transform.position, expParticleGood.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
