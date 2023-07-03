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
    // ������ �Ŵ��� �̱���
    public static DataManager instance;

    // ���� ���� ���
    private string savePath_Score;
    private string savePath_BestName;

    public string currentName; // ���� ���۽� �Է��� �̸�.

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

        // �̱��� �����͸Ŵ��� �ν��Ͻ��� ó�� ������ �� ��� ����.
        savePath_BestName = Application.persistentDataPath + "/bestName.json";
        savePath_Score = Application.persistentDataPath + "/bestScore.json";
    }

    // �ְ� �÷��̾� �̸� ����
    public void SaveBestPlayerName(string _bestName)
    {
        NameData name = new NameData(_bestName);
        string jsonName = JsonUtility.ToJson(name);

        // ���Ͽ� ������ ����
        File.WriteAllText(savePath_BestName, jsonName);

        Debug.Log(_bestName + "���� �ְ����� ����߽��ϴ�.");
    }

    // �ְ� �÷��̾� �̸��� �ҷ����� �Լ�(���̽� -> ���ڿ�)
    public string LoadBestPlayerName()
    {
        // ����� �ְ� ������ �ִ� ���
        if(File.Exists(savePath_BestName))
        {
           // ���Ͽ��� ������ �б�
            string jsonName = File.ReadAllText(savePath_BestName);
            NameData name = JsonUtility.FromJson<NameData>(jsonName);

            Debug.Log(name.name + "�� �ҷ��ɴϴ�.");

            return name.name;
        }
        // ���� ��� �⺻�� ��ȯ
        else
        {
            Debug.Log("�ְ� ����� �����ϴ�.");

            return " ";
        }
    }

    // �ְ� ������ �����ϴ� �Լ�
    public void SaveBestScore(int _score)
    {
        ScoreData data = new ScoreData(_score);
        string jsonData = JsonUtility.ToJson(data);

        // ���Ͽ� ������ ����
        File.WriteAllText(savePath_Score, jsonData);

        Debug.Log(_score + "���� ����Ǿ����ϴ�.");
    }

    // �ְ� ������ �ҷ����� �Լ�
    public string LoadBestScore()
    {
        if(File.Exists(savePath_Score))
        {
            // ���Ͽ��� ������ �б�
            string jsonData = File.ReadAllText(savePath_Score);
            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonData);

            Debug.Log(data.bestScore + "���� �ҷ��ɴϴ�.");

            return data.bestScore.ToString();
        }

        else
        {
            Debug.Log("��ϵ� �ְ������� �����ϴ�.");

            return "0";
        }
    }
}
