using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private void Awake()
    {
        if(Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
