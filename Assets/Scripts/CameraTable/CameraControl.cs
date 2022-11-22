using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera[] cameras;
    public int numeroCameras;
    public int NumeroMaximo;

    void Start()
    {
        try
        {
            NumeroMaximo = cameras.Length;
            numeroCameras = 1;


            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }

            cameras[numeroCameras - 1].gameObject.SetActive(true);
        }
        catch (Exception e){
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("c") && numeroCameras < NumeroMaximo)
        {
            numeroCameras++;
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }

            if (numeroCameras == 1)
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("c") && numeroCameras == NumeroMaximo)
        {
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }

            if (numeroCameras == 1)
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
            numeroCameras = 0;
        }
    }
}