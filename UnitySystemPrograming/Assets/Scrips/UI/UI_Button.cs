using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    // 자식 오브젝트들의 이름을 숫자형식으로 들고있음
    enum Buttons
    {
        PointButton,
    }

    // 자식 오브젝트들의 이름을 숫자형식으로 들고있음
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
        // 위에 만들어놓은 저장공간에 각 형식별로 컴퍼넌트들을 등록
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        // 저장 공간에서 해당 하는 형식의 컴퍼넌트 가져와서 사용
        GetText((int)Texts.ScoreText).text = "Bind Test";
    }

    private int _score = 0;

    public void OnButtonClicked()
    {
        ++_score;
    }
}