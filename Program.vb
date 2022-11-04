Imports System

Module Program
	Function MinimumDistance(distance As Integer(), shortestPathTreeSet As Boolean(), verticesCount As Integer) As Integer
		Dim min As Integer = Integer.MaxValue
		Dim minIndex As Integer = 0

		For v As Integer = 0 To verticesCount - 1
			If shortestPathTreeSet(v) = False AndAlso distance(v) <= min Then
				min = distance(v)
				minIndex = v
			End If
		Next

		Return minIndex
	End Function

	Sub Print(distance As Integer(), verticesCount As Integer)
		Console.WriteLine("Vertex    Distance from source")

		For i As Integer = 0 To verticesCount - 1
			Console.WriteLine("{0}" & vbTab & "  {1}", i, distance(i))
		Next
	End Sub

	Sub Dijkstra(graph As Integer(,), source As Integer, verticesCount As Integer)
		Dim distance As Integer() = New Integer(verticesCount - 1) {}
		Dim shortestPathTreeSet As Boolean() = New Boolean(verticesCount - 1) {}

		For i As Integer = 0 To verticesCount - 1
			distance(i) = Integer.MaxValue
			shortestPathTreeSet(i) = False
		Next

		distance(source) = 0

		For count As Integer = 0 To verticesCount - 2
			Dim u As Integer = MinimumDistance(distance, shortestPathTreeSet, verticesCount)
			shortestPathTreeSet(u) = True

			For v As Integer = 0 To verticesCount - 1
				If Not shortestPathTreeSet(v) AndAlso Convert.ToBoolean(graph(u, v)) AndAlso distance(u) <> Integer.MaxValue AndAlso distance(u) + graph(u, v) < distance(v) Then
					distance(v) = distance(u) + graph(u, v)
				End If
			Next
		Next

		Print(distance, verticesCount)
	End Sub

	Sub Main()
		Dim graph As Integer(,) = {
	{0, 4, 0, 0, 0, 0, 0, 8, 0},
	{4, 0, 8, 0, 0, 0, 0, 11, 0},
	{0, 8, 0, 7, 0, 4, 0, 0, 2},
	{0, 0, 7, 0, 9, 14, 0, 0, 0},
	{0, 0, 0, 9, 0, 10, 0, 0, 0},
	{0, 0, 4, 0, 10, 0, 2, 0, 0},
	{0, 0, 0, 14, 0, 2, 0, 1, 6},
	{8, 11, 0, 0, 0, 0, 1, 0, 7},
	{0, 0, 2, 0, 0, 0, 6, 7, 0}
}

		Dijkstra(graph, 0, 9)
	End Sub
End Module
