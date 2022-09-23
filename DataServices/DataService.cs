using System;
using Microsoft.Data.SqlClient;
using Trouble_shootingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Trouble_shootingApp.DataServices
{

	public interface IDataService
	{
		
		JourneyListViewModel GetJourneys();

    }

	public class DataService:IDataService
	{
        string connectionString = "Data Source=localhost;Database=CarsInc;user=sa;password=password;MultipleActiveResultSets=True; TrustServerCertificate=True";


        public JourneyListViewModel GetJourneys()
		{

           
            JourneyListViewModel journeyListView = new JourneyListViewModel();
            journeyListView.JourneysList = new List<JourneysViewModel>{ };

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("EXECUTE dbo.GetJourneys", connection);
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        var dr = new JourneysViewModel
                        {
                            JourneyId = reader.GetInt32(0),
                            Vehicle = reader.GetString(1),
                            FullName = reader.GetString(2),
                            Age = reader.GetInt32(3),
                            Rating = reader.GetInt32(4),
                            City = reader.GetString(5),
                            Miles = reader.GetInt32(6),
                            TimeTaken = reader.GetInt32(7)
                        };


                        journeyListView.JourneysList.Add(dr);
                    }

                    connection.Close();

                    return journeyListView;

                }
            }
            catch
            {
               
            }
            return journeyListView;

        }




	}


}

