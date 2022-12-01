using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject interfaceControl;
    GameObject gameObject;
    private void Start()
    {
        interfaceControl = GameObject.Find("InterfaceControl");
        gameObject = GameObject.FindGameObjectWithTag("TriggerEntrou");
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("TriggerPlayer"))
        {
            interfaceControl.GetComponent<ControleFalas>().isPlayerInTable = true;
            //gameObject.SetActive(false);
        }
    }

}
