using UnityEngine;
using UnityEngine.UI;
using Clase1;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button BackButtonSettings;
    [SerializeField] private Button BackButtonCredits;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private Slider speedSliderPlayer1;
    [SerializeField] private Slider speedSliderPlayer2;
    [SerializeField] private Text speedTextPlayer1;
    [SerializeField] private Text speedTextPlayer2;
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    private bool isPaused = false;

    private void Awake()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked);
        CreditsButton.onClick.AddListener(OnCreditsButtonClicked);
        ExitButton.onClick.AddListener(OnExitButtonClicked);
        BackButtonSettings.onClick.AddListener(OnBackButtonClicked);
        BackButtonCredits.onClick.AddListener(OnBackButtonClicked);
        speedSliderPlayer1.onValueChanged.AddListener(value => OnSpeedSliderChanged(value, player1, speedTextPlayer1));
        speedSliderPlayer2.onValueChanged.AddListener(value => OnSpeedSliderChanged(value, player2, speedTextPlayer2));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void OnDestroy()
    {
        PlayButton.onClick.RemoveAllListeners();
        SettingsButton.onClick.RemoveAllListeners();
        CreditsButton.onClick.RemoveAllListeners();
        ExitButton.onClick.RemoveAllListeners();
        BackButtonSettings.onClick.RemoveAllListeners();
        BackButtonCredits.onClick.RemoveAllListeners();
        speedSliderPlayer1.onValueChanged.RemoveAllListeners();
        speedSliderPlayer2.onValueChanged.RemoveAllListeners();
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        Time.timeScale = 1f;  // Reanuda el juego
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  // Pausa el juego
        isPaused = true;
    }

    private void SetActivePanel(GameObject panel)
    {
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        panel.SetActive(true);
    }

    private void OnPlayButtonClicked()
    {
        Resume();  // Cierra el menú y reanuda el juego
    }

    private void OnSettingsButtonClicked()
    {
        SetActivePanel(settingsPanel);
        Time.timeScale = 0f;  // Mantiene el juego en pausa
    }

    private void OnCreditsButtonClicked()
    {
        SetActivePanel(CreditsPanel);
        Time.timeScale = 0f;  // Mantiene el juego en pausa
    }

    public void OnBackButtonClicked()
    {
        SetPauseMenuActive(true);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnSpeedSliderChanged(float newSpeed, Movement player, Text speedText)
    {
        player.movementSpeed = newSpeed;
        speedText.text = "Speed: " + newSpeed.ToString("F2");
    }

    private void SetPauseMenuActive(bool isActive)
    {
        pauseMenuUI.SetActive(isActive);
        settingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}