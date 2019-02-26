using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    Character character = new Character();

    void Start()
    {
        Generador Generador = new Generador();
        string[] Nombres = new string[] { "Alejandro", "Daniel", "Julio", "Danilo", "Kevin", "Brayan", "Juan", "Sebastian", "Luis", "Alex", "Jorge","Anderson","Cristian","Camilo","Carlos","Felipe","Andres","Carlos","Gustavo","Cesar" };
        int Instancias = Random.Range(4, 10);
        string Informacion = "";
        for (int i = 0; i < Instancias; i++)
        {
            int Tipo = Random.Range(0, 2);
            if (Tipo == 0)
                Informacion = Generador.GenerarAldeano(Nombres[Random.Range(0,21)]);
            else
                Informacion = Generador.GenerarZonmbie();

            print(Informacion);
        }
        Cursor.visible = false;
        character.CreateHero();
        
    }
    
    void Update()
    {
        character.Mover();
    }

}

public class Generador
{


    /// <summary>
    /// Se usa para generar un aldeano y retornar su nombre y edad en un string
    /// </summary>
    /// <param name="Nombre">
    /// Nombre del aldeano
    /// </param>
    /// <returns></returns>
    public string GenerarAldeano(string Nombre)
    {
        int Edad = Random.Range(15, 101);
        GameObject Aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Aldeano.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        return "Hola soy " + Nombre + " y tengo " + Edad + " Años";

    }



    /// <summary>
    /// Se usa para generar un zombie y retornar el color que tiene
    /// </summary>
    /// <returns></returns>
    public string GenerarZonmbie()
    {
        int color = Random.Range(0,4);
        string nombreColor = "";
        GameObject zombies = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer renderer = zombies.GetComponent<Renderer>();
        zombies.transform.position = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        if (color == 0)
        {
            renderer.material.color = UnityEngine.Color.cyan;
            nombreColor = "Cyan";
        }
        else if(color == 1)
        {
            nombreColor = "Verde";
            renderer.material.color = UnityEngine.Color.green;
        }
        else if (color == 2)
        {
            nombreColor = "Magenta";
            renderer.material.color = UnityEngine.Color.magenta;
        }

        return "Soy un zombie color " + nombreColor;
    }
}

public class Character
{

    GameObject hero;
    Transform heroTransform;


    /// <summary>
    /// Este metodo se encarga de crear el personaje principal
    /// </summary>
    public void CreateHero()
    {

        hero = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Renderer color = hero.GetComponent<Renderer>();
        heroTransform = hero.GetComponent<Transform>();
        color.material.color = Color.red;
        Camera camera = hero.AddComponent<Camera>();
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