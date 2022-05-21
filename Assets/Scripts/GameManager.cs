using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerObj;
    private PlayerInput inputComponent;
    // Start is called before the first frame update
    void Start()
    {
        if(playerObj!=null)inputComponent = playerObj.GetComponent<PlayerInput>();
        if(inputComponent != null)inputComponent.enabled = false;
    }

    // Update is called once per frame

}
