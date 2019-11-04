using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    public void ButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
