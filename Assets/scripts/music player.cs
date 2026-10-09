using UnityEngine;

public class musicplayer : MonoBehaviour
{
    static musicplayer instance = null;
 
    void Awake()
    {
        if (instance == this) { return; }
 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else       
        {
            Destroy(gameObject);
            this.enabled = false;
        }  
    }
}
