using System.Diagnostics;
using ProjektowanieSystemow;
//------------Invoke program-------------//
for (;;)
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
    var matrixU = new Matrix(n, "matrixU" );
    var matrixL = new Matrix(n, "matrixL" );

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (matrixA._matrix[i][i] != 0)
            {
                matrixL._matrix[j][i] = matrixA._matrix[j][i]/matrixA._matrix[i][i];
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
                matrixA._matrix[j][k] = matrixA._matrix[j][k] - (matrixL._matrix[j][i] * matrixA._matrix[i][k]);
            }
        }
    }
    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < n; j++)
        {
            if(i <= j) matrixU._matrix[i][j] = matrixA._matrix[i][j];
            else matrixU._matrix[i][j] = 0;
        }
    }
    sw.Stop();

    Console.WriteLine("\n====End of Calculation====");
    matrixA.printMatrix();
    Console.WriteLine("\n=========================");
    
    matrixU.printMatrix();
    matrixL.printMatrix();
    Console.WriteLine("Time Elapsed: " + sw.Elapsed);
    Console.ReadKey();
}
//----------------Extra Functions----------------------//
//Start menu of program
void startMenu()
{
    Console.Clear();
    Console.WriteLine("=======SystemsDesign=======");
    Console.WriteLine("1) For self inserting matrix ");
    Console.WriteLine("2) For matrix 5x5 template");
    Console.Write(">");
    try
    {
        char userChoice = char.Parse(Console.ReadLine());
        
        switch (userChoice)
        {
            case '1':
                  Console.WriteLine("Enter the number:");
                int n =  int.Parse(Console.ReadLine());
                var matrix = new Matrix(n, "matrixA");
                matrix.insertingVariablesToMatrix();
                calculation(matrix);
                break;
            case '2':
                var tempMatrix = new Matrix(5, "matrixA");
                tempMatrix.changeMatrix("MatrixTemplate.txt");
                calculation(tempMatrix);
                break;
            default: Console.WriteLine("Wrong choice!"); break;
        }
        
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}

