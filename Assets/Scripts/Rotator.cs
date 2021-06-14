using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Transform pivot1;
    [SerializeField] Transform pivot2;
    [SerializeField] float rotateAmount = 90f;
    [SerializeField] int pivotSwitch = -1;
    [SerializeField] GameObject[] blockers;
    [SerializeField] CinemachineVirtualCamera finishCam;
    [SerializeField] CinemachineVirtualCamera rotarCam;
    [SerializeField] float rotateSpeedFactor = 0.5f;

    int rotarCamSwitch = -1;
    int rotationClock = 1;
    bool isMoving = true;
    float timer = 1;

    bool activateTimer = false;
   // int rotarCamIdx = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTimer)
        {
            timer = timer - Time.deltaTime;
            if(timer <= 0)
            {
                timer = 1;
                activateTimer = false;
            }
        }


        if(isMoving)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                pivotSwitch *= -1;
                rotationClock *= -1;
            }

            if (pivotSwitch > 0)
            {

                this.transform.RotateAround(pivot1.position,
                new Vector3(0f, 1f, 0f) * rotationClock,
                rotateAmount * Time.deltaTime);
            }

            else if (pivotSwitch < 0)
            {
                this.transform.RotateAround(pivot2.position,
                new Vector3(0f, 1f, 0f) * rotationClock,
                rotateAmount * Time.deltaTime);
            }
        }
        
      
    }

    public void Switch()
    {
        pivotSwitch *= -1;
        rotationClock *= -1;
    }



    public void Finish()
    {
        isMoving = false;
        foreach(GameObject blocker in blockers)
        {
            blocker.SetActive(false);
        }
       finishCam.Priority = 100;
    }

    public void SpeedUp()
    {
        rotateAmount += rotateSpeedFactor;
    }

    public void ZoomOut()
    {
        if (!activateTimer)
        {
            activateTimer = true;
            rotarCamSwitch *= -1;
            Debug.Log("Before : " + rotarCam.Priority);
            // rotarCamIdx++;
            if (rotarCamSwitch > 0)
            {
                rotarCam.Priority = 6;
            }

            else
            {
                rotarCam.Priority = 12;
            }

            Debug.Log("After : " + rotarCam.Priority);
        }
       
        // rotarCam= 12 + rotarCamIdx;
        //  rotarCam[rotarCamIdx - 1].Priority = 9;
        
    }
    


}
