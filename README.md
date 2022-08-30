# Kogane Custom Standalone Input Module

EventSystem.current.IsPointerOverGameObject が検出したゲームオブジェクトを取得できる StandaloneInputModule

## 使用例

```csharp
using Kogane;
using UnityEngine;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour
{
    [SerializeField] private CustomStandaloneInputModule m_module;

    private void Update()
    {
        if ( EventSystem.current.IsPointerOverGameObject() )
        {
            // EventSystem.current.IsPointerOverGameObject が検出したゲームオブジェクトを取得
            var lastPointerGameObject = m_module.GetLastPointerGameObject();

            Debug.Log( lastPointerGameObject, lastPointerGameObject );
        }
    }
}
```