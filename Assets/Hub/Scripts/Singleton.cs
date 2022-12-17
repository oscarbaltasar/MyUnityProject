using UnityEngine;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance
    {
        get;
        private set;
    }

    public void Awake()
    {
        Instance = this;
    }
}