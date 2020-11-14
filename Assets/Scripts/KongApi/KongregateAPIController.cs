using System;
using UnityEngine;
using System.Runtime.InteropServices;


[Obsolete("Deprecated, not releasing to Kongregate anymore", false)]
public class KongregateAPIController : MonoBehaviour
{
    private static KongregateAPIController instance;

    [DllImport("__Internal")]
    private static extern void KAPIInit();

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        gameObject.name = "KongregateAPI";
        try
        {
            KAPIInit();
        }
        catch
        {
            Debug.LogWarning("Couldn't start the Kongregate API");
        }
    }


}