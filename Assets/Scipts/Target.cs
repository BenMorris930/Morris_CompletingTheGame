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
        transform.position = new Vector3(Random.Range(-5, 6), -1);
        targetRB.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameRunning)
        {
            targetRB.useGravity = false;
            targetRB.velocity = Vector3.zero;
            targetRB.angularVelocity = Vector3.zero;

        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameRunning)
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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Good")) eventManager.gameOverEvent?.Invoke();
        Destroy(gameObject);
    }
}
