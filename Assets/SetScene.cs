using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour
{
    public string toActivate;
    void OnDisable()
    {
        this.gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        Resources.UnloadUnusedAssets();
        foreach (GameObject obj in SceneManager.GetSceneByName("Base").GetRootGameObjects())
        {
            if(obj.name == toActivate)
            {
                obj.SetActive(true);
                return;
            }
            else
            {
                Transform child = obj.transform.Find("Pages");
                {
                    if(child != null)
                    {
                        Transform grandChild = child.transform.Find(toActivate);
                        if(grandChild != null)
                        {
                            grandChild.gameObject.SetActive(true);
                            return;
                        }
                    }
                }
            }
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
