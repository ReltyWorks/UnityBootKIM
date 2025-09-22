using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    // �ڽ� ������Ʈ���� �̸��� ������������ �������
    enum Buttons
    {
        PointButton,
    }

    // �ڽ� ������Ʈ���� �̸��� ������������ �������
    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        ScoreText
    }

    private void Start()
    {
        // ���� �������� ��������� �� ���ĺ��� ���۳�Ʈ���� ���
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        // ���� �������� �ش� �ϴ� ������ ���۳�Ʈ �����ͼ� ���
        GetText((int)Texts.ScoreText).text = "Bind Test";
    }

    private int _score = 0;

    public void OnButtonClicked()
    {
        ++_score;
    }
}