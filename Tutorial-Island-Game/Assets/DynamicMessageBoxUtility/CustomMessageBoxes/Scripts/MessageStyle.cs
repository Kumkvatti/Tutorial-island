using UnityEngine;
using UnityEngine.UI;

namespace CustomMessageBoxes
{
    /// <summary>
    /// Data Object that holds the style information.
    /// </summary>
    [CreateAssetMenu(menuName = "CustomMessageBox/MessageBox Style")]
    public class MessageStyle : ScriptableObject
    {
        public string styleName;
        [Header("Window")]
		[Tooltip("Leave white if using a background image")]
        public Color backgroundColour = Color.white;
		[Tooltip("Optional")]
        public Sprite backgroundImage;
        [Header("Title")]
        public string titleText = "Your Title Here";
        public Font titleFont;
        public Color titleColour = Color.black;
        [Header("Body Text")]
        [Multiline]
        public string bodyTextText = "Your message here";
        public Color bodyTextColour = Color.black;
        public Font bodyTextFont;
        [Header("Button")]
        public ColorBlock buttonColours = ColorBlock.defaultColorBlock;
        public Sprite buttonBackground;
		[Range(0,1), Tooltip("0 to 1 - invisible to full width of message box.")]
		public float buttonWidth = 1;
        [Header("Button Text")]
        public Color buttonTextColour = Color.black;
        public Font buttonFont;
        public string buttonTextText = "OK";
        [Header("Advanced"), Range(0, 1)]
        public float MessageBoxHeight = 0.75f;
        [Range(0,1)]
        public float MessageBoxWidth = 0.75f;
    }
}
