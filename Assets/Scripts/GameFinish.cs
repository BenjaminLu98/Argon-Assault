using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFinish : MonoBehaviour
{
    TMP_Text endText; 
    ScoreBorad scoreBorad;
    // Start is called before the first frame update
    void Start()
    {
        endText = GetComponent<TMP_Text>();
        scoreBorad = FindObjectOfType<ScoreBorad>();
        
    }


    public void onFinished()
    {
        
        endText.text = $"Congratulations!\nYour score is {scoreBorad.score}";

    }
}
