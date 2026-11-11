using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoaderWin : MonoBehaviour
{

    public Button PlayButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = PlayButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Intro-Loading Screen");
        Debug.Log("Button Pressed");
    }
}
