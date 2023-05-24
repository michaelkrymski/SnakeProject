using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtoPress : MonoBehaviour
{
    // Start is called before the first frame update

    public void Button()
    {
        SceneManager.LoadScene(1); 
    }
}
