using System;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        
        public void GameOver()
        {
            Debug.Log("Game Over");
        }
        
        public void GameWin()
        {
            Debug.Log("Game Win");
        }
        
        public void RestartGame()
        {
            Debug.Log("Restart Game");
        }
        
        public void StartGame()
        {
            Debug.Log("Start Game");
        }
        
    }
