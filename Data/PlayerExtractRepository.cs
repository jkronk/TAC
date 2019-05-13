using System;
using Framework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data
{
    public class PlayerExtractRepository
    {
        public List<PlayerExtract> Get()
        {
            var titans = new List<PlayerExtract>();

            var sql = "SELECT * FROM ClubDB.dbo.PlayerExtract WHERE Season = 2019 AND CurrentClub = 'TEN' ORDER BY LastName, FirstName";

            using (var connection = new SqlConnection("Server=.;Database=ClubDB;Integrated Security=True;Trusted_Connection=yes;"))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var titan = new PlayerExtract();

                            titan.PlayerID = Convert.ToInt32(dataReader["PlayerID"]);
                            titan.LastName = dataReader["LastName"].ToString();
                            titan.FirstName = dataReader["FirstName"].ToString();
                            titan.FootballName = dataReader["FootballName"].ToString();
                            titan.College = dataReader["College"].ToString();
                            titan.Height = dataReader["Height"].ToString();
                            titan.Weight = Convert.ToInt32(dataReader["Weight"]);
                            titan.PositionAbbr = dataReader["PositionAbbr"].ToString();
                            
                            titans.Add(titan);
                        }
                    }
                }
            }

            return titans;
        }
    }
}