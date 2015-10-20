using UnityEngine;
using System;
using Npgsql;
using System.Collections;

public class DatabaseHandler {

	public static NpgsqlConnection connection;

	// Use this for initialization
	void Start () {
	}

	public static void connectToDatabase() {
		string connectionString = "Server=ec2-54-204-15-48.compute-1.amazonaws.com;Port=5432;User Id=puyqrebdtbgmji;Password=umIc9bRAzM7M33WHdXF85leE7p;Database=dcoe26165uq21b;SSL=True";
		connection = new NpgsqlConnection(connectionString);
		try {
			connection.Open();
		} catch (Exception e) {
			Debug.LogError(e.Message.ToString());
			connection.Close();
			Debug.LogError("Unable to connect to database");
		}
	}

	public static void insertPlayer(string name, DateTime birthday) {
		connectToDatabase();
		NpgsqlCommand command = new NpgsqlCommand ("insert into players(name,birthday,created_at,updated_at) values(:name, :birthday, :created, :updated)", connection);

		command.Parameters.Add (new NpgsqlParameter ("name", NpgsqlTypes.NpgsqlDbType.Varchar));
		command.Parameters.Add (new NpgsqlParameter ("birthday", NpgsqlTypes.NpgsqlDbType.Date));
		command.Parameters.Add (new NpgsqlParameter ("created", NpgsqlTypes.NpgsqlDbType.Timestamp));
		command.Parameters.Add (new NpgsqlParameter ("updated", NpgsqlTypes.NpgsqlDbType.Timestamp));

		command.Parameters [0].Value = name;
		command.Parameters [1].Value = birthday;
		command.Parameters [2].Value = DateTime.Now;
		command.Parameters [3].Value = DateTime.Now;

		command.ExecuteNonQuery ();
		closeConnection ();
	}

	public static void insertGame(string gameType, float playTime, float movingTime, float raceTime, float idleTime,
	                              int collisions, int itemsCollected, int powerupsCollected, string difficulty, int won, int playerId) {
		connectToDatabase ();
		NpgsqlCommand command = new NpgsqlCommand ("insert into games(game_type, play_time, moving_time, race_time, idle_time," +
			" collisions, items_collected, powerups_collected, difficulty, won, created_at, updated_at, player_id)" +
			" values(:gameType, :playTime, :movingTime, :raceTime, :idleTime, :collisions, :itemsCollected," +
			" :powerupsCollected, :difficulty, :won, :created, :updated, :pid)", connection);

		command.Parameters.Add (new NpgsqlParameter ("gameType", NpgsqlTypes.NpgsqlDbType.Varchar));
		command.Parameters.Add (new NpgsqlParameter ("playTime", NpgsqlTypes.NpgsqlDbType.Real));
		command.Parameters.Add (new NpgsqlParameter ("movingTime", NpgsqlTypes.NpgsqlDbType.Real));
		command.Parameters.Add (new NpgsqlParameter ("raceTime", NpgsqlTypes.NpgsqlDbType.Real));
		command.Parameters.Add (new NpgsqlParameter ("idleTime", NpgsqlTypes.NpgsqlDbType.Real));
		command.Parameters.Add (new NpgsqlParameter ("collisions", NpgsqlTypes.NpgsqlDbType.Integer));
		command.Parameters.Add (new NpgsqlParameter ("itemsCollected", NpgsqlTypes.NpgsqlDbType.Integer));
		command.Parameters.Add (new NpgsqlParameter ("powerupsCollected", NpgsqlTypes.NpgsqlDbType.Integer));
		command.Parameters.Add (new NpgsqlParameter ("difficulty", NpgsqlTypes.NpgsqlDbType.Varchar));
		command.Parameters.Add (new NpgsqlParameter ("won", NpgsqlTypes.NpgsqlDbType.Integer));
		command.Parameters.Add (new NpgsqlParameter ("created", NpgsqlTypes.NpgsqlDbType.Timestamp));
		command.Parameters.Add (new NpgsqlParameter ("updated", NpgsqlTypes.NpgsqlDbType.Timestamp));
		command.Parameters.Add (new NpgsqlParameter ("pid", NpgsqlTypes.NpgsqlDbType.Integer));

		command.Parameters [0].Value = gameType;
		command.Parameters [1].Value = playTime;
		command.Parameters [2].Value = movingTime;
		command.Parameters [3].Value = raceTime;
		command.Parameters [4].Value = idleTime;
		command.Parameters [5].Value = collisions;
		command.Parameters [6].Value = itemsCollected;
		command.Parameters [7].Value = powerupsCollected;
		command.Parameters [8].Value = difficulty;
		command.Parameters [9].Value = won;
		command.Parameters [10].Value = DateTime.Now;
		command.Parameters [11].Value = DateTime.Now;
		command.Parameters [12].Value = playerId;

		command.ExecuteNonQuery ();
		closeConnection ();
	}

	public static void closeConnection() {
		if (connection != null) {
			connection.Close();
			connection = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
