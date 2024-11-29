using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroChange : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Menu");
    }
}
