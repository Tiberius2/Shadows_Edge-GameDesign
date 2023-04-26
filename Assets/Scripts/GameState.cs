using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Singleton

    public static GameState Instance;


    private void SetupSingleton()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }

        Instance = this;
    }


    #endregion

    private State oldState;
    private State currentState;

    private void Awake()
    {
        SetupSingleton();

        oldState = State.NewGame;
        currentState = State.Playing;
    }
    
    public bool IsPaused { get { return currentState.Equals(State.Paused); } }

    public void Pause()
    {
        oldState = currentState;
        currentState = State.Paused;
    }

    public void Resume()
    {
        currentState = oldState;
    }
}

public enum State
{
    NewGame,
    Playing,
    Paused,
    GameOver,
    Finished
}
