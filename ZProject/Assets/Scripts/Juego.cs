using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    GenerarHeroe character;

    void Start()
    {
        character = new GenerarHeroe();
        string[] Nombres = new string[] { "Alejandro", "Daniel", "Julio", "Danilo", "Kevin", "Brayan", "Juan", "Sebastian", "Luis", "Alex", "Jorge","Anderson","Cristian","Camilo","Carlos","Felipe","Andres","Carlos","Gustavo","Cesar" };
        int Instancias = Random.Range(4, 10);
        for (int i = 0; i < Instancias; i++)
        {
            int Tipo = Random.Range(0, 2);
            if (Tipo == 0)
                new GenerarAldeano(Nombres[Random.Range(0, 21)]);
            else
                new GenerarZombie();
        }
        Cursor.visible = false;

    }
    
    void Update()
    {
        character.Mover();
    }
}

public class GenerarAldeano
{
    /// <summary>
    /// Se usa para generar un aldeano y retornar su nombre y edad en un string
    /// </summary>
    /// <param name="Nombre">
    /// Nombre del aldeano
    /// </param>
    /// <returns></returns>
    public GenerarAldeano(string Nombre)
    {
        int Edad = Random.Range(15, 101);
        GameObject Aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Aldeano.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Debug.Log("Hola soy " + Nombre + " y tengo " + Edad + " Años");
    }
}

public class GenerarZombie
{
    /// <summary>
    /// Se usa para generar un zombie y retornar el color que tiene
    /// </summary>
    /// <returns></returns>
    public GenerarZombie()
    {
        int color = Random.Range(0, 4);
        string nombreColor = "";
        GameObject zombies = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer renderer = zombies.GetComponent<Renderer>();
        zombies.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));

        if (color == 0)
        {
            renderer.material.color = UnityEngine.Color.cyan;
            nombreColor = "Cyan";
        }
        else if (color == 1)
        {
            nombreColor = "Verde";
            renderer.material.color = UnityEngine.Color.green;
        }
        else if (color == 2)
        {
            nombreColor = "Magenta";
            renderer.material.color = UnityEngine.Color.magenta;
        }

        Debug.Log("Soy un zombie color " + nombreColor);
    }
}

public class GenerarHeroe
{
    Transform heroTransform;

    /// <summary>
    /// Este metodo se encarga de crear el personaje principal
    /// </summary>

    public GenerarHeroe()
    {
        GameObject Heroe = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Renderer color = Heroe.GetComponent<Renderer>();
        heroTransform = Heroe.GetComponent<Transform>();
        color.material.color = Color.red;
        Camera camera = Heroe.AddComponent<Camera>();
        camera.fieldOfView = 70;
    }
    /// <summary>
    /// Este metodo se encarga de permitir el movimiento del jugador
    /// </summary>
    public void Mover()
    {
        if (Input.GetKey(KeyCode.A))
        {
            heroTransform.Rotate(0, -2, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            heroTransform.Rotate(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            heroTransform.Translate(0, 0, 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            heroTransform.Translate(0, 0, -0.5f);
        }
    }
}