using System;
using UnityEngine;

public class InputManager {

    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool pressed = false;

    public void OnUpdate() {

        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null) {

            if (Input.GetMouseButton(0)) {

                MouseAction.Invoke(Define.MouseEvent.Press); ;
                pressed = true;
            }
            else {

                if(pressed == true) {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                pressed = false;
            }


        }

    }
}
