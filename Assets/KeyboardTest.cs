using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardTest : MonoBehaviour
{
    void Update()
    {
        // KeyboardCheck.wasPressedThisFrame(Key.Space);        // スペースが押されたか
        // KeyboardCheck.KeyLogs[Key.Space].wasPressedThisFrame // これでも取得できる
        
        // 押されたキーがあった場合、表示する
        foreach (var pair in KeyboardCheck.KeyLogs)
        {
            if (pair.Value.wasPressedThisFrame)
            {
                Debug.Log($"{pair.Key}");
            }
        }
    }
}
