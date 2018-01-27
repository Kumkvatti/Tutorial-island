using UnityEngine;
using UnityEngine.UI;

namespace CustomMessageBoxes
{ 
    /// <summary>
    /// This script is added to each message box created. You don't need to touch it. It just handles the deleting of the message box once the button is pressed.
    /// </summary>
public class DynamicMessageBox : MonoBehaviour
    {
        public GameObject buttonObj;

        void Start()
        {
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(DeleteThisMessageBox); 
        }
        void DeleteThisMessageBox()
        {
            Destroy(gameObject);
        }
    }
}