using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField]
    GameObject pausePasta;
    [SerializeField]
    GameObject ControlesText;
    [SerializeField]
    GameObject VoltarButton;
    [SerializeField]
    GameObject PauseSairButton;
    [SerializeField]
    GameObject PauseResumeButton;
    [SerializeField]
    GameObject PauseControlesButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.Escape))
        {

            GameObject[] pecasComputador = GameObject.FindGameObjectsWithTag("Computador");

            isPaused = !isPaused;
            if (isPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pausePasta.SetActive(true);

                for (int i = 0; i < pecasComputador.Length; i++)
                {
                    pecasComputador[i].GetComponent<MoveObjectAndConect>().enabled = false;
                    pecasComputador[i].GetComponent<MeshCollider>().enabled = false;
                }
            }
            else
            {
                
                Time.timeScale = 1;
                pausePasta.SetActive(false);
                GameObject camera = GameObject.FindGameObjectWithTag("CameraTable");
                if (camera != null && camera.tag.Equals("CameraTable"))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                for (int i = 0; i < pecasComputador.Length; i++)
                {

                    pecasComputador[i].GetComponent<MoveObjectAndConect>().enabled = true;
                    pecasComputador[i].GetComponent<MeshCollider>().enabled = true;
                }
            }

        }

    }
    public void voltar()
    {
        GameObject[] pecasComputador = GameObject.FindGameObjectsWithTag("Computador");
        GameObject camera = GameObject.FindGameObjectWithTag("CameraTable");

        isPaused = false;
        Time.timeScale = 1;
        pausePasta.SetActive(false);

        if (camera != null && camera.tag.Equals("CameraTable"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        for (int i = 0; i < pecasComputador.Length; i++)
        {
            pecasComputador[i].GetComponent<MoveObjectAndConect>().enabled = true;
            pecasComputador[i].GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void sair()
    {
        Application.Quit();

    }
    public void opcoes()
    {
       

        ControlesText.SetActive(true);
        VoltarButton.SetActive(true);

        PauseSairButton.SetActive(false);
        PauseResumeButton.SetActive(false);
        PauseControlesButton.SetActive(false);
    }
    public void voltarOpcoes()
    {


        ControlesText.SetActive(false);
        VoltarButton.SetActive(false);

        PauseSairButton.SetActive(true);
        PauseResumeButton.SetActive(true);
        PauseControlesButton.SetActive(true);



    }
}

