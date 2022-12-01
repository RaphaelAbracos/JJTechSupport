using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStatus : MonoBehaviour
{
    public bool isCompleted;
    float stopwatch;

    MoveObjectAndConect[] computerParts;

    private GameObject pc;

    void Start()
    {
        stopwatch = 0;
        isCompleted = false;
        pc = GameObject.FindGameObjectWithTag("PC");
        computerParts = pc.GetComponentsInChildren<MoveObjectAndConect>();
        pc.SetActive(false);
        //computerParts = FindObjectsOfType<MoveObjectAndConect>();
        
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
