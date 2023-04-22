using System;
using System.Collections;
using UnityEngine;

public class WaitForTimeThenExecute : MonoBehaviour
{
    public float delay = 2.0f;

    private Action action;

    public static void ExecuteAfterDelay(float delay, Action action)
    {
        GameObject gameObject = new("WaitForTimeThenExecute");

        WaitForTimeThenExecute instance = gameObject.AddComponent<WaitForTimeThenExecute>();
        instance.delay = delay;
        instance.action = action;
        instance.StartCoroutine(instance.WaitAndExecute());
    }

    private IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
        Destroy(gameObject);
    }
}
