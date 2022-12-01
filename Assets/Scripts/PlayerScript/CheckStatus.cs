using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStatus : MonoBehaviour
{
    public bool isCompleted;
    public bool isPecasCompleted;
    float stopwatch;

    MoveObjectAndConect[] computerParts;
    LimparObjeto[] pecasPartes;

    private GameObject pc;
    private GameObject pecas;

    void Start()
    {
        stopwatch = 0;
        isCompleted = false;
        pc = GameObject.FindGameObjectWithTag("PC");
        computerParts = pc.GetComponentsInChildren<MoveObjectAndConect>();
        pc.SetActive(false);

        pecas = GameObject.FindGameObjectWithTag("Pecas");
        pecasPartes = pecas.GetComponentsInChildren<LimparObjeto>();
        pecas.SetActive(false);
    }
    void Update()
    {
        stopwatch += Time.deltaTime;
        if (stopwatch >= 0.2f)// 5HZ
        {
            stopwatch = 0;
            int countConectedParts = 0;
            
            for(int x = 0; x< computerParts.Length; x++)
            {
                if (computerParts[x].isConected)
                {
                    countConectedParts++;
                }
            }
            if(countConectedParts >= computerParts.Length && pc.activeSelf)
            {
                isCompleted = true;
            }
            else
            {
                isCompleted = false;
            }

            int countPecasParts = 0;
            for(int i = 0; i<  pecasPartes.Length; i++)
            {
                if (pecasPartes[i].isCompleted)
                {
                    countPecasParts++;
                }
            }
            if(countPecasParts >= pecasPartes.Length && pecas.activeSelf)
            {
                isPecasCompleted = true;
            }
            else
            {
                isPecasCompleted = false;
            }
        }

    }

    public void ResetProperties()
    {
        stopwatch = 0;
        isCompleted = false;
        pc = GameObject.FindGameObjectWithTag("PC");
        computerParts = pc.GetComponentsInChildren<MoveObjectAndConect>();
        //pc.SetActive(false);
    }
}
