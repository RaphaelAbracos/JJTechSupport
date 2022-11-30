using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class NPCMovement: MonoBehaviour {

    Transform[] Positions;
    [SerializeField] float objectSpeed;

    private bool isFinalpos;
    private int nextPosIndex;
    Transform nextPos;
    private Animator animator;
    GameObject[] waypointList; 

    // Start is called before the first frame update
    void Start()
    {
        waypointList = GameObject.FindGameObjectsWithTag("Waypoint");
        //Deixa a lista de waypoints em ordem
        Array.Sort(waypointList, CompareObNames);
        Positions = new Transform[waypointList.Length];
        for(int i = 0; i < waypointList.Length; i++)
        {
            Positions[i] = waypointList[i].transform; 
        }
        nextPos = Positions[0];
        isFinalpos = false;
        animator = GetComponent<Animator>();
    }


    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
        if (transform.position == nextPos.position && !isFinalpos)
        {
            nextPosIndex++;

            if (nextPosIndex >= Positions.Length)
            {
                isFinalpos=true;
            }
            else
            {
                nextPos = Positions[nextPosIndex];
            }
        }
        else if(transform.position == nextPos.position && isFinalpos)
        {
            animator.SetBool("isWalking", false);

        }
        else
        {
            transform.LookAt(nextPos.transform);
            animator.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
        }
    }



}