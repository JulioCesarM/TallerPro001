using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    GenerarHeroe character;

    void Start()
    {
        character = new GenerarHeroe();
        string[] nombres = new string[] { "Alejandro", "Daniel", "Julio", "Danilo", "Kevin", "Brayan", "Juan", "Sebastian", "Luis", "Alex", "Jorge","Anderson","Cristian","Camilo","Carlos","Felipe","Andres","Carlos","Gustavo","Cesar" };
        int instancias = Random.Range(4, 10);
        for (int i = 0; i < instancias; i++)
        {
            int tipo = Random.Range(0, 2);
            if (tipo == 0)
                new GenerarAldeano(nombres[Random.Range(0, 21)]);
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
    /// <param name="nombre">
    /// Nombre del aldeano
    /// </param>
    public GenerarAldeano(string nombre)
    {
        int edad = Random.Range(15, 101);
        GameObject aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube);
        aldeano.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Debug.Log(DarMensaje(nombre, edad));
    }

    /// <summary>
    /// Este metodo es para crear el mensaje del adeano
    /// </summary>
    /// <param name="nombre">
    /// Nombre asignado del aldeano
    /// </param>
    /// <param name="edad">
    /// Edad asignada del aldeano
    /// </param>
    /// <returns>
    /// Retorna el mensaje del aldeano
    /// </returns>
    string DarMensaje(string nombre,int edad)
    {
        string mensaje = "Hola soy " + nombre + " y tengo " + edad + " Años";
        return mensaje;
    }
}

public class GenerarZombie
{
    /// <summary>
    /// Se usa para generar un zombie y retornar el color que tiene
    /// </summary>
    public GenerarZombie()
    {
        int color = Random.Range(0, 4);
        string nombreColor = "";
        GameObject zombies = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer renderer = zombies.GetComponent<Renderer>();
        zombies.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));

        if (color == 0)
        {
            renderer.material.color = Color.cyan;
            nombreColor = "Cyan";
        }
        else if (color == 1)
        {
            nombreColor = "Verde";
            renderer.material.color = Color.green;
        }
        else if (color == 2)
        {
            nombreColor = "Magenta";
            renderer.material.color = Color.magenta;
        }

        Debug.Log(DarMensaje(nombreColor));
    }

    /// <summary>
    /// Este metodo crea el mensaje del zombie 
    /// </summary>
    /// <param name="color">
    /// Color asignado al zombie
    /// </param>
    /// <returns>
    /// Retorna el mensaje del aldeano
    /// </returns>
    string DarMensaje(string color)
    {
        string mensaje = "Soy un zombie de color " + color;
        return mensaje;
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
        GameObject heroe = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Renderer color = heroe.GetComponent<Renderer>();
        heroTransform = heroe.GetComponent<Transform>();
        color.material.color = Color.red;
        Camera camera = heroe.AddComponent<Camera>();
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