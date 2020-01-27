using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextUpdater : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private string[] arguments = new string[5];
    public AudioSource source;
    public AudioClip Argument1;
    public AudioClip Argument2;
    public AudioClip Argument3;
    public AudioClip Argument4;
    public AudioClip Argument5;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        source.GetComponent<AudioSource>();

        //arguments
        arguments[0] = "Attendance in classes is automatic: sign-in sheets or card scanners will no longer be necessary, saving students time";
        arguments[1] = "Personal security will be increased: in the event of a fire or serious event, campus security will know where help is needed";
        arguments[2] = "The University can measure room occupancy, improving space allocation, efficiency and saving money, which can be reinvested into University services.";
        arguments[3] = "The beacons and app can be used as navigation waypoints to guide students to unfamiliar new rooms";
        arguments[4] = "Friends can let each other know where they are on campus";

        //text
        keys.Add("Argument1", KeyCode.A);
        keys.Add("Argument2", KeyCode.S);
        keys.Add("Argument3", KeyCode.D);
        keys.Add("Argument4", KeyCode.F);
        keys.Add("Argument5", KeyCode.G);

        //scene
        keys.Add("Character", KeyCode.Z);
        keys.Add("Text", KeyCode.X);
        keys.Add("Voice", KeyCode.C);

        //random
        keys.Add("random", KeyCode.Q);
    }

    // Update is called once per frame
    void Update()
    {
        //random arguments
        if (Input.GetKeyDown(keys["random"]))
        {
            StartCoroutine(random());
        }

        //update scene
        if (Input.GetKeyDown(keys["Character"]))
        {
            SceneManager.LoadScene("Living Room - Character");
        }
        if (Input.GetKeyDown(keys["Text"]))
        {
            SceneManager.LoadScene("Living Room - Text");
        }
        if (Input.GetKeyDown(keys["Voice"]))
        {
            SceneManager.LoadScene("Living Room - Voice");
        }

        //phrases set to keybinds
        if (Input.GetKeyDown(keys["Argument1"]))
        {
            textMesh.text = "Attendance in classes is automatic: sign-in sheets or card scanners will no longer be necessary, saving students time";
            source.clip = Argument1;
            source.Play();
        }
        if (Input.GetKeyDown(keys["Argument2"]))
        {
            textMesh.text = "Personal security will be increased: in the event of a fire or serious event, campus security will know where help is needed";
            source.clip = Argument2;
            source.Play();
        }
        if (Input.GetKeyDown(keys["Argument3"]))
        {
            textMesh.text = "The University can measure room occupancy, improving space allocation, efficiency and saving money, which can be reinvested into University services.";
            source.clip = Argument3;
            source.Play();
        }
        if (Input.GetKeyDown(keys["Argument4"]))
        {
            textMesh.text = "The beacons and app can be used as navigation waypoints to guide students to unfamiliar new rooms";
            source.clip = Argument4;
            source.Play();
        }
        if (Input.GetKeyDown(keys["Argument5"]))
        {
            textMesh.text = "Friends can let each other know where they are on campus";
            source.clip = Argument5;
            source.Play();
        }
    }

    IEnumerator random()
    {
        List<int> numberList = new List<int>();
        //random arguments
        for (int i = 0; i < 5; i++)
        {
            int randomNumber = Random.Range(0, arguments.Length);
            for (int e = 0; e < 5; e++)
            {
                bool alreadyExist = numberList.Contains(randomNumber);
                if (alreadyExist == true)
                {
                    randomNumber = Random.Range(0, arguments.Length);
                }
            }
            numberList.Add(randomNumber);
            textMesh.text = arguments[randomNumber];
            if (arguments[randomNumber] == arguments[0])
            {
                source.clip = Argument1;
                source.Play();
            }
            if (arguments[randomNumber] == arguments[1])
            {
                source.clip = Argument2;
                source.Play();
            }
            if (arguments[randomNumber] == arguments[2])
            {
                source.clip = Argument3;
                source.Play();
            }
            if (arguments[randomNumber] == arguments[3])
            {
                source.clip = Argument4;
                source.Play();
            }
            if (arguments[randomNumber] == arguments[4])
            {
                source.clip = Argument5;
                source.Play();
            }
            //Wait for 15 seconds
            yield return new WaitForSeconds(15);
        }
    }
}
