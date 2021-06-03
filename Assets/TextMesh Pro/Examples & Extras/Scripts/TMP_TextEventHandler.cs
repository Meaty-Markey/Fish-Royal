﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace TextMesh_Pro.Scripts
{
    public class TMPTextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [FormerlySerializedAs("m_OnCharacterSelection")]
        [SerializeField]
        private CharacterSelectionEvent mOnCharacterSelection = new CharacterSelectionEvent();

        [FormerlySerializedAs("m_OnSpriteSelection")]
        [SerializeField]
        private SpriteSelectionEvent mOnSpriteSelection = new SpriteSelectionEvent();

        [FormerlySerializedAs("m_OnWordSelection")]
        [SerializeField]
        private WordSelectionEvent mOnWordSelection = new WordSelectionEvent();

        [FormerlySerializedAs("m_OnLineSelection")]
        [SerializeField]
        private LineSelectionEvent mOnLineSelection = new LineSelectionEvent();

        [FormerlySerializedAs("m_OnLinkSelection")]
        [SerializeField]
        private LinkSelectionEvent mOnLinkSelection = new LinkSelectionEvent();

        private Camera _mCamera;
        private Canvas _mCanvas;
        private int _mLastCharIndex = -1;
        private int _mLastLineIndex = -1;
        private int _mLastWordIndex = -1;

        private int _mSelectedLink = -1;


        private TMP_Text _mTextComponent;


        /// <summary>
        ///     Event delegate triggered when pointer is over a character.
        /// </summary>
        public CharacterSelectionEvent ONCharacterSelection
        {
            get => mOnCharacterSelection;
            set => mOnCharacterSelection = value;
        }


        /// <summary>
        ///     Event delegate triggered when pointer is over a sprite.
        /// </summary>
        public SpriteSelectionEvent ONSpriteSelection
        {
            get => mOnSpriteSelection;
            set => mOnSpriteSelection = value;
        }


        /// <summary>
        ///     Event delegate triggered when pointer is over a word.
        /// </summary>
        public WordSelectionEvent ONWordSelection
        {
            get => mOnWordSelection;
            set => mOnWordSelection = value;
        }


        /// <summary>
        ///     Event delegate triggered when pointer is over a line.
        /// </summary>
        public LineSelectionEvent ONLineSelection
        {
            get => mOnLineSelection;
            set => mOnLineSelection = value;
        }


        /// <summary>
        ///     Event delegate triggered when pointer is over a link.
        /// </summary>
        public LinkSelectionEvent ONLinkSelection
        {
            get => mOnLinkSelection;
            set => mOnLinkSelection = value;
        }

        private void Awake()
        {
            // Get a reference to the text component.
            _mTextComponent = gameObject.GetComponent<TMP_Text>();

            // Get a reference to the camera rendering the text taking into consideration the text component type.
            if (_mTextComponent.GetType() == typeof(TextMeshProUGUI))
            {
                _mCanvas = gameObject.GetComponentInParent<Canvas>();
                if (_mCanvas != null)
                {
                    if (_mCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
                    {
                        _mCamera = null;
                    }
                    else
                    {
                        _mCamera = _mCanvas.worldCamera;
                    }
                }
            }
            else
            {
                _mCamera = Camera.main;
            }
        }


        private void LateUpdate()
        {
            if (TMP_TextUtilities.IsIntersectingRectTransform(_mTextComponent.rectTransform, Input.mousePosition,
                _mCamera))
            {
                #region Example of Character or Sprite Selection

                int charIndex =
                    TMP_TextUtilities.FindIntersectingCharacter(_mTextComponent, Input.mousePosition, _mCamera, true);
                if (charIndex != -1 && charIndex != _mLastCharIndex)
                {
                    _mLastCharIndex = charIndex;

                    TMP_TextElementType elementType = _mTextComponent.textInfo.characterInfo[charIndex].elementType;

                    // Send event to any event listeners depending on whether it is a character or sprite.
                    if (elementType == TMP_TextElementType.Character)
                    {
                        SendOnCharacterSelection(_mTextComponent.textInfo.characterInfo[charIndex].character,
                            charIndex);
                    }
                    else if (elementType == TMP_TextElementType.Sprite)
                    {
                        SendOnSpriteSelection(_mTextComponent.textInfo.characterInfo[charIndex].character, charIndex);
                    }
                }

                #endregion


                #region Example of Word Selection

                // Check if Mouse intersects any words and if so assign a random color to that word.
                int wordIndex = TMP_TextUtilities.FindIntersectingWord(_mTextComponent, Input.mousePosition, _mCamera);
                if (wordIndex != -1 && wordIndex != _mLastWordIndex)
                {
                    _mLastWordIndex = wordIndex;

                    // Get the information about the selected word.
                    TMP_WordInfo wInfo = _mTextComponent.textInfo.wordInfo[wordIndex];

                    // Send the event to any listeners.
                    SendOnWordSelection(wInfo.GetWord(), wInfo.firstCharacterIndex, wInfo.characterCount);
                }

                #endregion


                #region Example of Line Selection

                // Check if Mouse intersects any words and if so assign a random color to that word.
                int lineIndex = TMP_TextUtilities.FindIntersectingLine(_mTextComponent, Input.mousePosition, _mCamera);
                if (lineIndex != -1 && lineIndex != _mLastLineIndex)
                {
                    _mLastLineIndex = lineIndex;

                    // Get the information about the selected word.
                    TMP_LineInfo lineInfo = _mTextComponent.textInfo.lineInfo[lineIndex];

                    // Send the event to any listeners.
                    char[] buffer = new char[lineInfo.characterCount];
                    for (int i = 0;
                        i < lineInfo.characterCount && i < _mTextComponent.textInfo.characterInfo.Length;
                        i++)
                    {
                        buffer[i] = _mTextComponent.textInfo.characterInfo[i + lineInfo.firstCharacterIndex].character;
                    }

                    string lineText = new string(buffer);
                    SendOnLineSelection(lineText, lineInfo.firstCharacterIndex, lineInfo.characterCount);
                }

                #endregion


                #region Example of Link Handling

                // Check if mouse intersects with any links.
                int linkIndex = TMP_TextUtilities.FindIntersectingLink(_mTextComponent, Input.mousePosition, _mCamera);

                // Handle new Link selection.
                if (linkIndex != -1 && linkIndex != _mSelectedLink)
                {
                    _mSelectedLink = linkIndex;

                    // Get information about the link.
                    TMP_LinkInfo linkInfo = _mTextComponent.textInfo.linkInfo[linkIndex];

                    // Send the event to any listeners. 
                    SendOnLinkSelection(linkInfo.GetLinkID(), linkInfo.GetLinkText(), linkIndex);
                }

                #endregion
            }
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("OnPointerEnter()");
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("OnPointerExit()");
        }


        private void SendOnCharacterSelection(char character, int characterIndex)
        {
            if (ONCharacterSelection != null)
            {
                ONCharacterSelection.Invoke(character, characterIndex);
            }
        }

        private void SendOnSpriteSelection(char character, int characterIndex)
        {
            if (ONSpriteSelection != null)
            {
                ONSpriteSelection.Invoke(character, characterIndex);
            }
        }

        private void SendOnWordSelection(string word, int charIndex, int length)
        {
            if (ONWordSelection != null)
            {
                ONWordSelection.Invoke(word, charIndex, length);
            }
        }

        private void SendOnLineSelection(string line, int charIndex, int length)
        {
            if (ONLineSelection != null)
            {
                ONLineSelection.Invoke(line, charIndex, length);
            }
        }

        private void SendOnLinkSelection(string linkID, string linkText, int linkIndex)
        {
            if (ONLinkSelection != null)
            {
                ONLinkSelection.Invoke(linkID, linkText, linkIndex);
            }
        }

        [Serializable]
        public class CharacterSelectionEvent : UnityEvent<char, int>
        { }

        [Serializable]
        public class SpriteSelectionEvent : UnityEvent<char, int>
        { }

        [Serializable]
        public class WordSelectionEvent : UnityEvent<string, int, int>
        { }

        [Serializable]
        public class LineSelectionEvent : UnityEvent<string, int, int>
        { }

        [Serializable]
        public class LinkSelectionEvent : UnityEvent<string, string, int>
        { }
    }
}