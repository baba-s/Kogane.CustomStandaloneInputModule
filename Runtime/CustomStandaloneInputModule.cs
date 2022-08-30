using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Kogane
{
    /// <summary>
    /// StandaloneInputModule を拡張したクラス
    /// </summary>
    public sealed class CustomStandaloneInputModule : StandaloneInputModule
    {
        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// EventSystem.current.IsPointerOverGameObject が検出したゲームオブジェクトを返します
        /// </summary>
        [CanBeNull]
        public GameObject GetLastPointerGameObject()
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return GetLastPointerGameObject( kMouseLeftId );
        }

        /// <summary>
        /// EventSystem.current.IsPointerOverGameObject が検出したゲームオブジェクトを返します
        /// </summary>
        [CanBeNull]
        public GameObject GetLastPointerGameObject( int pointerId )
        {
            var lastPointer = GetLastPointerEventData( pointerId );
            return lastPointer?.pointerCurrentRaycast.gameObject;
        }

        /// <summary>
        /// Unity エディタならマウスクリック、それ以外なら最初のタッチを使用して
        /// EventSystem.current.IsPointerOverGameObject が検出したゲームオブジェクトを返します
        /// </summary>
        [CanBeNull]
        public GameObject GetLastPointerGameObjectByFirstPointerId()
        {
            return Application.isEditor
                    ? GetLastPointerGameObject()
                    : GetLastPointerGameObject( Input.GetTouch( 0 ).fingerId )
                ;
        }
    }
}