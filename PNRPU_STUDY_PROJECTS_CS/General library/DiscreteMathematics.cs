using SpecificDataStructures;

namespace DiscreteMathematics;

public class Matrix
{
    private double[,] matrix = new double[0, 0];
    public string textFilePath = "";
    public int Rows    { get; private set; }
    public int Columns { get; private set; }
    public int Size    { get; private set; }


    // matrix properties
    public Property IsSquareMatrix        { get; private set; }
    public Property IsBinaryMatrix        { get; private set; }
    public Property IsRelationshipsMatrix { get; private set; }

    // relationships properties
    public Property IsReflexive     { get; private set; }
    public Property IsIrreflexive   { get; private set; }
    public Property IsAntisymmetric { get; private set; }
    public Property IsSymmetric     { get; private set; }
    public Property IsAsymmetric    { get; private set; }
    public Property IsTransitive    { get; private set; }
    public Property IsConnected     { get; private set; }

    public Matrix()
    {
        Rows    = 0;
        Columns = 0;
        Size    = 0;

        ResetProperties();
    }

    public void Resize()
    {
        ArrayHandler.TwoDimensional.Resize(ref matrix);
        UpdateDimensionality();
        ResetProperties();
    }

    public void Fill(string textFilePath = "default.txt") 
    {
        ArrayHandler.TwoDimensional.Fill(matrix, textFilePath);
        ResetProperties();
    }

    public void Show()
    {
        int shift = IsBinaryMatrix.Status ? 4 : 20; 
        Console.WriteLine("\nВывод всех элементов матрицы: ");

        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; ++j)
                Console.Write("{0}".PadRight(shift), matrix[i, j]);

            Console.WriteLine();
        }
    }

    public void ShowMatrixProperties()
    {
        Console.WriteLine("\nСвойства матрицы:");
        Console.WriteLine("{0, -20}\t{1}\t{2}", "квадратная", '—', IsSquareMatrix.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "бинарная", '—',   IsBinaryMatrix.Status);
    }

    public void ShowRelationshipsProperties()
    {
        Console.WriteLine("\nСвойства отношений:");
        Console.WriteLine("{0, -20}\t{1}\t{2}", "рефлексивность", '—',     IsReflexive.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "антирефлексивность", '—', IsIrreflexive.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "симметричность", '—',     IsSymmetric.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "антисимметричность", '—', IsAntisymmetric.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "асимметричность", '—',    IsAsymmetric.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "транзитивность", '—',     IsTransitive.Status);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "связность", '—',          IsConnected.Status);
    }

    private void ResetProperties()
    {
        IsSquareMatrix        = new(CheckSquareness);
        IsBinaryMatrix        = new(CheckBinarity);
        IsRelationshipsMatrix = new(CheckIfMatrixIsRelationshipsMatrix);

        IsReflexive     = new(CheckReflexivity);
        IsIrreflexive   = new(CheckReflexivity);
        IsSymmetric     = new(CheckSymmetry);
        IsAntisymmetric = new(CheckSymmetry);
        IsAsymmetric    = new(CheckSymmetry);
        IsTransitive    = new(CheckTransitivity);
        IsConnected     = new(CheckConnexity);
    }

    private void UpdateDimensionality()
    {
        Rows    = matrix.GetUpperBound(0) + 1;
        Columns = (Rows != 0) ? matrix.Length / Rows : 0;
        Size    = Rows * Columns;
    }

    private void CheckSquareness()
    {
        IsSquareMatrix.Status = Rows == Columns;
    }

    private void CheckBinarity()
    {
        if (Size == 0)
        {
            IsBinaryMatrix.Status = false;
            return;
        }

        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; ++j)
            {
                if (matrix[i, j] != 0.0 && matrix[i, j] != 1.0)
                {
                    IsBinaryMatrix.Status = false;
                    return;
                }
            }
        }

        IsBinaryMatrix.Status = true;
    }

    private void CheckIfMatrixIsRelationshipsMatrix()
    {
        IsRelationshipsMatrix.Status = IsSquareMatrix.Status && IsBinaryMatrix.Status;
    }

    private void CheckReflexivity()
    {
        if (!IsRelationshipsMatrix.Status)
            return;

        int rankOfMatrix = Rows;
        double sumOfvaluesOnMainDiagonal = 0;
        for (int i = 0, j = 0; i < rankOfMatrix; ++i, ++j)
            sumOfvaluesOnMainDiagonal += matrix[i, j];

        IsReflexive.Status   = sumOfvaluesOnMainDiagonal == rankOfMatrix;
        IsIrreflexive.Status = sumOfvaluesOnMainDiagonal == 0;
        IsReflexive.isChecked   = true;
        IsIrreflexive.isChecked = true;
    }

    private void CheckSymmetry()
    {
        if (!IsRelationshipsMatrix.Status)
            return;

        int rankOfMatrix = Rows;
        bool isSymmetric      = true; // проверяем матрицу до тех пор,
        bool isAntisymmetric  = true; // пока свойства сохраняются
        for (int i = 0; i < rankOfMatrix; ++i)
        {
            for (int j = 0; j < rankOfMatrix; ++j)
            {
                if (i == j)
                    break;

                isSymmetric     = isSymmetric     && (matrix[i, j] == matrix[j, i]);
                isAntisymmetric = isAntisymmetric && ((matrix[i, j] + matrix[j, i]) < 2);

                if (!isSymmetric && !isAntisymmetric)
                {
                    IsSymmetric.Status     = false;
                    IsAntisymmetric.Status = false;
                    IsAsymmetric.Status    = false;
                    IsSymmetric.isChecked     = true;
                    IsAntisymmetric.isChecked = true;
                    IsAsymmetric.isChecked    = true;
                    return;
                }
            }
        }

        IsSymmetric.Status     = isSymmetric;
        IsAntisymmetric.Status = isAntisymmetric;
        IsAsymmetric.Status    = isAntisymmetric && IsIrreflexive.Status;
        IsSymmetric.isChecked     = true;
        IsAntisymmetric.isChecked = true;
        IsAsymmetric.isChecked    = true; 
    }

    private void CheckTransitivity()
    {
        if (!IsRelationshipsMatrix.Status)
            return;

        int rankOfMatrix = Rows;
        for (int i = 0; i < rankOfMatrix; ++i)
        {
            for (int j = 0; j < rankOfMatrix; ++j)
            {
                if (i == j)
                    continue;

                if (matrix[i, j] == 0)
                    continue;

                for (int k = 0; k < rankOfMatrix; ++k)
                {
                    if (k == i || k == j)
                        continue;

                    if (matrix[j, k] == 0)
                        continue;

                    if (matrix[i, k] == 0)
                    {
                        IsTransitive.Status = false;
                        return;
                    }
                }
            }
        }

        IsTransitive.Status = true;
    }

    private void CheckConnexity()
    {
        if (!IsRelationshipsMatrix.Status)
            return;

        int rankOfMatrix = Rows;
        for (int i = 0; i < rankOfMatrix; ++i)
        {
            for (int j = 0; j < rankOfMatrix; ++j)
            {
                if (i == j)
                    continue;

                if ((matrix[i, j] + matrix[j, i]) == 0)
                {
                    IsConnected.Status = false;
                    return;
                }
            }
        }

        IsConnected.Status = true;
    }
}