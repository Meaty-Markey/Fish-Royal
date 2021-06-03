using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TextMesh_Pro.Scripts
{
    public class ChatController : MonoBehaviour
    {
        [FormerlySerializedAs("TMP_ChatInput")]
        public TMP_InputField tmpChatInput;

        [FormerlySerializedAs("TMP_ChatOutput")]
        public TMP_Text tmpChatOutput;

        [FormerlySerializedAs("ChatScrollbar")]
        public Scrollbar chatScrollbar;

        private void OnEnable()
        {
            tmpChatInput.onSubmit.AddListener(AddToChatOutput);
        }

        private void OnDisable()
        {
            tmpChatInput.onSubmit.RemoveListener(AddToChatOutput);
        }


        private void AddToChatOutput(string newText)
        {
            // Clear Input Field
            tmpChatInput.text = string.Empty;

            DateTime timeNow = DateTime.Now;

            tmpChatOutput.text += "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") +
                                  ":" +
                                  timeNow.Second.ToString("d2") + "</color>] " + newText + "\n";

            tmpChatInput.ActivateInputField();

            // Set the scrollbar to the bottom when next text is submitted.
            chatScrollbar.value = 0;
        }
    }
}