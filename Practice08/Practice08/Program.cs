namespace Practice08
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new ListGraph('1', '2', '3', '4', '5', '6');
            graph.AddEdge('1', '2');
            graph.AddEdge('1', '4');
            graph.AddEdge('2', '5');
            graph.AddEdge('3', '5');
            graph.AddEdge('3', '6');
            graph.AddEdge('4', '2');
            graph.AddEdge('5', '4');
            graph.AddEdge('6', '6');

            graph.BreadthFirstSearch('3');
            graph.PrintPath('3', '2');
            graph.PrintPath('3', '1');
        }
    }
}
