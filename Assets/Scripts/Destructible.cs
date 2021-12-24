using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    /// <summary>
    /// Уничтоженный объект на сцене. То что может иметь хитпоинты.
    /// </summary>
    public class Destructible : Entity
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }
            if(collision.gameObject.tag == "Ground")
            {
                Destroy(gameObject);
            }
        }
    }
}
