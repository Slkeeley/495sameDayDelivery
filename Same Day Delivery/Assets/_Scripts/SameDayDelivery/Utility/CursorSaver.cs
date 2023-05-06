using System;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class CursorSaver : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}