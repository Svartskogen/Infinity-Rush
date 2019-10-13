using UnityEngine;
using System.Runtime.InteropServices;

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

        Object.DontDestroyOnLoad(gameObject);
        gameObject.name = "KongregateAPI";

        try
        {
            KAPIInit();
        }
        catch
        {
            Debug.LogError("No se pudo iniciar la API de kong");
            //throw;
        }
    }


}