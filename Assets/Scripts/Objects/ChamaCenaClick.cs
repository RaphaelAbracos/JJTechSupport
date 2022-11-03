using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChamaCenaClick : MonoBehaviour
{
    bool isMouseDentro;
    Color myStartColor, sColor;
    // Start is called before the first frame update
    void Start()
    {   
        myStartColor = GetComponent<MeshRenderer>().material.color;//pega a cor original
        sColor = Color.blue;//define a cor de quando estiver "colidindo"
        isMouseDentro = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMouseDentro == true){
            GetComponent<MeshRenderer>().material.color = sColor;
            if(Input.GetKeyDown(KeyCode.E)){
            
                SceneManager.LoadScene(1);
            }
        }
    }
    void OnMouseEnter(){
        
        GetComponent<MeshRenderer>().material.color = sColor;
        isMouseDentro = true;
    }
    void OnMouseExit(){
        GetComponent<MeshRenderer>().material.color = myStartColor;
        isMouseDentro = false;
    }


}
