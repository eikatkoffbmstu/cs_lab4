using System;

class MyMatrix
{
    private int[,] matrix;
    private int numRows;
    private int numCols;
    private static Random random = new Random();

    public MyMatrix(int rows, int cols, int minRandomValue, int maxRandomValue)
    {
        numRows = rows;
        numCols = cols;
        matrix = new int[numRows, numCols];

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = random.Next(minRandomValue, maxRandomValue + 1);
            }
        }
    }

    public int this[int row, int col]
    {
        get
        {
            if (row >= 0 && row < numRows && col >= 0 && col < numCols)
            {
                return matrix[row, col];
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
        set
        {
            if (row >= 0 && row < numRows && col >= 0 && col < numCols)
            {
                matrix[row, col] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
    }

    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.numRows != b.numRows || a.numCols != b.numCols)
        {
            Console.WriteLine("Matrices must have the same dimensions for addition. Look at these nice nulls:");

            MyMatrix result = new MyMatrix(2, 2, 0, 0);

            for (int i = 0; i < 2; i++) for (int j = 0; j < 2; j++) result[i, j] = 0;

            return result;
        }
        else
        {
            MyMatrix result = new MyMatrix(a.numRows, a.numCols, 0, 0);

            for (int i = 0; i < a.numRows; i++)
            {
                for (int j = 0; j < a.numCols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }
    }

    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        if (a.numRows != b.numRows || a.numCols != b.numCols)
        {
            Console.WriteLine("Matrices must have the same dimensions for subtraction. Do you like nulls?");

            MyMatrix result = new MyMatrix(2, 2, 0, 0);

            for (int i = 0; i < 2; i++) for (int j = 0; j < 2; j++) result[i, j] = 0;

            return result;
        }
        else
        {
            MyMatrix result = new MyMatrix(a.numRows, a.numCols, 0, 0);

            for (int i = 0; i < a.numRows; i++)
            {
                for (int j = 0; j < a.numCols; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }

            return result;
        }
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.numCols != b.numRows)
        {
            Console.WriteLine("Matrices cannot be multiplied, look at the four nulls:");

            MyMatrix result = new MyMatrix(2, 2, 0, 0);

            for (int i = 0; i < 2; i++) for (int j = 0; j < 2; j++) result[i, j] = 0;

            return result;
        }
        else
        {
            MyMatrix result = new MyMatrix(a.numRows, b.numCols, 0, 0);

            for (int i = 0; i < a.numRows; i++)
            {
                for (int j = 0; j < b.numCols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.numCols; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    }

    public static MyMatrix operator *(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.numRows, a.numCols, 0, 0);

        for (int i = 0; i < a.numRows; i++)
        {
            for (int j = 0; j < a.numCols; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator /(MyMatrix a, int scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        MyMatrix result = new MyMatrix(a.numRows, a.numCols, 0, 0);

        for (int i = 0; i < a.numRows; i++)
        {
            for (int j = 0; j < a.numCols; j++)
            {
                result[i, j] = a[i, j] / scalar;
            }
        }

        return result;
    }

    public void Print()
    {
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class lab041
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows for Matrix A:");
        int rowsA = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns for Matrix A:");
        int colsA = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of rows for Matrix B:");
        int rowsB = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns for Matrix B:");
        int colsB = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the minimum random value:");
        int minRandomValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the maximum random value:");
        int maxRandomValue = int.Parse(Console.ReadLine());

        MyMatrix matrixA = new MyMatrix(rowsA, colsA, minRandomValue, maxRandomValue);
        MyMatrix matrixB = new MyMatrix(rowsB, colsB, minRandomValue, maxRandomValue);

        Console.WriteLine("\nMatrix A:");
        matrixA.Print();

        Console.WriteLine("\nMatrix B:");
        matrixB.Print();

        Console.WriteLine("\nMatrix A + Matrix B:");
        (matrixA + matrixB).Print();

        Console.WriteLine("\nMatrix A - Matrix B:");
        (matrixA - matrixB).Print();

        Console.WriteLine("\nMatrix A * Matrix B:");
        (matrixA * matrixB).Print();

        Console.WriteLine("\nMatrix A * 2:");
        (matrixA * 2).Print();

        Console.WriteLine("\nMatrix A / 2:");
        (matrixA / 2).Print();
    }
}
