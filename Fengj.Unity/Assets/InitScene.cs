using Fengj.GSessions;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Global.session = new GSession();

        SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}