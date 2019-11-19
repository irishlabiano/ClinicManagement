using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace Azure.API
{
	public static class Dashboard
	{
		public class City
		{
			[FunctionName("CountCities")]
			public static async Task<int> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "getCities")]HttpRequestMessage req)
			{
				int count = 0;

				var conString = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

				using (SqlConnection conn = new SqlConnection(conString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Cities", conn))
					{
						var reader = await cmd.ExecuteReaderAsync();
						if (reader.Read())
						{
							count = int.Parse(reader[0].ToString());
						}
					}
					conn.Close();
				}

				return count;

			}
		}

		public class Specialization
		{
			[FunctionName("CountSpecializations")]
			public static async Task<int> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "getSpecializations")]HttpRequestMessage req)
			{
				int count = 0;

				var conString = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

				using (SqlConnection conn = new SqlConnection(conString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Specializations", conn))
					{
						var reader = await cmd.ExecuteReaderAsync();
						if (reader.Read())
						{
							count = int.Parse(reader[0].ToString());
						}
					}
					conn.Close();
				}

				return count;

			}
		}

		public class Attendance
		{
			[FunctionName("CountAttendances")]
			public static async Task<int> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "getAttendances")]HttpRequestMessage req)
			{
				int count = 0;

				var conString = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

				using (SqlConnection conn = new SqlConnection(conString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Attendances", conn))
					{
						var reader = await cmd.ExecuteReaderAsync();
						if (reader.Read())
						{
							count = int.Parse(reader[0].ToString());
						}
					}
					conn.Close();
				}

				return count;

			}
		}


	}
}
