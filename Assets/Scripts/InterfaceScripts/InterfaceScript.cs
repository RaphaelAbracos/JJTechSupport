using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
   
    public Text ponto;
    public void isPontoLigado(bool isLigado)
    {
        

        if (isLigado)
        {
            ponto.text = ".";
        }
        else
        {
            ponto.text = "";
        }

    }
}
