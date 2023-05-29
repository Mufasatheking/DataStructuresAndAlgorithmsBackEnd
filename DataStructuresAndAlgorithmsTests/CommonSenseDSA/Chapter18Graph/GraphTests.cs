namespace DataStructuresAndAlgorithmsTests.CommonSenseDSA.Chapter18Graph
{
    public class WeightedGraphVertex
    {
        public class City
        {
            public string Name { get; set; }
            public Dictionary<City, double> Routes { get; set; }

            public City(string name)
            {
                Name = name;
                Routes = new Dictionary<City, double>();
            }

            public void AddRoute(City city, double price)
            {
                Routes[city] = price;
            }
        }
        public int Value { get; set; }
        public Dictionary<WeightedGraphVertex, int> AdjacentVertices { get; set; }

        public WeightedGraphVertex(int value)
        {
            Value = value;
            AdjacentVertices = new Dictionary<WeightedGraphVertex, int>();
        }

        public void AddAdjacentVertex(WeightedGraphVertex vertex, int weight)
        {
            AdjacentVertices[vertex] = weight;
        }
        
        public List<string> DijkstraShortestPath(City startingCity, City finalDestination)
        {
            var cheapestPricesTable = new Dictionary<string, double>();
            var cheapestPreviousStopoverCityTable = new Dictionary<string, string>();
            var unvisitedCities = new List<City>();
            var visitedCities = new Dictionary<string, bool>();

            cheapestPricesTable[startingCity.Name] = 0;

            var currentCity = startingCity;

            while (currentCity != null)
            {
                visitedCities[currentCity.Name] = true;
                unvisitedCities.Remove(currentCity);

                foreach (var route in currentCity.Routes)
                {
                    var adjacentCity = route.Key;
                    var price = route.Value;

                    if (!visitedCities.ContainsKey(adjacentCity.Name))
                    {
                        unvisitedCities.Add(adjacentCity);
                    }

                    var priceThroughCurrentCity = cheapestPricesTable[currentCity.Name] + price;

                    if (!cheapestPricesTable.ContainsKey(adjacentCity.Name) ||
                        priceThroughCurrentCity < cheapestPricesTable[adjacentCity.Name])
                    {
                        cheapestPricesTable[adjacentCity.Name] = priceThroughCurrentCity;
                        cheapestPreviousStopoverCityTable[adjacentCity.Name] = currentCity.Name;
                    }
                }

                currentCity = unvisitedCities.OrderBy(city => cheapestPricesTable[city.Name]).FirstOrDefault();
            }

            var shortestPath = new List<string>();
            var currentCityName = finalDestination.Name;

            while (currentCityName != startingCity.Name)
            {
                shortestPath.Add(currentCityName);
                currentCityName = cheapestPreviousStopoverCityTable[currentCityName];
            }

            shortestPath.Add(startingCity.Name);

            shortestPath.Reverse();

            return shortestPath;
        }

    }

    public class Vertex
    {
        public int Value { get; set; }
        public List<Vertex> AdjacentVertices { get; set; }

        public Vertex(int value)
        {
            Value = value;
            AdjacentVertices = new List<Vertex>();
        }

        public void AddAdjacentVertex(Vertex vertex)
        {
            AdjacentVertices.Add(vertex);
        }
        public void DFSTraverse(Vertex vertex, Dictionary<int, bool> visitedVertices = null)
        {
            if (visitedVertices == null)
            {
                visitedVertices = new Dictionary<int, bool>();
            }

            // Mark vertex as visited by adding it to the dictionary:
            visitedVertices[vertex.Value] = true;

            // Print the vertex's value, so we can make sure our traversal really works:
            Console.WriteLine(vertex.Value);

            // Iterate through the current vertex's adjacent vertices:
            foreach (var adjacentVertex in vertex.AdjacentVertices)
            {
                // Ignore an adjacent vertex if we've already visited it:
                if (visitedVertices.ContainsKey(adjacentVertex.Value))
                {
                    continue;
                }

                // Recursively call this method on the adjacent vertex:
                DFSTraverse(adjacentVertex, visitedVertices);
            }
        }
        public Vertex DFS(Vertex vertex, int searchValue, Dictionary<int, bool> visitedVertices = null)
        {
            if (visitedVertices == null)
            {
                visitedVertices = new Dictionary<int, bool>();
            }

            // Return the original vertex if it happens to
            // be the one we're searching for:
            if (vertex.Value == searchValue)
            {
                return vertex;
            }

            visitedVertices[vertex.Value] = true;

            foreach (var adjacentVertex in vertex.AdjacentVertices)
            {
                if (visitedVertices.ContainsKey(adjacentVertex.Value))
                {
                    continue;
                }

                // If the adjacent vertex is the vertex we're searching for, just return that vertex:
                if (adjacentVertex.Value == searchValue)
                {
                    return adjacentVertex;
                }

                // Attempt to find the vertex we're searching for by recursively calling this method on the adjacent vertex:
                var vertexWereSearchingFor = DFS(adjacentVertex, searchValue, visitedVertices);

                // If we were able to find the correct vertex using the above recursion, return the correct vertex:
                if (vertexWereSearchingFor != null)
                {
                    return vertexWereSearchingFor;
                }
            }

            // If we haven't found the vertex we're searching for:
            return null;
        }

        public void BFSTraverse(Vertex startingVertex)
        {
            Queue<Vertex> queue = new Queue<Vertex>();

            Dictionary<int, bool> visitedVertices = new Dictionary<int, bool>();
            visitedVertices[startingVertex.Value] = true;
            queue.Enqueue(startingVertex);

            // While the queue is not empty:
            while (queue.Count > 0)
            {
                // Remove the first vertex off the queue and make it the current vertex:
                Vertex currentVertex = queue.Dequeue();

                // Print the current vertex's value:
                Console.WriteLine(currentVertex.Value);

                // Iterate over current vertex's adjacent vertices:
                foreach (Vertex adjacentVertex in currentVertex.AdjacentVertices)
                {
                    // If we have not yet visited the adjacent vertex:
                    if (!visitedVertices.ContainsKey(adjacentVertex.Value))
                    {
                        // Mark the adjacent vertex as visited:
                        visitedVertices[adjacentVertex.Value] = true;

                        // Add the adjacent vertex to the queue:
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }
        }
        /*
        public List<string> FindShortestPath(Vertex firstVertex, Vertex secondVertex, Dictionary<int, bool> visitedVertices = null)
        {
            if (visitedVertices == null)
            {
                visitedVertices = new Dictionary<string, bool>();
            }

            Queue<Vertex> queue = new Queue<Vertex>();

            Dictionary<string, string> previousVertexTable = new Dictionary<string, string>();

            visitedVertices[firstVertex.Value] = true;
            queue.Enqueue(firstVertex);

            while (queue.Count > 0)
            {
                Vertex currentVertex = queue.Dequeue();

                foreach (Vertex adjacentVertex in currentVertex.AdjacentVertices)
                {
                    if (!visitedVertices.ContainsKey(adjacentVertex.Value))
                    {
                        visitedVertices[adjacentVertex.Value] = true;
                        queue.Enqueue(adjacentVertex);

                        previousVertexTable[adjacentVertex.Value] = currentVertex.Value;
                    }
                }
            }

            List<string> shortestPath = new List<string>();
            string currentVertexValue = secondVertex.Value;

            while (currentVertexValue != firstVertex.Value)
            {
                shortestPath.Add(currentVertexValue);
                currentVertexValue = previousVertexTable[currentVertexValue];
            }

            shortestPath.Add(firstVertex.Value);
            shortestPath.Reverse();

            return shortestPath;
        }
        */

    }
    
    public class GraphTests
    {
        
    }
}