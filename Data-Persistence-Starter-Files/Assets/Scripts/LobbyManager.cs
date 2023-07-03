using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text playerNameText;

    private string bestScore;   // main������ ������ ����Ʈ ���ھ�.
    private string playerName;  // main������ ������ �÷��̾� �̸�.

    // Start is called before the first frame update
    void Start()
    {
        // ���̽��� ����� ����Ʈ ���ھ� ���� �޾� ������Ʈ.
        bestScore = DataManager.instance.LoadBestScore();
        playerName = DataManager.instance.LoadBestPlayerName();
        bestScoreText.text = "Best Score : " + bestScore;
        playerNameText.text = "Name : " + playerName;
    }

    public void SetPlayerName()
    {
        // �÷��̾� �̸��� ��ǲ�ʵ��� ���ڿ��� ����.
        playerName = inputField.text;
    }
    public void StartButton()
    {
        //SetPlayerName();
        // ��ǲ�ʵ�� ���� �÷��̾� �̸��� �����͸Ŵ��� �̱��� ������ ����.
        DataManager.instance.currentName = playerName;

        // �� ��ȯ
        SceneManager.LoadScene("main");
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
