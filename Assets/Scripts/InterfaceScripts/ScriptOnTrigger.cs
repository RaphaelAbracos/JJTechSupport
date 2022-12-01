using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject interfaceControl = GameObject.Find("InterfaceControl");
        GameObject gameObject = GameObject.FindGameObjectWithTag("TriggerEntrou");
        if (other.CompareTag("TriggerPlayer"))
        {
            interfaceControl.GetComponent<ControleFalas>().isPlayerInTable = true;
            gameObject.SetActive(false);
        }
    }

}
