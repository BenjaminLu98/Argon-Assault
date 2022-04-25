using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBorad : MonoBehaviour
{
    public int score;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        score = 0;
    }
    private void Update()
    {
        text.text = $"{score}";
    }


}
