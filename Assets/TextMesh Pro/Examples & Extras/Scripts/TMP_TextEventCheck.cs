using UnityEngine;
using UnityEngine.Serialization;

namespace TextMesh_Pro.Scripts
{
    public class TMPTextEventCheck : MonoBehaviour
    {
        [FormerlySerializedAs("TextEventHandler")]
        public TMPTextEventHandler textEventHandler;

        private void OnEnable()
        {
            if (textEventHandler != null)
            {
                textEventHandler.ONCharacterSelection.AddListener(OnCharacterSelection);
                textEventHandler.ONSpriteSelection.AddListener(OnSpriteSelection);
                textEventHandler.ONWordSelection.AddListener(OnWordSelection);
                textEventHandler.ONLineSelection.AddListener(OnLineSelection);
                textEventHandler.ONLinkSelection.AddListener(OnLinkSelection);
            }
        }


        private void OnDisable()
        {
            if (textEventHandler != null)
            {
                textEventHandler.ONCharacterSelection.RemoveListener(OnCharacterSelection);
                textEventHandler.ONSpriteSelection.RemoveListener(OnSpriteSelection);
                textEventHandler.ONWordSelection.RemoveListener(OnWordSelection);
                textEventHandler.ONLineSelection.RemoveListener(OnLineSelection);
                textEventHandler.ONLinkSelection.RemoveListener(OnLinkSelection);
            }
        }


        private void OnCharacterSelection(char c, int index)
        {
            Debug.Log("Character [" + c + "] at Index: " + index + " has been selected.");
        }

        private void OnSpriteSelection(char c, int index)
        {
            Debug.Log("Sprite [" + c + "] at Index: " + index + " has been selected.");
        }

        private void OnWordSelection(string word, int firstCharacterIndex, int length)
        {
            Debug.Log("Word [" + word + "] with first character index of " + firstCharacterIndex + " and length of " +
                      length + " has been selected.");
        }

        private void OnLineSelection(string lineText, int firstCharacterIndex, int length)
        {
            Debug.Log("Line [" + lineText + "] with first character index of " + firstCharacterIndex +
                      " and length of " + length + " has been selected.");
        }

        private void OnLinkSelection(string linkID, string linkText, int linkIndex)
        {
            Debug.Log("Link Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText +
                      "\" has been selected.");
        }
    }
}