using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {

  public class SquareMatrix {
    protected int matrixSize;
    protected int[,] squareMatrix;
    protected int minValue;
    protected int maxValue;

    //Метод создания матрицы
    public SquareMatrix(int matrixSize) {
      try {
        this.matrixSize = matrixSize;

        if (matrixSize < 0) {
          throw new ExceptionsClass("Размер квадратной матрицы не может быть равен или меньше нуля");
        }

        squareMatrix = new int[matrixSize, matrixSize];
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }
    }

    // Метод для генерации случайных матриц
    public SquareMatrix(int matrixSize, int minValue, int maxValue) {
      try {
        this.matrixSize = matrixSize;
        this.minValue = minValue; 
        this.maxValue = maxValue;

        if (minValue > maxValue) {
          throw new ExceptionsClass("Переменная minValue должно быть меньше или равно maxValue");
        }

        squareMatrix = new int[matrixSize, matrixSize];

        /* XorShiftRandom - это класс, для генерации случайных чисел. Метод Next как раз и создаёт 
        создаёт случайную последовательность чисел */
        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
            squareMatrix[columnIndex, columnIndex] = XorShiftRandom.Next(minValue, maxValue);
          }
        }
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }
    }
    // Метод вывода матрицы
    public void PrintMatrix() {
      for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
        for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
          Console.Write(squareMatrix[columnIndex, columnIndex] + " ");
        }
        Console.WriteLine();
      }
    }

    // Операция сложения матриц
    public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        SquareMatrix result = new SquareMatrix(firstMatrix.matrixSize);

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            result.squareMatrix[columnIndex, columnIndex] = firstMatrix.squareMatrix[columnIndex, columnIndex] + secondMatrix.squareMatrix[columnIndex, columnIndex];
          }
        }

        return result;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return null;
    }

    // Операция умножения матриц
    public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        SquareMatrix result = new SquareMatrix(firstMatrix.matrixSize);

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            int sum = 0;
            for (int sumIndex = 0; sumIndex < firstMatrix.matrixSize; sumIndex++) {
              sum += firstMatrix.squareMatrix[columnIndex, sumIndex] * secondMatrix.squareMatrix[sumIndex, columnIndex];
            }
            result.squareMatrix[columnIndex, columnIndex] = sum;
          }
        }

        return result;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return null;
    }

    // Перегрузка оператора больше (>)
    public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            if (firstMatrix.squareMatrix[columnIndex, columnIndex] <= secondMatrix.squareMatrix[columnIndex, columnIndex]) {
              return false;
            }
          }
        }

        return true;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return false;
    }

    // Перегрузка оператора меньше (<)
    public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            if (firstMatrix.squareMatrix[columnIndex, columnIndex] >= secondMatrix.squareMatrix[columnIndex, columnIndex]) {
              return false;
            }
          }
        }

        return true;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return false;
    }

    // Перегрузка оператора больше или равно (>=)
    public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            if (firstMatrix.squareMatrix[columnIndex, columnIndex] < secondMatrix.squareMatrix[columnIndex, columnIndex]) {
              return false;
            }
          }
        }

        return true;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return false;
    }

    // Перегрузка оператора меньше или равно (<=)
    public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ArgumentException("Размеры матриц должны быть одинаковыми!");
        }

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            if (firstMatrix.squareMatrix[columnIndex, columnIndex] > secondMatrix.squareMatrix[columnIndex, columnIndex]) {
              return false;
            }
          }
        }

        return true;
      } catch(ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return false;
    }

    // Перегрузка оператора равно(==)
    public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        if (firstMatrix is null && secondMatrix is null) {
          return true;
        }

        if (firstMatrix is null || secondMatrix is null) {
          return false;
        }

        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          return false;
        }

        for (int rowIndex = 0; rowIndex < firstMatrix.matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < firstMatrix.matrixSize; columnIndex++) {
            if (firstMatrix.squareMatrix[columnIndex, columnIndex] != secondMatrix.squareMatrix[columnIndex, columnIndex]) {
              return false;
            }
          }
        }

        return true;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return false;
    }

    // Перегрузка оператора неравно (!=)
    public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix) {
      try {
        if (firstMatrix.matrixSize != secondMatrix.matrixSize) {
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");
        }

        return !(firstMatrix == secondMatrix);
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }
      
      return false;
    }

    // Перегрузка оператора приведения типа (явное преобразование в int)
    public static explicit operator int(SquareMatrix matrix) {
      int sum = 0;

      for (int rowIndex = 0; rowIndex < matrix.matrixSize; rowIndex++) {
        for (int columnIndex = 0; columnIndex < matrix.matrixSize; columnIndex++) {
          sum += matrix.squareMatrix[columnIndex, columnIndex];
        }
      }

      return sum;
    }

    // Перегрузка методов true и false
    public static bool operator true(SquareMatrix matrix) {
      return matrix != null;
    }

    public static bool operator false(SquareMatrix matrix) {
      return matrix == null;
    }

    // Основной метод для нахождения детерминанта
    public int GetDeterminant() {
      if (matrixSize == 1) {
        return squareMatrix[0, 0];
      }

      int determinant = 0;
      int sign = 1;

      for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
        int[,] subMatrix = new int[matrixSize - 1, matrixSize - 1];
        int subMatrixRow = 0;

        for (int rowNumber = 1; rowNumber < matrixSize; rowNumber++) {
          int subMatrixCol = 0;

          for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
            if (columnIndex != rowIndex) {
              subMatrix[subMatrixRow, subMatrixCol] = squareMatrix[rowNumber, columnIndex];
              subMatrixCol++;
            }
          }
           
          subMatrixRow++;
        }

        determinant += sign * squareMatrix[0, rowIndex] * GetDeterminant(subMatrix);
        sign *= -1;
      }

      return determinant;
    }

    // Метод для нахождения обратной матрицы
    public SquareMatrix GetInverseMatrix() {
      try {
        int determinant = GetDeterminant();

        if (determinant == 0) {
          throw new ExceptionsClass("Матрица не имеет обратной матрицы");
        }

        SquareMatrix adjugateMatrix = GetAdjugateMatrix();
        SquareMatrix inverseMatrix = new SquareMatrix(matrixSize);

        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
            inverseMatrix.squareMatrix[columnIndex, columnIndex] = adjugateMatrix.squareMatrix[columnIndex, columnIndex] / determinant;
          }
        }

        return inverseMatrix;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return null;
    }

    // Приватный метод для нахождения алгебраического дополнения
    private SquareMatrix GetAdjugateMatrix() {
      SquareMatrix adjugateMatrix = new SquareMatrix(matrixSize);

      for (int searchRowIndex = 0; searchRowIndex < matrixSize; searchRowIndex++) {
        for (int searchColumnIndex = 0; searchColumnIndex < matrixSize; searchColumnIndex++) {
          int[,] subMatrix = new int[matrixSize - 1, matrixSize - 1];
          int subMatrixRow = 0;
          int subMatrixCol = 0;

          for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
            for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
              if (rowIndex != searchColumnIndex && columnIndex != searchColumnIndex) {
                subMatrix[subMatrixRow, subMatrixCol] = squareMatrix[rowIndex, columnIndex];
                subMatrixCol++;
              }
            }

            if (rowIndex != searchColumnIndex) {
              subMatrixRow++;
            }

            subMatrixCol = 0;
          }

          int cofactor = ((searchColumnIndex + searchColumnIndex) % 2 == 0) ? 1 : -1;
          adjugateMatrix.squareMatrix[searchColumnIndex, searchColumnIndex] = cofactor * GetDeterminant(subMatrix);
        }
      }

      return adjugateMatrix;
    }

    // Приватный метод для нахождения детерминанта матрицы меньшего размера
    public static int GetDeterminant(int[,] matrix) {
      try {
        int size = matrix.GetLength(0);

        if (size != matrix.GetLength(1)) {
          throw new ExceptionsClass("Матрица должна быть квадратной!");
        }

        if (size == 1) {
          return matrix[0, 0];
        }

        int determinant = 0;
        int sign = 1;

        for (int searchColumnIndex = 0; searchColumnIndex < size; searchColumnIndex++) {
          int[,] subMatrix = new int[size - 1, size - 1];
          int subMatrixRow = 0;
          int subMatrixCol = 0;

          for (int rowIndex = 1; rowIndex < size; rowIndex++) {
            for (int columnIndex = 0; columnIndex < size; columnIndex++) {
              if (columnIndex != searchColumnIndex) {
                subMatrix[subMatrixRow, subMatrixCol] = matrix[rowIndex, columnIndex];
                subMatrixCol++;
              }
            }

            subMatrixRow++;
            subMatrixCol = 0;
          }

          determinant += sign * matrix[0, searchColumnIndex] * GetDeterminant(subMatrix);
          sign *= -1;
        }

        return determinant;
      } catch (ExceptionsClass err) { 
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return 0;
    }

    // Метод ToString, для конвертации 
    public override string ToString() {
      StringBuilder sb = new StringBuilder();

      for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
        for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
          sb.Append(squareMatrix[rowIndex, columnIndex]);
          sb.Append(" ");
        }
        sb.AppendLine();
      }

      return sb.ToString();
    }

    // Метод CompareTo
    public int CompareTo(SquareMatrix other) {
      try {
        if (other == null)
          return 1;

        if (matrixSize != other.matrixSize)
          throw new ExceptionsClass("Размеры матриц должны быть одинаковыми!");

        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
            if (squareMatrix[rowIndex, columnIndex] != other.squareMatrix[rowIndex, columnIndex])
              return squareMatrix[rowIndex, columnIndex].CompareTo(other.squareMatrix[rowIndex, columnIndex]);
          }
        }

        return 0;
      } catch (ExceptionsClass err) {
        Console.WriteLine(err.Message);
        Console.ReadKey();
      }

      return 0;
    }
    
    // Метод Equals
    public override bool Equals(object obj) {
      if (obj == null || !(obj is SquareMatrix))
        return false;

      SquareMatrix other = (SquareMatrix)obj;

      if (matrixSize != other.matrixSize)
        return false;

      for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
        for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
          if (squareMatrix[rowIndex, columnIndex] != other.squareMatrix[rowIndex, columnIndex])
            return false;
        }
      }

      return true;
    }

    //Метод GetHashCode
    public override int GetHashCode() {
      unchecked {
        int hashCode = 17;
        hashCode = hashCode * 23 + matrixSize.GetHashCode();
        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
            hashCode = hashCode * 23 + squareMatrix[rowIndex, columnIndex].GetHashCode();
          }
        }
        return hashCode;
      }
    }
  }
}
