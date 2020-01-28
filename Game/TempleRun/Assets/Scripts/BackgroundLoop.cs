using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop instance; //Static because we only want one instance

    private void Awake()
    {
        if (instance == null) //Instace == null because we dont set it then we assign it this instance.
            instance = this;
        else if(instance != this) //If instance != the new instance destroy it
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
