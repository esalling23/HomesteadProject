using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableArea : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color hover_color;
    public Color base_color;
    public string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        base_color = Color.white;
        base_color.a = 0.0f;
    }

    public void OnMouseEnter() {
        Debug.Log("Entered");
        sprite.color = hover_color;
    }

    public void OnMouseExit() {
        Debug.Log("Exited");
        sprite.color = base_color;
    }

    public void OnMouseDown() {
        Debug.Log("clicked");
        SceneManager.LoadScene(scene_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
