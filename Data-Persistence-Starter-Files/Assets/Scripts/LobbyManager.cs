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

    private string bestScore;   // main씬으로 전달할 베스트 스코어.
    private string playerName;  // main씬으로 전달할 플레이어 이름.

    // Start is called before the first frame update
    void Start()
    {
        // 제이슨에 저장된 베스트 스코어 전달 받아 업데이트.
        bestScore = DataManager.instance.LoadBestScore();
        playerName = DataManager.instance.LoadBestPlayerName();
        bestScoreText.text = "Best Score : " + bestScore;
        playerNameText.text = "Name : " + playerName;
    }

    public void SetPlayerName()
    {
        // 플레이어 이름에 인풋필드의 문자열을 저장.
        playerName = inputField.text;
    }
    public void StartButton()
    {
        //SetPlayerName();
        // 인풋필드로 받은 플레이어 이름을 데이터매니저 싱글톤 변수에 저장.
        DataManager.instance.currentName = playerName;

        // 씬 전환
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
