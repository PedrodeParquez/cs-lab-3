using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {
  public class SquareMatrix {
    private int matrixSize;
    private int[,] squareMatrix;

    public SquareMatrix(int matrixSize) {
      this.matrixSize = matrixSize;

      squareMatrix = new int[matrixSize, matrixSize];
    }

    public SquareMatrix(int matrixSize, int minValue, int maxValue) {
      this.matrixSize = matrixSize;

      if (minValue > maxValue) {
        throw new ArgumentException("Переменная minValue должно быть меньше или равно maxValue");
      }

      squareMatrix = new int[matrixSize, matrixSize];

      /* XorShiftRandom - это класс, для генерации случайных чисел. Метод Next как раз и создаёт 
      создаёт случайную последовательность чисел */
      for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          squareMatrix[columnIndex, rowIndex] = XorShiftRandom.Next(minValue, maxValue);
        }
      }
    } 

    public void PrintMatrix() {
      for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++) {
        for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++) {
          Console.Write(squareMatrix[columnIndex, rowIndex] + " ");
        }
        Console.WriteLine();
      }
    }

    public static SquareMatrix operator +(SquareMatrix matrix1, SquareMatrix matrix2) {
      if (matrix1.matrixSize != matrix2.matrixSize) {
        throw new ArgumentException("Размеры матриц   должны быть одинаковыми.");
      }

      SquareMatrix result = new SquareMatrix(matrix1.matrixSize);

      for (int columnIndex = 0; columnIndex < matrix1.matrixSize; columnIndex++) {
        for (int rowIndex = 0; rowIndex < matrix1.matrixSize; rowIndex++) {
          result.squareMatrix[columnIndex, rowIndex] = matrix1.squareMatrix[columnIndex, rowIndex] +
                                                      matrix2.squareMatrix[columnIndex, rowIndex];
        }
      }

      return result;
    }

    public static SquareMatrix operator *(SquareMatrix matrix1, SquareMatrix matrix2) {
      if (matrix1.matrixSize != matrix2.matrixSize) {
        throw new ArgumentException("Размеры матриц должны быть одинаковыми.");
      }

      SquareMatrix result = new SquareMatrix(matrix1.matrixSize);

      for (int columnIndex = 0; columnIndex < matrix1.matrixSize; columnIndex++) {
        for (int rowIndex = 0; rowIndex < matrix1.matrixSize; rowIndex++) {
          int sum = 0;
          for (int k = 0; k < matrix1.matrixSize; k++) {
            sum += matrix1.squareMatrix[columnIndex, k] * matrix2.squareMatrix[k, rowIndex];
          }
          result.squareMatrix[columnIndex, rowIndex] = sum;
        }
      }

      return result;
    }

  }

}
