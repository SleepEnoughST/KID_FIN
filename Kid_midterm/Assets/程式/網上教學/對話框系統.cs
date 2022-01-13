using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 對話框系統 : MonoBehaviour
{
    public GameObject move;
    public GameObject talk;
    public 課程 A;
    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文字文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed = 0.1f;

    bool textFinished;
    bool cancelTyping;

    [Header("頭像")]
    public Sprite face01, face02;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            A.GetComponent<課程>().enabled = true;
            return;
        }
        //if (Input.GetKeyDown(KeyCode.Z) && textFinished)
        //{
            //textLabel.text = textList[index];
            //index++;
            //StartCoroutine(SetTextUI());
        //}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
        A.GetComponent<課程>().enabled = false;
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }
    
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "A":
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                faceImage.sprite = face02;
                index++;
                break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length -1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
