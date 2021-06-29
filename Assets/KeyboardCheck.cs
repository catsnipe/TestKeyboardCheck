using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardCheck : MonoBehaviour
{
    public class InputLog
    {
        public bool isPressed;
        public bool wasPressedThisFrame;
        public bool wasReleasedThisFrame;
    }

    public static Dictionary<Key, InputLog>   KeyLogs;

    void Awake()
    {
        KeyLogs = new Dictionary<Key, InputLog>();

        foreach (Key val in Enum.GetValues(typeof(Key)))
        {
            // IMESelected は Key でなく Button に属する？
            if (val == Key.None || val == Key.IMESelected)
            {
                continue;
            }

            if (KeyLogs.ContainsKey(val) == false)
            {
                KeyLogs.Add(val, new InputLog());
            }
        }
    }

    IEnumerator Start()
    {
        while (true)
        {
            foreach (var pair in KeyLogs)
            {
                InputLog log       = pair.Value;
                bool     isPressed = Keyboard.current[pair.Key].isPressed;

                log.wasPressedThisFrame  = false;
                log.wasReleasedThisFrame = false;

                if (isPressed == true)
                {
                    if (log.isPressed == false) log.wasPressedThisFrame = true;
                }
                else
                {
                    if (log.isPressed == true)  log.wasReleasedThisFrame = true;
                }

                log.isPressed = isPressed;
            }

            yield return null;
        }
    }

    public static bool isPressed(Key val)
    {
        if (KeyLogs?.ContainsKey(val) == false)
        {
            return false;
        }

        return KeyLogs[val].isPressed;
    }

    public static bool wasPressedThisFrame(Key val)
    {
        if (KeyLogs?.ContainsKey(val) == false)
        {
            return false;
        }

        return KeyLogs[val].wasPressedThisFrame;
    }

    public static bool wasReleasedThisFrame(Key val)
    {
        if (KeyLogs?.ContainsKey(val) == false)
        {
            return false;
        }

        return KeyLogs[val].wasPressedThisFrame;
    }
}
