using UnityEngine;
using UnityEngine.UI;

namespace CustomMessageBoxes
{
    public class MessageBoxCreator : MonoBehaviour
    {
        private static Canvas messageBoxCanvas;
        private static MessageStyle defaultStyle = new MessageStyle();

        /// <summary>
        /// Creates a message box with the given style. Title, message and button text is optional, as this will be taken from the style itself but you can override if you want.
        /// </summary>
        /// <param name="selectedStyle">A MessageStyle Object</param>
        /// <param name="customTitle">Overrides title text in style</param>
        /// <param name="customMessage">Overrides message text in style</param>
        /// <param name="customButtonText">Overrides button text text in style</param>
        public static void CreateMessageBox(MessageStyle selectedStyle = null, string customTitle = "", string customMessage = "", string customButtonText = "")
        {

            if (selectedStyle == null)
            {
                selectedStyle = defaultStyle;
            }

            CheckForCanvas();
            SetDefaultFonts(selectedStyle);

            //Window
            GameObject newWindow = new GameObject();
            newWindow.transform.parent = messageBoxCanvas.transform;
            newWindow.name = "Dynamic Message Box";
			Image windowImage = newWindow.AddComponent<Image>();
            windowImage.color = selectedStyle.backgroundColour;
            if (selectedStyle.backgroundImage != null)
            {
                windowImage.sprite = selectedStyle.backgroundImage;
            }
            RectTransform windowRect = windowImage.rectTransform;
            windowRect.anchoredPosition = new Vector2(0, 0);
            windowRect.sizeDelta = new Vector2((Screen.width * selectedStyle.MessageBoxWidth), (Screen.height * selectedStyle.MessageBoxHeight));

            //TitleText
            GameObject newText = new GameObject();
            newText.transform.parent = newWindow.transform;
            newText.name = "Dynamic Message Box Title";
            Text text = newText.AddComponent<Text>();
            text.text = selectedStyle.titleText;
            text.color = selectedStyle.titleColour;
            text.resizeTextForBestFit = true;
            RectTransform titleRect = newText.GetComponent<RectTransform>();
            titleRect.sizeDelta = new Vector2(windowRect.rect.width, windowRect.rect.height / 5);
            titleRect.anchoredPosition = new Vector2(0, (0 + (windowRect.rect.height / 2)) - (titleRect.rect.height / 2));
            text.alignment = TextAnchor.MiddleCenter;
            text.font = selectedStyle.titleFont;

            //Button
            GameObject newButton = new GameObject();
            newButton.transform.parent = newWindow.transform;
            newButton.name = "Dynamic Message Box Button";
            Image buttonImage = newButton.AddComponent<Image>();
            Button button = newButton.AddComponent<Button>();
            button.targetGraphic = buttonImage;
            button.colors = selectedStyle.buttonColours;
            RectTransform buttonRect = newButton.GetComponent<RectTransform>();
            buttonRect.sizeDelta = new Vector2(windowRect.rect.width * selectedStyle.buttonWidth, windowRect.rect.height / 10);
            buttonRect.anchoredPosition = new Vector2(0, (0 - (windowRect.rect.height / 2)) + (buttonRect.rect.height / 2));
            if (selectedStyle.buttonBackground != null)
            {
                buttonImage.sprite = selectedStyle.buttonBackground;
            }

            //Button Fuctionality
            DynamicMessageBox dmb = newWindow.AddComponent<DynamicMessageBox>();
            dmb.buttonObj = newButton;

            //ButtonText
            GameObject newButtonText = new GameObject();
            newButtonText.transform.parent = newButton.transform;
            newButtonText.name = "Dynamic Message Box Button Text";
            Text buttonText = newButtonText.AddComponent<Text>();
            buttonText.font = selectedStyle.buttonFont;
            buttonText.text = selectedStyle.buttonTextText;
            buttonText.color = selectedStyle.buttonTextColour;
            RectTransform buttonTextRect = newButtonText.GetComponent<RectTransform>();
            buttonTextRect.sizeDelta = buttonRect.sizeDelta;
            buttonTextRect.anchoredPosition = new Vector2(0, 0);
            buttonText.alignment = TextAnchor.MiddleCenter;
            buttonText.resizeTextForBestFit = true;

            //Body Text
            GameObject newBodyText = new GameObject();
            newBodyText.transform.parent = newWindow.transform;
            newBodyText.name = "Dynamic Message Box Body Text";
            Text bodyText = newBodyText.AddComponent<Text>();
            bodyText.text = selectedStyle.bodyTextText;
            bodyText.font = selectedStyle.bodyTextFont;
            bodyText.color = selectedStyle.bodyTextColour;
            bodyText.resizeTextMaxSize = 30;
            bodyText.alignment = TextAnchor.MiddleCenter;
            bodyText.resizeTextForBestFit = true;
            RectTransform bodyTextRect = newBodyText.GetComponent<RectTransform>();
            float bodyTextHeight = windowRect.rect.height - titleRect.rect.height - buttonRect.rect.height;
            bodyTextRect.sizeDelta = new Vector2(windowRect.rect.width, bodyTextHeight);
            bodyTextRect.anchoredPosition = new Vector2(0, 0);

            //Check for text override
            if (customTitle != "")
            {
                text.text = customTitle;
            }
            if (customMessage != "")
            {
                bodyText.text = customMessage;
            }
            if (customButtonText != "")
            {
                buttonText.text = customButtonText;
            }
        }

        static void CheckForCanvas()
        {
            if (messageBoxCanvas == null)
            {
                CreateCanvas();
            }
        }

        static void CreateCanvas()
        {
            //Create Canvas
            if (messageBoxCanvas == null)
            {
                GameObject canvasObj = new GameObject();
                canvasObj.name = "Messagebox Canvas";
                messageBoxCanvas = canvasObj.AddComponent<Canvas>();
                canvasObj.AddComponent<CanvasScaler>();
                canvasObj.AddComponent<GraphicRaycaster>();
            }
            //Setup Canvas
            messageBoxCanvas.pixelPerfect = true;
            messageBoxCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        static void SetDefaultFonts (MessageStyle selectedStyle)
        {
                if (selectedStyle.bodyTextFont == null)
                {
                    selectedStyle.bodyTextFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                }
                if (selectedStyle.titleFont == null)
                {
                    selectedStyle.titleFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                }
                if (selectedStyle.buttonFont == null)
                {
                    selectedStyle.buttonFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                }
        }

		public static void DestroyAllMessageBoxes()
		{
			if(messageBoxCanvas !=null && messageBoxCanvas.gameObject != null)
			Destroy (messageBoxCanvas.gameObject);
		}
    }
}