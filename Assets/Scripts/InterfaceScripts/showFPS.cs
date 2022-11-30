using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showFPS : MonoBehaviour
{
    public Text fpsText;
    public float deltaTime;

    void Update()
    {

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        if(Mathf.Ceil(fps) > 1000)
        {
            fpsText.text = "";
        }
        else
        {
            fpsText.text = Mathf.Ceil(fps).ToString();
        }
        
    }
}