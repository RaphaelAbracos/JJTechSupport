using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTable : MonoBehaviour
{
    [SerializeField] private bool isMouse;
    // Start is called before the first frame update
    void Start()
    {   
              
    }

    // Update is called once per frame
    void Update()
    {
          //if(isMouse){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //}
    }
}
