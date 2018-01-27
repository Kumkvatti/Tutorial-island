using UnityEngine;
using CustomMessageBoxes;

class StylePreviewer : MonoBehaviour
{
    public MessageStyle style;
    public string customTitle;
    public string customMessage;
    public string customButtonText;

    void Start()
    { 
        MessageBoxCreator.CreateMessageBox(style);
    }
}

