using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[Serializable]
class QuestionComponent{
    public Question question;
    public string entry;
}

public class SendToGoogle : MonoBehaviour
{

    [SerializeField] private QuestionComponent [] questions;

    private string _playerID;
   
    //This component will only work if its Send() method is being called somewhere.

    public bool reportFromEditor = true;
    [SerializeField] private string url =
        "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfymTbpCBjMWxPTDZT4uwY0KoEMizMN4FyLLA4TTNluFT0LpA/formResponse";
    
    //SINGLETON STUFF
    protected static SendToGoogle m_instance = null;
    public static SendToGoogle instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SendToGoogle>();
            }

            return m_instance;
        }
    }

    /// <summary>
    /// Gathers data and begins the coroutine which posts it to the Google Form.
    /// </summary>
    /// <param name="entry">The DialogueEntry is used to report the number of results associated with this input.</param>
    /// <param name="conversant">Conversant can be accessed using a current or recent ink path with the ExtractFromPath method.</param>
    public void Send()
    {
        //if (!reportFromEditor && Application.isEditor) return; 
        
        //collate data
        //var version = Application.version;
        //var playerID = PlayerID();
        //var timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);

        

        
        Debug.Log("send!!!");
        StartCoroutine(Post(
            //version,
            //playerID, 
            //timestamp, 
            ));
    
    }

    
    private IEnumerator Post(
        //string version, 
        //string playerID, 
        //string timestamp, 
        )
    {
        var form = new WWWForm();
        //form.AddField("entry.2026731822", version);
        //form.AddField("entry.489222163", playerID);
        //form.AddField("entry.477698655", timestamp);
        for(int i=0; i< questions.Length; i++){

            form.AddField(questions[i].entry, questions[i].question.ToStringAnswer());
        }

        //YOU'LL HAVE TO FIND YOUR OWN ENTRY NUMBERS HERE BY SEARCHING THE GOOGLE FORM'S SOURCE FOR "entry."

        var www = UnityWebRequest.Post(url, form);
        Debug.Log("post!!!");
        yield return www.SendWebRequest();
    }

    private string PlayerID()
    {
        //if an ID is already in memory, submit it
        if (_playerID != null) return _playerID;
        
        //attempt to load an ID from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerID"))
        {
            _playerID = PlayerPrefs.GetString("PlayerID");
            return _playerID;
        }

        //fallback
        //generate new id, save to playerprefs, store in memory, and return it
        var id = "p" + UnityEngine.Random.Range((int)1, (int)999999999);
        PlayerPrefs.SetString("PlayerID", id);
        _playerID = id;
        return _playerID;
    }

}