using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float HThrow = 10;
    [SerializeField] float VThrow = 10;


    float HInput, VInput;
    float HMax = 30f;
    float VMax = 20f;
    [SerializeField] float yawSpeed = 150f;
    [SerializeField] float rollSpeed = 30f;
    [SerializeField] float yawMax = 60f;
    [SerializeField] float rollMax = 30f;



    List<ParticleSystem> beamList;

    // Start is called before the first frame update
    void Start()
    {
        beamList = new List<ParticleSystem>();
        ProcessBeamList();
    }

    private void ProcessBeamList()
    {
        var beamObjects = GameObject.FindGameObjectsWithTag("Ship Beam");
        foreach (var beamObject in beamObjects)
        {
            var beam = beamObject.GetComponent<ParticleSystem>();
            beamList.Add(beam);
        }
    }


    // Update is called once per frame
    void Update()
    {
        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");
        ProcessMovement();
        ProcessRotation();
        ProcessFire();
    }

    // Aircraft cannot rotate when the timeline runs because its rotation has been recorded by the timeline.
    void ProcessRotation()
    {
        var yawInput = -HInput;
        var rollInput = -VInput;
        if (yawInput != 0)
        {
            transform.Rotate(new Vector3(0, 0, yawInput * yawSpeed * Time.deltaTime), Space.Self);
            if (transform.localEulerAngles.z >= yawMax && transform.localEulerAngles.z <= 360.0f - yawMax)
            {
                if (yawInput > 0)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, yawMax);
                }
                else if (yawInput < 0)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -yawMax);
                }
            }
        }
        else
        {
            if (transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z <= yawMax+Mathf.Epsilon)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Clamp(transform.localEulerAngles.z - yawSpeed * Time.deltaTime, 0f, transform.localEulerAngles.z));
            }
            else if(360f-yawMax-Mathf.Epsilon <= transform.localEulerAngles.z && transform.localEulerAngles.z<=360)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Clamp(transform.localEulerAngles.z + yawSpeed * Time.deltaTime, transform.localEulerAngles.z, 360f));
            }
        }

        //if (rollInput != 0)
        //{
        //    transform.Rotate(new Vector3(rollInput * rollSpeed * Time.deltaTime, 0, 0), Space.Self);
        //    if (transform.localEulerAngles.x >= rollMax && transform.localEulerAngles.x <= 360.0f - rollMax)
        //    {
        //        if (rollInput > 0)
        //        {
        //            transform.localEulerAngles = new Vector3(rollMax, transform.localEulerAngles.y, transform.localEulerAngles.z );
        //        }
        //        else if (rollInput < 0)
        //        {
        //            transform.localEulerAngles = new Vector3(-rollMax, transform.localEulerAngles.y, transform.localEulerAngles.z );
        //        }
        //    }
        //}
        //else
        //{
        //    if (transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x <= rollMax)
        //    {
        //        transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x - rollSpeed * Time.deltaTime, 0f, transform.localEulerAngles.x), transform.localEulerAngles.y, transform.localEulerAngles.z);
        //    }
        //    else if (360f - rollMax <= transform.localEulerAngles.x && transform.localEulerAngles.x <= 360)
        //    {
        //        transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x + rollSpeed * Time.deltaTime, transform.localEulerAngles.x, 360f), transform.localEulerAngles.y, transform.localEulerAngles.z);
        //    }
        //}
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
    }

    void ProcessMovement()
    {
        float updatedX = Mathf.Clamp(transform.localPosition.x + HInput * HThrow * Time.deltaTime, -HMax, HMax);
        float updatedY = Mathf.Clamp(transform.localPosition.y + VInput * VThrow * Time.deltaTime, -VMax, VMax);
        transform.localPosition = new Vector3(
            updatedX,
            updatedY,
            transform.localPosition.z
        );
    }

    void ProcessFire()
    {
        if (Input.GetButton("Fire1"))
        {
            foreach(var beam in beamList)
            {
                if(!beam.isPlaying)
                {
                    beam.Play();
                }
            }
        }
    }

    
}
