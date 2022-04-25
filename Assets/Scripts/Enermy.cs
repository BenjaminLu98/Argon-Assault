using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public float health;
    public float damage;
    public int destroyScore;
    bool isDestroyed;
    [SerializeField]public ScoreBorad scoreBorad;
    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        scoreBorad = FindObjectOfType<ScoreBorad>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit the enermy");
        if(other.CompareTag("Ship Beam")&&!isDestroyed){
            health -= damage;
            if (health <= 0.0f)
            {
                isDestroyed = true;
                scoreBorad.score += destroyScore;
                Destroy(this.gameObject, 0.2f);
            }
        }
        
    }
}
