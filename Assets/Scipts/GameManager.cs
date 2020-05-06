using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TargetSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator TargetSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }

}
