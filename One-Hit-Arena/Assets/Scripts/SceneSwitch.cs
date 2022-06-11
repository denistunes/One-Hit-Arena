using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Update is called once per frame
    public void SwitchScene(string sceneName)
    {
        FindObjectOfType<AudioManager>().Play("UI_Button");
        SceneManager.LoadScene(sceneName);
    }
}
