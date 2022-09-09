using System;
using System.Text;

namespace BO4B
{
	internal class Cell
	{
		public int[] results;
		public bool[] isBest;

		public Cell()
		{
			results = new int[4];
			isBest = new bool[4];
		}
		public override string ToString()
		{
			return $"({results[0]},{results[1]},{results[2]},{results[3]})";
		}
	}

	internal class Combination
	{
		public int[] values;
		public Combination(int x, int y, int z)
		{
			values = new int[] { x, y, z };
		}
		public override string ToString()
		{
			return $"({values[0]},{values[1]},{values[2]})";
		}

	}

	internal class Program
	{
		private static void Main(string[] args)
		{
			var combinations=new Combination[]
			{






new Combination(0,0,10),
new Combination(0,1,9),
new Combination(0,2,8),
new Combination(0,3,7),
new Combination(0,4,6),
new Combination(0,5,5),
new Combination(0,6,4),
new Combination(0,7,3),
new Combination(0,8,2),
new Combination(0,9,1),
new Combination(0,10,0),
new Combination(1,0,9),
new Combination(1,1,8),
new Combination(1,2,7),
new Combination(1,3,6),
new Combination(1,4,5),
new Combination(1,5,4),
new Combination(1,6,3),
new Combination(1,7,2),
new Combination(1,8,1),
new Combination(1,9,0),
new Combination(2,0,8),
new Combination(2,1,7),
new Combination(2,2,6),
new Combination(2,3,5),
new Combination(2,4,4),
new Combination(2,5,3),
new Combination(2,6,2),
new Combination(2,7,1),
new Combination(2,8,0),
new Combination(3,0,7),
new Combination(3,1,6),
new Combination(3,2,5),
new Combination(3,3,4),
new Combination(3,4,3),
new Combination(3,5,2),
new Combination(3,6,1),
new Combination(3,7,0),
new Combination(4,0,6),
new Combination(4,1,5),
new Combination(4,2,4),
new Combination(4,3,3),
new Combination(4,4,2),
new Combination(4,5,1),
new Combination(4,6,0),
new Combination(5,0,5),
new Combination(5,1,4),
new Combination(5,2,3),
new Combination(5,3,2),
new Combination(5,4,1),
new Combination(5,5,0),
new Combination(6,0,4),
new Combination(6,1,3),
new Combination(6,2,2),
new Combination(6,3,1),
new Combination(6,4,0),
new Combination(7,0,3),
new Combination(7,1,2),
new Combination(7,2,1),
new Combination(7,3,0),
new Combination(8,0,2),
new Combination(8,1,1),
new Combination(8,2,0),
new Combination(9,0,1),
new Combination(9,1,0),
new Combination(10,0,0)
};
			var array = new Cell[66, 66, 66, 66];
			Console.WriteLine(array.Length);
			var table=new int[4,3];
			var companyChoises=new Combination[4];
			var coefficient=new int[4,3]{
			{1,4,1},
			{2,2,1},
			{1,2,2},
			{2,1,2},
			};
			int tempSum;
			Cell tempCell;
			StringBuilder stringBuilder=new StringBuilder();
			for(int i1 = 0; i1 < 66; i1++)
				for(int i2 = 0; i2 < 66; i2++)
					for(int i3 = 0; i3 < 66; i3++)
						for(int i4 = 0; i4 < 66; i4++)
						{
							tempCell = new Cell();
							array[i1, i2, i3, i4] = tempCell;
							companyChoises[0] = combinations[i1];
							companyChoises[1] = combinations[i2];
							companyChoises[2] = combinations[i3];
							companyChoises[3] = combinations[i4];
							for(int j1 = 0; j1 < 4; j1++)
								for(int j2 = 0; j2 < 3; j2++)
								{
									table[j1, j2] = companyChoises[j1].values[j2];
								}
							for(int j1 = 0; j1 < 4; j1++)
								for(int j2 = 0; j2 < 3; j2++)
								{
									table[j1, j2] *= coefficient[j1, j2];
								}

							for(int j1 = 0; j1 < 4; j1++)
							{
								tempSum = 0;
								for(int j2 = 0; j2 < 3; j2++)
									for(int j3 = 0; j3 < 4; j3++)
									{
										if(table[j3, j2] < table[j1, j2])
											tempSum++;
									}
								tempCell.results[j1] = tempSum;
							}
							stringBuilder.Append(tempCell);
						}
			var str=stringBuilder.ToString();
			int tempMax;
			for(int i2 = 0; i2 < 66; i2++)
				for(int i3 = 0; i3 < 66; i3++)
					for(int i4 = 0; i4 < 66; i4++)
					{
						tempMax = 0;
						for(int i1 = 0; i1 < 66; i1++)
						{
							if(array[i1, i2, i3, i4].results[0] > tempMax)
								tempMax = array[i1, i2, i3, i4].results[0];
						}
						for(int i1 = 0; i1 < 66; i1++)
						{
							if(array[i1, i2, i3, i4].results[0] == tempMax)
								array[i1, i2, i3, i4].isBest[0] = true;

						}
					}
			for(int i1 = 0; i1 < 66; i1++)
				for(int i3 = 0; i3 < 66; i3++)
					for(int i4 = 0; i4 < 66; i4++)
					{
						tempMax = 0;
						for(int i2 = 0; i2 < 66; i2++)
						{
							if(array[i1, i2, i3, i4].results[1] > tempMax)
								tempMax = array[i1, i2, i3, i4].results[1];
						}
						for(int i2 = 0; i2 < 66; i2++)
						{
							if(array[i1, i2, i3, i4].results[1] == tempMax)
								array[i1, i2, i3, i4].isBest[1] = true;

						}

					}
			for(int i1 = 0; i1 < 66; i1++)
				for(int i2 = 0; i2 < 66; i2++)
					for(int i4 = 0; i4 < 66; i4++)
					{
						tempMax = 0;
						for(int i3 = 0; i3 < 66; i3++)
						{
							if(array[i1, i2, i3, i4].results[2] > tempMax)
								tempMax = array[i1, i2, i3, i4].results[2];
						}
						for(int i3 = 0; i3 < 66; i3++)
						{
							if(array[i1, i2, i3, i4].results[2] == tempMax)
								array[i1, i2, i3, i4].isBest[2] = true;

						}
					}
			for(int i1 = 0; i1 < 66; i1++)
				for(int i2 = 0; i2 < 66; i2++)
					for(int i3 = 0; i3 < 66; i3++)
					{
						tempMax = 0;
						for(int i4 = 0; i4 < 66; i4++)
						{
							if(array[i1, i2, i3, i4].results[3] > tempMax)
								tempMax = array[i1, i2, i3, i4].results[3];
						}
						for(int i4 = 0; i4 < 66; i4++)
						{
							if(array[i1, i2, i3, i4].results[3] == tempMax)
								array[i1, i2, i3, i4].isBest[3] = true;

						}
					}
			tempSum = 0;
			for(int i1 = 0; i1 < 66; i1++)
				for(int i2 = 0; i2 < 66; i2++)
					for(int i3 = 0; i3 < 66; i3++)
						for(int i4 = 0; i4 < 66; i4++)
						{
							tempCell = array[i1, i2, i3, i4];
							if(tempCell.isBest[0] && tempCell.isBest[1] && tempCell.isBest[2] && tempCell.isBest[3])
							{
								tempSum++;
								Console.WriteLine($"Pure NE in {combinations[i1]},{combinations[i2]},{combinations[i3]},{combinations[i4]} with result {tempCell}");
							}
						}

			Console.WriteLine(tempSum);
		}
	}
}
