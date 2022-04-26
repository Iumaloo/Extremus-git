using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToIsle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string name;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(name);
    }
}
