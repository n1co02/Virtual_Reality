using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour

    
{
    [SerializeField] TextMesh scoreText;

    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreManager.score;
    }
}
