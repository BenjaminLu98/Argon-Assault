using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject playerExplosion;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerInput>().enabled = false;
        Instantiate(playerExplosion,transform.position,Quaternion.identity);
        GetComponent<Renderer>().enabled = false;
        
        Invoke("reloadLevel", 1.0f);
    }
    void reloadLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);
    }
}

