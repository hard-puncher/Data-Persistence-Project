using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

[System.Serializable]
public class ScoreData
{
    public int bestScore;

    public ScoreData(int _bestScore)
    {
        this.bestScore = _bestScore;
    }
}

[System.Serializable]
public class NameData
{
    public string name;

    public NameData(string _name)
    {
        this.name = _name;
    }
}

public class DataManager : MonoBehaviour
{
    // 데이터 매니저 싱글톤
    public static DataManager instance;

    // 정보 저장 경로
    private string savePath_Score;
    private string savePath_BestName;

    public string currentName; // 게임 시작시 입력한 이름.

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

        // 싱글톤 데이터매니저 인스턴스가 처음 생성될 때 경로 지정.
        savePath_BestName = Application.persistentDataPath + "/bestName.json";
        savePath_Score = Application.persistentDataPath + "/bestScore.json";
    }

    // 최고 플레이어 이름 저장
    public void SaveBestPlayerName(string _bestName)
    {
        NameData name = new NameData(_bestName);
        string jsonName = JsonUtility.ToJson(name);

        // 파일에 데이터 저장
        File.WriteAllText(savePath_BestName, jsonName);

        Debug.Log(_bestName + "님이 최고기록을 경신했습니다.");
    }

    // 최고 플레이어 이름을 불러오는 함수(제이슨 -> 문자열)
    public string LoadBestPlayerName()
    {
        // 저장된 최고 점수가 있는 경우
        if(File.Exists(savePath_BestName))
        {
           // 파일에서 데이터 읽기
            string jsonName = File.ReadAllText(savePath_BestName);
            NameData name = JsonUtility.FromJson<NameData>(jsonName);

            Debug.Log(name.name + "를 불러옵니다.");

            return name.name;
        }
        // 없는 경우 기본값 반환
        else
        {
            Debug.Log("최고 기록이 없습니다.");

            return " ";
        }
    }

    // 최고 점수를 저장하는 함수
    public void SaveBestScore(int _score)
    {
        ScoreData data = new ScoreData(_score);
        string jsonData = JsonUtility.ToJson(data);

        // 파일에 데이터 저장
        File.WriteAllText(savePath_Score, jsonData);

        Debug.Log(_score + "점이 저장되었습니다.");
    }

    // 최고 점수를 불러오는 함수
    public string LoadBestScore()
    {
        if(File.Exists(savePath_Score))
        {
            // 파일에서 데이터 읽기
            string jsonData = File.ReadAllText(savePath_Score);
            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonData);

            Debug.Log(data.bestScore + "점을 불러옵니다.");

            return data.bestScore.ToString();
        }

        else
        {
            Debug.Log("기록된 최고점수가 없습니다.");

            return "0";
        }
    }
}
