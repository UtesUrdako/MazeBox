using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button start;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    private void Awake()
    {
        Time.timeScale = 0f;
        start.onClick.AddListener(() =>
        {
            startPanel.SetActive(false);
            Time.timeScale = 1f;
        });
    }

    public void Finish()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
    }
}
