using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class LimparObjeto : MonoBehaviour
{
    [SerializeField]
    GameObject objetoLimppo;
    public bool isCompleted;

    // Start is called before the first frame update

    void Start()
    {
        objetoLimppo.SetActive(false);
        isCompleted = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        objetoLimppo.SetActive(true);
        this.gameObject.SetActive(false);
        isCompleted = true;
    }
}
