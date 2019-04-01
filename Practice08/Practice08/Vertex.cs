namespace Practice08
{
    class Vertex
    {
        public Color color;
        public char key;
        public int distance;
        public Vertex predecessor;

        public Vertex(char key)
        {
            this.key = key;
        }

        public override string ToString()
        {
            return key.ToString();
        }
    }
}
