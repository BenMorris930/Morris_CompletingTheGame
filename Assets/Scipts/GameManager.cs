using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TargetSpawner());
        UpdateScore(0);
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

    public void UpdateScore(int delta)
    {
        score += delta;
        if (score < 0) score = 0;
        scoreText.text = "Score: " + score;
    }
}
