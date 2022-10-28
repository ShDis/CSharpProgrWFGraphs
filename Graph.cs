using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgrWFGraphs
{
    public class Graph
    {
        private Random rnd;
        private double connectionChance;
        private int verticlesCount;
        public int VerticlesCount
        {
            get { return verticlesCount; }
        }

        private List<PointInt> connectionsList; //start point number -> end point number
        public List<PointInt> ConnectionsList
        {
            get { return connectionsList; }
        }

        private List<PointDouble> verticlesLocationsList; //actual points locations
        public List<PointDouble> VerticlesLocationsList
        {
            get { return verticlesLocationsList; }
        }
        //private byte[][] incidentMatrix;

        public Graph(double connectionChance)
        {
            rnd = new Random();
            this.connectionChance = connectionChance;
            verticlesCount = rnd.Next() % 5 + 5; //from 3 to 9
            //int connectionsCount = random.Next() % CountMaxAvailableConnections(verticlesCount) + 1;
            //incidentMatrix = new incidentMatrix[verticlesCount][verticlesCount];
            GeneratePointsLocations();
            GenerateConnections();
        }

        private void GeneratePointsLocations()  
        {
            //set points locations
            verticlesLocationsList = new List<PointDouble>();

            for (int i = 1; i < verticlesCount + 1; i++)
            {
                verticlesLocationsList.Add(
                    new PointDouble(
                        Math.Cos((i - 1) * (360.0 / (double)verticlesCount) * Math.PI / 180.0), 
                        Math.Sin((i - 1) * (360.0 / (double)verticlesCount) * Math.PI / 180.0)
                        )
                    );
            }
        }

        private void GenerateConnections()
        {
            //set points random connections
            connectionsList = new List<PointInt>();

            for (int i = 1; i < verticlesCount; i++) //for every point not including last
            {
                for (int j = i + 1; j < verticlesCount + 1; j++) //for every pointNum > current
                {
                    if (CheckIsConnected(connectionChance)) //to
                    {
                        connectionsList.Add(new PointInt(i - 1, j - 1, rnd.Next(1,9)));
                    }
                    if (CheckIsConnected(connectionChance)) //from
                    {
                        connectionsList.Add(new PointInt(j - 1, i - 1, rnd.Next(1, 9)));
                    }
                }
            }
        }

        private bool CheckIsConnected(double chancePercent)
        {
            if (rnd.NextDouble() * 100.0 > chancePercent)
                return false;
            return true;
        }
    }
}
