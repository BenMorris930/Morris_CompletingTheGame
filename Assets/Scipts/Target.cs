using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
