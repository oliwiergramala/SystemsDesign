using System.Diagnostics;
using ProjektowanieSystemow;
//------------Invoke program-------------//
for (; ; )
{
    startMenu();
}

//-------LU decomposition of a matrix using the Gaussian method-------//

void calculation(Matrix matrixA)
{
    //Timer
    Stopwatch sw = new Stopwatch();
    sw.Restart();
    sw.Start();
    int n = matrixA._matrix.Count();
    //Initial matrix for calculation
    var tempMatrixA = new Matrix(n, "tempMatrixA");
    var matrixU = new Matrix(n, "matrixU");
    var matrixL = new Matrix(n, "matrixL");

    tempMatrixA._matrix = matrixA._matrix.Select(row => row.ToList()).ToList();

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (matrixA._matrix[i][i] != 0)
            {
                matrixL._matrix[j][i] = matrixA._matrix[j][i] / matrixA._matrix[i][i];

            }
            else
            {
                matrixL._matrix[j][i] = 0;
            }

        }

        for (int j = i + 1; j < n; j++)
        {
            for (int k = i + 1; k < n; k++)
            {
                tempMatrixA._matrix[j][k] = tempMatrixA._matrix[j][k] - (matrixL._matrix[j][i] * tempMatrixA._matrix[i][k]);
            }
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i <= j) matrixU._matrix[i][j] = tempMatrixA._matrix[i][j];
            else matrixU._matrix[i][j] = 0;
        }
        matrixL._matrix[i][i] = 1;
    }
    sw.Stop();

    Console.WriteLine("\n====End of Calculation====");
    matrixA.printMatrix();
    Console.WriteLine("\n=========================");

    matrixU.printMatrix();
    matrixL.printMatrix();
    Console.WriteLine("Time Elapsed: " + sw.Elapsed);
}
//----------------Extra Functions----------------------//
//Start menu of program
void startMenu()
{
    void functionTempMatrix(int size)
    {
        var tempMatrix = new Matrix(size, "matrixA");
        tempMatrix.changeMatrix("MatrixTemplates/MatrixTemplate" + size + ".txt");
        calculation(tempMatrix);
    }

    Console.Clear();
    Console.WriteLine("=======SystemsDesign=======");
    Console.WriteLine("1) For self inserting matrix ");
    Console.WriteLine("2) For matrix 2x2 template");
    Console.WriteLine("3) For matrix 3x3 template");
    Console.WriteLine("4) For matrix 4x4 template");
    Console.WriteLine("5) For matrix 5x5 template");
    Console.WriteLine("6) For matrix 6x6 template");
    Console.WriteLine("7) For matrix 7x7 template");
    Console.WriteLine("8) For matrix 8x8 template");
    Console.WriteLine("9) For matrix 9x9 template");
    Console.WriteLine("10) For matrix 10x10 template");
    Console.WriteLine("11) For matrix 20x20 template");
    Console.WriteLine("12) For matrix 100x100 template");
    Console.WriteLine("13) For matrix 1000x1000 template");
    Console.WriteLine("14) For matrix 10000x10000 template");
    Console.Write(">");
    try
    {
        int userChoice = int.Parse(Console.ReadLine());

        if (userChoice == 1)
        {
            Console.WriteLine("Enter the number:");
            int n = int.Parse(Console.ReadLine());
            var matrix = new Matrix(n, "matrixA");
            matrix.insertingVariablesToMatrix();
            calculation(matrix);
        }
        else if (userChoice > 1 && userChoice < 15)
        {
            functionTempMatrix(userChoice);
        }
        else
        {
            Console.WriteLine("Wrong choice!");
        }

    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
    Console.WriteLine("\n=========================");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

