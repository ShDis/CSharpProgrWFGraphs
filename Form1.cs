using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CSharpProgrWFGraphs
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        private double ortho2DMatrixSize = 1.0;

        public void ResetOrtho2DMatrix()
        {
            Glu.gluOrtho2D(-ortho2DMatrixSize, ortho2DMatrixSize, -ortho2DMatrixSize, ortho2DMatrixSize); //R2 size
        }
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
        }

        private Graph g;
        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit(); //graphics library utility
            Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DOUBLE);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            ResetOrtho2DMatrix();
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity(); //единичная матрица

            CreateGraph();
            Draw();
        }


        private void DrawVertexes() //visualize points
        {
            Gl.glColor3f(1.0f, 0.6f, 0.0f);//orange
            //smooth
            Gl.glPointSize(10.0f);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);
            //draw 
            Gl.glPointSize(10.0f);
            foreach (PointDouble p in g.VerticlesLocationsList)
            {
                Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2d(p.x, p.y);
                Gl.glEnd();
            }
        }

        private void DrawConnections()
        {
            Gl.glLineWidth(2.0f);
            foreach (PointInt p in g.ConnectionsList)
            {
                if (p.underlined == true)
                    Gl.glColor3f(1.0f, 0.0f, 0.0f);
                else
                    Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glLineWidth(2.0f);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(g.VerticlesLocationsList[p.from].x, g.VerticlesLocationsList[p.from].y);
                Gl.glVertex2d(g.VerticlesLocationsList[p.to].x, g.VerticlesLocationsList[p.to].y);
                Gl.glEnd();
            }
        }

        private void DrawArrows()
        {
            double arrowLength = 0.039;
            double arrowAngle = 15.0 * Math.PI / 180.0;

            //debug
            //label1.Text = "";
            //label2.Text = "";

            foreach (PointInt p in g.ConnectionsList)
            {
                double angle;
                if (g.VerticlesLocationsList[p.to].y - g.VerticlesLocationsList[p.from].y >= 0)
                {
                    angle = Math.Acos((g.VerticlesLocationsList[p.to].x - g.VerticlesLocationsList[p.from].x) /
                       Math.Sqrt(
                           Math.Pow(g.VerticlesLocationsList[p.to].x - g.VerticlesLocationsList[p.from].x, 2) +
                           Math.Pow(g.VerticlesLocationsList[p.to].y - g.VerticlesLocationsList[p.from].y, 2))
                       );
                }
                else
                {
                    angle = 2.0 * Math.PI - Math.Acos((g.VerticlesLocationsList[p.to].x - g.VerticlesLocationsList[p.from].x) /
                       Math.Sqrt(
                           Math.Pow(g.VerticlesLocationsList[p.to].x - g.VerticlesLocationsList[p.from].x, 2) +
                           Math.Pow(g.VerticlesLocationsList[p.to].y - g.VerticlesLocationsList[p.from].y, 2))
                       );
                }

                Gl.glColor3f(0.0f, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_POLYGON);
                Gl.glVertex2d(g.VerticlesLocationsList[p.to].x, g.VerticlesLocationsList[p.to].y); //first point

                //debug
                //label1.Text = label1.Text + " " + angle;

                Gl.glVertex2d(
                    g.VerticlesLocationsList[p.to].x -
                    Math.Cos((angle - arrowAngle)) * arrowLength
                    ,
                    g.VerticlesLocationsList[p.to].y -
                    Math.Sin((angle - arrowAngle)) * arrowLength
                    ); //second point
                Gl.glVertex2d(
                    g.VerticlesLocationsList[p.to].x -
                    Math.Cos((angle + arrowAngle)) * arrowLength
                    ,
                    g.VerticlesLocationsList[p.to].y -
                    Math.Sin((angle + arrowAngle)) * arrowLength
                    ); //third point
                Gl.glVertex2d(g.VerticlesLocationsList[p.to].x, g.VerticlesLocationsList[p.to].y); //fourth point
                Gl.glEnd();

                //black line
                Gl.glColor3f(0.0f, 1.0f, 1.0f);
                Gl.glLineWidth(0.05f);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(g.VerticlesLocationsList[p.to].x, g.VerticlesLocationsList[p.to].y); //first point
                Gl.glVertex2d(
                    g.VerticlesLocationsList[p.to].x -
                    Math.Cos((angle - arrowAngle)) * arrowLength
                    ,
                    g.VerticlesLocationsList[p.to].y -
                    Math.Sin((angle - arrowAngle)) * arrowLength
                    ); //second point
                Gl.glVertex2d(
                    g.VerticlesLocationsList[p.to].x -
                    Math.Cos((angle + arrowAngle)) * arrowLength
                    ,
                    g.VerticlesLocationsList[p.to].y -
                    Math.Sin((angle + arrowAngle)) * arrowLength
                    ); //third point
                Gl.glVertex2d(g.VerticlesLocationsList[p.to].x, g.VerticlesLocationsList[p.to].y); //fourth point
                Gl.glEnd();
            }
        }

        private void DrawDistancesText()
        {
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            double divideParts = 7.0;
            for (int i = 0; i < g.ConnectionsList.Count; i++) //попытка в читабельный код)0))
            {
                double from_x = g.VerticlesLocationsList[g.ConnectionsList[i].from].x;
                double from_y = g.VerticlesLocationsList[g.ConnectionsList[i].from].y;
                double to_x = g.VerticlesLocationsList[g.ConnectionsList[i].to].x;
                double to_y = g.VerticlesLocationsList[g.ConnectionsList[i].to].y;
                float location_x = (float)(to_x - (to_x - from_x) / divideParts);
                float location_y = (float)(to_y - (to_y - from_y) / divideParts);
                String distance = g.ConnectionsList[i].distance.ToString();
                RenderStringHelvetica(location_x, location_y, distance);
            }
        }

        private void DrawVertexText()
        {
            Gl.glColor3f(1.0f, 0.6f, 0.0f);//orange
            for (int i = 0; i < g.VerticlesLocationsList.Count; i++)
            {
                RenderStringTimesRoman((float)g.VerticlesLocationsList[i].x, (float)g.VerticlesLocationsList[i].y, i.ToString());
            }
        }

        private void RenderStringTimesRoman(float x, float y, string s)
        {
            Gl.glRasterPos2f(x + 0.02f, y + 0.02f);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, s);
        }

        private void RenderStringHelvetica(float x, float y, string s)
        {
            Gl.glRasterPos2f(x + 0.02f, y + 0.02f);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_HELVETICA_12, s);
        }

        private void ShowAdjacencyMatrix()
        {
            int[,] adjacencyMatrix = GetAdjacencyMatrix();

            String text = "";
            for (int i = 0; i < g.VerticlesCount; i++)
            {
                String line = "";
                for (int j = 0; j < g.VerticlesCount; j++)
                {
                    //if (adjacencyMatrix[i, j] != -1)
                    line += " " + adjacencyMatrix[i, j].ToString();
                    //line = line + " " + "-";
                }
                text += line;
                if (i != g.VerticlesCount - 1)
                    text += "\n";
            }
            richTextBoxAjacencyMatrix.Text = text;
        }

        private int[,] GetAdjacencyMatrix()
        {
            int[,] adjacencyMatrix = new int[g.VerticlesCount, g.VerticlesCount];

            for (int i = 0; i < g.VerticlesCount; i++)
            {
                for (int j = 0; j < g.VerticlesCount; j++)
                {
                    adjacencyMatrix[i, j] = 0;
                }
            }

            for (int i = 0; i < g.ConnectionsList.Count; i++)
            {
                adjacencyMatrix[g.ConnectionsList[i].from, g.ConnectionsList[i].to] = g.ConnectionsList[i].distance;
            }

            return adjacencyMatrix;
        }

        private int[] BellmanFord(int src)
        {
            /*На этом шаге инициализируются расстояния от исходной вершины до всех остальных вершин, 
             * как бесконечные, а расстояние до самого src принимается равным 0.
             * Создается массив dist[] размера | V | со всеми значениями равными бесконечности, 
             * за исключением элемента dist[src], где src — исходная вершина.*/
            int[] dist = new int[g.VerticlesCount];
            for (int i = 0; i < g.VerticlesCount; i++)
                dist[i] = int.MaxValue;
            dist[src] = 0;

            /*Вторым шагом вычисляются самые короткие расстояния. Следующие шаги нужно 
            выполнять | V | -1 раз, где | V | — число вершин в данном графе.
            Произведите следующее действие для каждого ребра u - v:
            Если dist[v] > dist[u] + вес ребра uv, то обновите dist[v] 
            dist[v] = dist[u] + вес ребра uv*/
            for (int step = 0; step < g.VerticlesCount - 1; step++)
            {
                for (int e = 0; e < g.ConnectionsList.Count; e++)
                {
                    if (dist[g.ConnectionsList[e].to] > dist[g.ConnectionsList[e].from] + g.ConnectionsList[e].distance && dist[g.ConnectionsList[e].from] != int.MaxValue)
                    {
                        dist[g.ConnectionsList[e].to] = dist[g.ConnectionsList[e].from] + g.ConnectionsList[e].distance;
                    }
                }
            }

            return dist;
        }

        private void SetTheShortestPathUnderlined(int vertexFrom, int vertexTo, int distance)
        {
            labelVertexFrom.Text = "From v" + vertexFrom.ToString() + " to v" + vertexTo + ": " + distance.ToString();
            for (int connectionId = 0; connectionId < g.ConnectionsList.Count; connectionId++)
                g.ConnectionsList[connectionId].underlined = false;
            FindNext(new List<int>(),vertexFrom, 0, distance, vertexTo);
        }

        private bool FindNext(List<int> visited, int lastVertex, int dist, int requiredDist, int destination)
        {
            visited.Add(lastVertex);
            if (dist == requiredDist && visited.Last() == destination)
            {
                for (int visitedVertexId = 0; visitedVertexId < visited.Count - 1; visitedVertexId++)
                {
                    for (int connectionId = 0; connectionId < g.ConnectionsList.Count; connectionId++)
                    {
                        if (g.ConnectionsList[connectionId].from == visited[visitedVertexId] && g.ConnectionsList[connectionId].to == visited[visitedVertexId+1])
                        {
                            g.ConnectionsList[connectionId].underlined = true;
                        }
                    }
                }
                return true;
            }
            foreach(PointInt connection in g.ConnectionsList)
            {
                if (visited.Last() == connection.from && !visited.Contains(connection.to))
                {

                    FindNext(visited.ToList(), connection.to, dist + connection.distance, requiredDist,destination);
                }
            }
            return false;
        }

        private int lastSize = 0;
        private int lastVertexTo = 1;
        private void timerTrackBars_Tick(object sender, EventArgs e)
        {
            if (lastSize != trackBarScale.Value || lastVertexTo != trackBarVertexTo.Value)
            {
                Draw();
                lastSize = trackBarScale.Value;
                lastVertexTo = trackBarVertexTo.Value;
            }
        }

        void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glPushMatrix();
            Gl.glScaled(1.0 - 0.08 * trackBarScale.Value, 1.0 - 0.08 * trackBarScale.Value, 1.0 - 0.08 * trackBarScale.Value);

            SetTheShortestPathUnderlined(0, trackBarVertexTo.Value, BellmanFord(0)[trackBarVertexTo.Value]);

            DrawVertexes();
            DrawConnections();
            DrawArrows();
            DrawVertexText();
            DrawDistancesText();

            ShowAdjacencyMatrix();

            Gl.glPopMatrix();

            simpleOpenGlControl1.Invalidate();
        }

        private void buttonGenGraph_Click(object sender, EventArgs e) //regen Graph
        {
            CreateGraph();
            Draw();
        }

        private void CreateGraph()
        {
            timerTrackBars.Enabled = false;
            g = new Graph((double)trackBarConnectionChance.Value);
            trackBarVertexTo.Maximum = g.VerticlesCount - 1;
            timerTrackBars.Enabled = true;
        }
    }
}
