using UnityEngine;
using LLMUnity;
using TMPro;


namespace LLMUnitySamples
{
    public class PlayerInteraction : MonoBehaviour
    {
        public LLM llm;
        public TMP_InputField playerText;
        public TMP_Text AIText;

        void Start()
        {
            
            playerText.onSubmit.AddListener(OnInputFieldSubmit);
            playerText.Select();
        }

        
        void OnInputFieldSubmit(string message)
        {
            playerText.interactable = false; 
            AIText.text = "..."; 
            
            _ = llm.Chat(message, SetAIText, AIReplyComplete);
        }

        
        public void SetAIText(string text)
        {
            AIText.text = text;
        }

        
        public void AIReplyComplete()
        {
            playerText.interactable = true; 
            playerText.Select(); 
            playerText.text = ""; 
        }

        
        public void CancelRequests()
        {
            llm.CancelRequests();
            AIReplyComplete();
        }

        public void ExitGame()
        {
            Debug.Log("Exit button clicked");
            Application.Quit();
        }
    }
}