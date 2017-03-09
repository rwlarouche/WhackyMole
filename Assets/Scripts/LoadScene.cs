using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OnClick(string level) //Object clicked - Load Scene
    {
        SceneManager.LoadScene(level);
    }
}