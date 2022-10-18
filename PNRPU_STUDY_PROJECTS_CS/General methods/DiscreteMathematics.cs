namespace DiscreteMathematics;

public class Matrix
{
    private double[,] matrix = new double[0, 0];
    public string textFilePath = "";
    public int Rows    { get; private set; }
    public int Columns { get; private set; }
    public int Size    { get; private set; }


    // matrix properties
    private bool isSquareMatrix = false,
                 isBinaryMatrix = false;
    public  bool IsSquareMatrix
    {
        get
        {
            if (!haveMatrixSquarenessBeenChecked)
                CheckSquareness();

            return isSquareMatrix;
        }
        private set
        {
            isSquareMatrix = value;
        } 
    }
    public  bool IsBinaryMatrix
    {
        get
        {
            if (!haveMatrixBinarityBeenChecked)
                CheckBinarity();

            return isBinaryMatrix;
        }
        private set
        {
            isBinaryMatrix = value;
        }
    }
    private bool haveMatrixSquarenessBeenChecked = false;
    private bool haveMatrixBinarityBeenChecked   = false;

    // relations properties
    private bool isReflexive     = false,
                 isIrreflexive   = false,
                 isSymmetric     = false,
                 isAntisymmetric = false,
                 isAsymmetric    = false,
                 isTransitive    = false,
                 isConnected     = false;
    public  bool IsReflexive
    {
        get
        {
            if (!haveMatrixReflexiveBeenChecked)
                CheckReflexivity();

            return isReflexive;
        }
        private set
        {
            isReflexive = value;
        }
    }
    public  bool IsIrreflexive
    {
        get
        {
            if (!haveMatrixIrreflexiveBeenChecked)
                CheckReflexivity();

            return isIrreflexive;
        }
        private set
        {
            isIrreflexive = value;
        }
    }
    public  bool IsSymmetric
    {
        get
        {
            if (!haveMatrixSymmetricBeenChecked)
                CheckSymmetry();

            return isSymmetric;
        }
        private set
        {
            isSymmetric = value;
        }
    }
    public  bool IsAntisymmetric
    {
        get
        {
            if (!haveMatrixAntisymmetricBeenChecked)
                CheckSymmetry();

            return isAntisymmetric;
        }
        private set
        {
            isAntisymmetric = value;
        }
    }
    public  bool IsAsymmetric
    {
        get
        {
            if (!haveMatrixAsymmetricBeenChecked)
                CheckSymmetry();

            return isAsymmetric;
        }
        private set
        {
            isAsymmetric = value;
        }
    }
    public  bool IsTransitive
    {
        get
        {
            if (!haveMatrixTransitiveBeenChecked)
                CheckTransitivity();

            return isTransitive;
        }
        private set
        {
            isTransitive = value;
        }
    }
    public  bool IsConnected
    {
        get
        {
            if (!haveMatrixConnectedBeenChecked)
                CheckConnexity();

            return isConnected;
        }
        private set
        {
            isConnected = value;
        }
    }
    private bool haveMatrixReflexiveBeenChecked     = false;
    private bool haveMatrixIrreflexiveBeenChecked   = false;
    private bool haveMatrixSymmetricBeenChecked     = false;
    private bool haveMatrixAntisymmetricBeenChecked = false;
    private bool haveMatrixAsymmetricBeenChecked    = false;
    private bool haveMatrixTransitiveBeenChecked    = false;
    private bool haveMatrixConnectedBeenChecked     = false;

    public Matrix()
    {
        Rows    = 0;
        Columns = 0;
        Size    = 0;

        IsSquareMatrix = isSquareMatrix;
        IsBinaryMatrix = isBinaryMatrix;

        IsReflexive     = isReflexive;
        IsIrreflexive   = isIrreflexive;
        IsSymmetric     = isSymmetric;
        IsAntisymmetric = isAntisymmetric;
        IsAsymmetric    = isAsymmetric;
        IsTransitive    = isTransitive;
        IsConnected     = isConnected;    
    }

    public void Resize()
    {
        ArrayHandler.TwoDimensional.Resize(ref matrix);
        CheckSquareness();
    }

    public void Fill(string textFilePath = "default.txt") 
    {
        ArrayHandler.TwoDimensional.Fill(matrix, textFilePath);
        CheckBinarity();
    }

    public void Show()
    {
        CheckMatrixProperties();
        int shift = IsBinaryMatrix ? 4 : 20; 
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
        CheckMatrixProperties();
        Console.WriteLine("\nСвойства матрицы:");
        Console.WriteLine("{0, -20}\t{1}\t{2}", "квадратная", '—', IsSquareMatrix);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "бинарная", '—',   IsBinaryMatrix);
    }

    public void ShowRelationsProperties()
    {
        CheckRelationsProperties();
        Console.WriteLine("\nСвойства отношений:");
        Console.WriteLine("{0, -20}\t{1}\t{2}", "рефлексивность", '—',     IsReflexive);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "антирефлексивность", '—', IsIrreflexive);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "симметричность", '—',     IsSymmetric);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "антисимметричность", '—', IsAntisymmetric);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "асимметричность", '—',    IsAsymmetric);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "транзитивность", '—',     IsTransitive);
        Console.WriteLine("{0, -20}\t{1}\t{2}", "связность", '—',          IsConnected);
    }

    private void UpdateDimensionality()
    {
        Rows    = matrix.GetUpperBound(0) + 1;
        Columns = (Rows != 0) ? matrix.Length / Rows : 0;
        Size    = Rows * Columns;
    }

    private void CheckSquareness()
    {
        UpdateDimensionality();
        IsSquareMatrix = Rows == Columns;
        haveMatrixSquarenessBeenChecked = true;
    }

    private void CheckBinarity()
    {
        if (Size == 0)
        {
            IsBinaryMatrix = false;
            return;
        }

        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; ++j)
            {
                if (matrix[i, j] != 0.0 && matrix[i, j] != 1.0)
                {
                    IsBinaryMatrix = false;
                    return;
                }
            }
        }

        IsBinaryMatrix = true;
        haveMatrixBinarityBeenChecked = true;
    }

    private void CheckMatrixProperties()
    {
        if (!haveMatrixSquarenessBeenChecked)
            CheckSquareness();

        if (!haveMatrixBinarityBeenChecked)
            CheckBinarity();
    }

    private void CheckRelationsProperties()
    {
        if (!haveMatrixReflexiveBeenChecked)
            CheckReflexivity();
        else if (!haveMatrixIrreflexiveBeenChecked)
            CheckReflexivity();

        if (!haveMatrixSymmetricBeenChecked)
            CheckSymmetry();
        else if (!haveMatrixAntisymmetricBeenChecked)
            CheckSymmetry();
        else if (!haveMatrixAsymmetricBeenChecked)
            CheckSymmetry();

        if (!haveMatrixTransitiveBeenChecked)
            CheckTransitivity();

        if (!haveMatrixConnectedBeenChecked)
            CheckConnexity();
    }

    private void CheckReflexivity()
    {
        CheckMatrixProperties();
        if (!(IsSquareMatrix && IsBinaryMatrix))
            return;

        int rankOfMatrix = Rows;
        double sumOfvaluesOnMainDiagonal = 0;
        for (int i = 0, j = 0; i < rankOfMatrix; ++i, ++j)
            sumOfvaluesOnMainDiagonal += matrix[i, j];

        IsReflexive   = sumOfvaluesOnMainDiagonal == rankOfMatrix;
        IsIrreflexive = sumOfvaluesOnMainDiagonal == 0;
        haveMatrixReflexiveBeenChecked   = true;
        haveMatrixIrreflexiveBeenChecked = true;
    }

    private void CheckSymmetry()
   {
        CheckMatrixProperties();
        if (!(IsSquareMatrix && IsBinaryMatrix))
            return;

        int rankOfMatrix = Rows;
        isSymmetric      = true; // проверяем матрицу до тех пор,
        isAntisymmetric  = true; // пока свойства сохраняются
        for (int i = 0; i < rankOfMatrix; ++i)
        {
            for (int j = 0; j < rankOfMatrix; ++j)
            {
                if (i == j)
                    break;

                IsSymmetric     = isSymmetric     && (matrix[i, j] == matrix[j, i]);
                IsAntisymmetric = isAntisymmetric && ((matrix[i, j] + matrix[j, i]) < 2);

                if (!isSymmetric && !isAntisymmetric)
                {
                    IsAsymmetric = false;
                    haveMatrixSymmetricBeenChecked     = true;
                    haveMatrixAntisymmetricBeenChecked = true;
                    haveMatrixAsymmetricBeenChecked    = true;
                    return;
                }
            }
        }

        if (!haveMatrixIrreflexiveBeenChecked)
            CheckReflexivity();

        IsAsymmetric = isAntisymmetric && isIrreflexive;
        haveMatrixSymmetricBeenChecked     = true;
        haveMatrixAntisymmetricBeenChecked = true;
        haveMatrixAsymmetricBeenChecked    = true;
    }

    private void CheckTransitivity()
    {
        CheckMatrixProperties();
        if (!(IsSquareMatrix && IsBinaryMatrix))
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
                        IsTransitive = false;
                        haveMatrixTransitiveBeenChecked = true;
                        return;
                    }
                }
            }
        }

        IsTransitive = true;
        haveMatrixTransitiveBeenChecked = true;
    }

    private void CheckConnexity()
    {
        CheckMatrixProperties();
        if (!(IsSquareMatrix && IsBinaryMatrix))
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
                    IsConnected = false;
                    haveMatrixConnectedBeenChecked = true;
                    return;
                }
            }
        }

        IsConnected = true;
        haveMatrixConnectedBeenChecked = true;
    }
}