using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour {

    private string connection;
    private string p = "ARShooter.db";
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
    public Text test;

	// Use this for initialization
	void Start () {
        OpenDB();
        CreateTable();
        CloseDB();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDB()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/" + p;
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    }

    public void CloseDB()
    {
        if (reader != null)
            reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }

    bool CreateTable()
    { // Create a table, name, column array, column type array
        string query =  "CREATE  TABLE  IF NOT EXISTS \"HighScores\" (\"PlayerID\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , \"Name\" TEXT NOT NULL , \"Date_Time\" DATETIME NOT NULL  DEFAULT CURRENT_DATE, \"Shots\" INTEGER NOT NULL , \"Kills\" INTEGER NOT NULL , \"Level\" INTEGER NOT NULL , \"Score\" INTEGER NOT NULL )";
        try
        {
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);
            return false;
        }
        return true;
    }

    public void InsertScore(string name, int score, int ShotsFired, int Kills, int Level)
    {
        OpenDB();
        using (dbcmd = dbcon.CreateCommand())
        {
            string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score,Shots,Kills,Level) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", name, score, ShotsFired, Kills, Level);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            CloseDB();
        }
    }

    public List<ScoreCard> GetScores()
    {
        List<ScoreCard> scores = new List<ScoreCard>();
        try
        {
            OpenDB();
            using (dbcmd = dbcon.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores ORDER BY Score DESC LIMIT 9";
                dbcmd.CommandText = sqlQuery;

                using (reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ScoreCard temp = new ScoreCard(reader.GetString(1), reader.GetInt32(6));
                        scores.Add(temp);
                    }
                    CloseDB();
                }
            }
        }
        catch (Exception e)
        {
            test.text = e.StackTrace;
        }
        return scores;
    }
}

public class ScoreCard
{
    public string name;
    public int score;
    public ScoreCard(string _name, int _score)
    {
        name = _name;
        score = _score;
    }
}
