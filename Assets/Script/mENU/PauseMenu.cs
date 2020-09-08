using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUi;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandleMainButtonOnClickEvent()
    {
            Time.timeScale = 1;
            Destroy(gameObject);
            SceneManager.LoadScene("MeinMenu");
    }
    public void HandleResumButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
