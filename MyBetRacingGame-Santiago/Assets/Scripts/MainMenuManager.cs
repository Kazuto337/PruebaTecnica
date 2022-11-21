using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sceneController.ChangeScene(1);
        }
    }
}
