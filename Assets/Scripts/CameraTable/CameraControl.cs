using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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


     GameObject interfaceControl = GameObject.Find("InterfaceControl");
    Vector3 posicaoFinalComputador = new Vector3(10.2539997f, 1.54400003f, 8.5909996f);
        Vector3 posicaoFinalMesa = new Vector3(9.76200008f, 1.84300005f, 9.535585f);
        

        if (Input.GetKeyDown("c") && numeroCameras < NumeroMaximo)
        {

            interfaceControl.GetComponent<InterfaceScript>().isLigarLegendaImagens(false);
            interfaceControl.GetComponent<InterfaceScript>().isPontoLigado(false);
            numeroCameras++;
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }

            if (numeroCameras == 1)
            {

                interfaceControl.GetComponent<InterfaceScript>().isPontoLigado(true);
                //Computador
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.Find("Player").transform.position = posicaoFinalComputador;
            }
            else
            {

                interfaceControl.GetComponent<InterfaceScript>().isLigarLegendaImagens(true);
                interfaceControl.GetComponent<InterfaceScript>().isPontoLigado(false);
                //mesa
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").transform.position = posicaoFinalMesa;
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown("c") && numeroCameras == NumeroMaximo)
        {
            interfaceControl.GetComponent<InterfaceScript>().isLigarLegendaImagens(false);
            foreach (Camera obj in cameras)
            {
                obj.gameObject.SetActive(false);
            }

            if (numeroCameras == 1)
            {
                interfaceControl.GetComponent<InterfaceScript>().isPontoLigado(false);
                //Computador
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.Find("Player").transform.position = posicaoFinalComputador;
            }
            else
            {
                interfaceControl.GetComponent<InterfaceScript>().isPontoLigado(false);
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").transform.position = posicaoFinalMesa;
            }
            cameras[numeroCameras - 1].gameObject.SetActive(true);
            numeroCameras = 0;
        }

    }
}