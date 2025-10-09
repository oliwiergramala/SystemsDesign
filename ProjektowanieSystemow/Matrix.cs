namespace ProjektowanieSystemow;
public class Matrix
{
    //Variables of Matrix
    public List<List<float>> _matrix;
    public string _name;
    //Creat Matrix with zero's
    public Matrix(int n, string name)
    {
        _matrix = new List<List<float>>();
        _name = name;
        Console.WriteLine($"\nNew {_name}:");
        _matrix = initialMatrix(n);
    }
    
    //Init matrix
    public List<List<float>> initialMatrix(int n)
    {
        if(n > 1)
        {
            for (int i = 0; i < n; i++)
            {
                List<float> row = new List<float>();
                for (int j = 0; j < n; j++)
                {
                    row.Add(0);
                }
                _matrix.Add(row);
            }
            printMatrix();
            return _matrix;
        }
        else
        {
            Console.WriteLine("Matrix size must be greater than 1.");
            return null;
        }

    }
    //Change Matrix from file
    public void changeMatrix(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        _matrix.Clear();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            string[] parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<float> row = new List<float>();
            foreach (string p in parts)
            {
                if (float.TryParse(p, out float value))
                    row.Add(value);
                else
                    Console.WriteLine($"Could not parse '{p}' as float.");
            }

            _matrix.Add(row);
        }

        Console.WriteLine($"\n✅ Matrix {_name} updated from file '{filePath}':");
        printMatrix();
    }
    
    //Display matrix
    public void printMatrix()
    {
        //arranged dispaly
        var tempMaxCellLenght = 0;
        var tempCellLenght = 0;
        Console.WriteLine($"\n{_name} :");

        foreach (var row in this._matrix)
        {
            foreach (var cel in row)
            {
                if (Math.Round(cel, 1).ToString().Length > tempMaxCellLenght) tempMaxCellLenght = Math.Round(cel, 1).ToString().Length;
            }
        }

        foreach (var row in this._matrix)
        {
            foreach (var cel in row)
            {
                tempCellLenght = Math.Round(cel, 1).ToString().Length;
                for (int i = 0; i < tempMaxCellLenght - tempCellLenght; i++) Console.Write(" ");
                Console.Write((float)Math.Round(cel, 1) + " ");
            }
            Console.WriteLine();
        }
    }
    
    // Insert variables to a matrix
    public void insertingVariablesToMatrix()
    {
        int j = _matrix.Count;
        
        _matrix.Clear();

        for (int i = 0; i < j; i++)
        {
            Console.WriteLine($"Insert row {i}:");
            string userRow = Console.ReadLine();
            string[] parts = userRow.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<float> row = new List<float>();
            foreach (string p in parts)
            {
                if (float.TryParse(p, out float value))
                    row.Add(value);
                else
                    Console.WriteLine($"Could not parse '{p}' as float.");
            }
            _matrix.Add(row);
        }
        printMatrix();
    }
}