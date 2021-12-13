using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour, IDamageable<int>
{
    private int health;
    private Slider slider;
    private GameObject character;
    public int Health { get => health; set => health = value; }

    private void Start()
    {
        health = 100;
        character = gameObject;

        try { character.GetComponent<Character>(); }
        catch { Debug.Log("Failed to get a PlayerObject"); }

        try { slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>(); }
        catch { Debug.Log("Failed to get a Slider"); }


        slider.maxValue = health;
        slider.value = health;         
    }
   
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            slider.value = health;
        }
        else 
        {
            character.GetComponent<BoxCollider>().enabled = false;

            try     { SceneManager.LoadScene(0); }
            catch   { Debug.Log("Either you completed the game or something broke with the levels"); }
          
        }
    }
}
