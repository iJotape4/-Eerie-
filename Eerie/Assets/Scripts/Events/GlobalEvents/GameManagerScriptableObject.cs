using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "Game Manager", menuName = "ScriptableObjects/Events/Game Manager", order = 1)]
    public class GameManagerScriptableObject : ScriptableObject
    {   
        GameState gameState = GameState.mainMenu;

        protected UnityEvent<GameState> gameStateChangeEvent;

        private void OnEnable()
        {
            gameState = GameState.mainMenu;
            if(gameStateChangeEvent ==null)
                gameStateChangeEvent = new UnityEvent<GameState>();
        }

        public void Win()
        {
            gameState = GameState.win;             
            gameStateChangeEvent?.Invoke(gameState);
        }

         public void Lose()
        {
            gameState = GameState.death;
            Debug.Log("GAME OVER");
            gameStateChangeEvent?.Invoke(gameState);
        }
        
        protected enum GameState 
        {
            mainMenu,
            playing,
            paused,
            win,
            death
        }
    }
}


