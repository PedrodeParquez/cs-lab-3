  using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {
  internal class Program {
    static void Main() {
      int firstMatrixSize, firstMinNumber, firstMaxNumber, secondMatrixSize, 
        secondMinNumber, secondMaxNumber, userChoice;
        
      Console.Write("Введите размер первой квадратичной матрицы: ");
      firstMatrixSize = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите минимальное число первой матрицы: ");
      firstMinNumber = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите максимальное число первой матрицы: ");
      firstMaxNumber = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите размер второй квадратичной матрицы: ");
      secondMatrixSize = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите минимальное число второй матрицы: ");
      secondMinNumber = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите максимальное число второй матрицы: ");
      secondMaxNumber = Convert.ToInt32(Console.ReadLine());
        
      SquareMatrix firstRandomSquareMatrix = new SquareMatrix(firstMatrixSize, firstMinNumber, firstMaxNumber);
         
      Console.WriteLine("Первая квадратная матрица со случайными значениями");
      firstRandomSquareMatrix.PrintMatrix();

      SquareMatrix secondRandomSquareMatrix = new SquareMatrix(secondMatrixSize, secondMinNumber, secondMaxNumber);

      Console.WriteLine("Первая квадратная матрица со случайными значениями");
      secondRandomSquareMatrix.PrintMatrix();

      Console.WriteLine("Выберите, что вы хотите сделать с представленными матрицами:" +
        "\nСложить матрицы - 1" +
        "\nПеремножить матрицы - 2 " +
        "\nУзнать больше ли первая матрица чем вторая матрица- 3 " +
        "\nУзнать меньше ли первая матрица чем вторая матрица - 4 " +
        "\nУзнать больше или равно первая матрица чем вторая - 5" +
        "\nУзнать меньше или равна первая матрица чем вторая - 6" +
        "\nУзнать равны ли случайные матрицы - 7" +
        "\nУзнать неравны ли случайные матрицы - 8" +
        "\nПривеcти матрицу в тип int - 9" +
        "\nПерегрузка метода true для любой матрицы - 10" +
        "\nПерегрузка методов false для любой матрицы - 11" +
        "\nНайти детерминанту выбранной матрицы - 12" +
        "\nНайти обратную матрицу выбранной матрицы - 13" +
        "\nВаш выбор: ");

      userChoice = Convert.ToInt32(Console.ReadLine());
      
      switch (userChoice) {
        case 1:
          Console.WriteLine("Матрица которая получилась после сложения двух случайных матриц:");
          SquareMatrix resultAdditionsMatrix = firstRandomSquareMatrix + secondRandomSquareMatrix;
          resultAdditionsMatrix.PrintMatrix();
          break;
        case 2:
          Console.Write("Матрица которая получилась после сложения двух случайных матриц");
          SquareMatrix resultMultiplicationMatrix = firstRandomSquareMatrix + secondRandomSquareMatrix;
          resultMultiplicationMatrix.PrintMatrix();
          break;
        case 3:
          Console.Write("Результат сравнения матриц");
          bool isGreaterResult = firstRandomSquareMatrix > secondRandomSquareMatrix;

          if (isGreaterResult) {
            Console.WriteLine("Первая матрица больше второй матрицы.");
          } else {
            Console.WriteLine("Первая матрица меньше или равна второй матрицы.");
          }
          break;
        case 4:
          Console.Write("Результат сравнения матриц: ");
          bool isLessResult = firstRandomSquareMatrix > secondRandomSquareMatrix;

          if (isLessResult) {
            Console.WriteLine("Первая матрица меньше второй матрицы.");
          } else {
            Console.WriteLine("Первая матрица больше или равна второй матрицы.");
          }
          break;
        case 5:
          Console.Write("Результат сравнения матриц");
          bool isGreaterOrEqualResult = firstRandomSquareMatrix > secondRandomSquareMatrix;

          if (isGreaterOrEqualResult) {
            Console.WriteLine("Первая матрица больше или равна второй матрицы.");
          } else {
            Console.WriteLine("Первая матрица меньше или не равна второй матрицы.");
          }
          break;
        case 6:
          Console.Write("Результат сравнения матриц:");
          bool isLessOrEqualResult = firstRandomSquareMatrix > secondRandomSquareMatrix;

          if (isLessOrEqualResult) {
            Console.WriteLine("Первая матрица меньше или равна второй матрицы.");
          } else {
            Console.WriteLine("Первая матрица больше или не равна второй матрицы.");
          }
          break;
        case 7:
          Console.Write("Результат сравнения матриц: ");
          bool isEqualResult = firstRandomSquareMatrix == secondRandomSquareMatrix;

          if (isEqualResult) {
            Console.WriteLine("Первая матрица равна второй матрице.");
          } else {
            Console.WriteLine("Первая матрица не равна, больше или меньше второй матрицы.");
          }
          break;
        case 8:
          Console.Write("Резултаты сравнения: ");
          bool isNotEqualResult = firstRandomSquareMatrix != secondRandomSquareMatrix;

          if (isNotEqualResult) {
            Console.WriteLine("Первая  матрица не равна второй матрице.");
          } else {
            Console.WriteLine("Первая матрица равна, больше или меньше второй матрицы.");
          }
          break;
        case 9:
          Console.Write("Выберите матрицы, которую хотите преобразовать в тип int:" +
            "\nПервая матрица - 1\nВторая матрица -2\n Ваш выбор: ");
          int choiceMatrixConvertTo = Convert.ToInt32(Console.ReadLine());

          switch (choiceMatrixConvertTo) {
            case 1:
              int firstResultMatrix = (int)firstRandomSquareMatrix;
              Console.WriteLine("Преобразованная первая матрица" + firstResultMatrix);
              break;
            case 2:
              int secondResultMatrix = (int)secondRandomSquareMatrix;
              Console.WriteLine("Преобразованная вторая матрица" + secondResultMatrix);
              break;
          }
          break;
        case 10:
          Console.Write("Выберите матрицы, которую хотите проверить на существование:" +
            " \nПервая матрица - 1\nВторая матрица -2\n Ваш выбор: ");
          int choiceMatrixIsTrue = Convert.ToInt32(Console.ReadLine());

          switch (choiceMatrixIsTrue) {
            case 1:
              if (firstRandomSquareMatrix) {
                Console.WriteLine("Первая матрица существует!");
              } else {
                Console.WriteLine("Первая матрица не сущуствует!");
              }
              break;
            case 2:
              if (secondRandomSquareMatrix) {
                Console.WriteLine("Вторая матрица существует!");
              } else {
                Console.WriteLine("Вторая матрица не существует!");  
              }
              Console.WriteLine();
              break;
          }
        break;
        case 11:
          Console.Write("Выберите матрицы, которую хотите проверить на существование:" +
            " \nПервая матрица - 1\nВторая матрица -2\n Ваш выбор: ");
          int choiceMatrixIsFalse = Convert.ToInt32(Console.ReadLine());

          switch (choiceMatrixIsFalse) {
            case 1:
              if (firstRandomSquareMatrix) {
                Console.WriteLine("Первая матрица не существует!");
              } else {
                Console.WriteLine("Первая матрица существует!");
              }
              break;
            case 2:
              if (secondRandomSquareMatrix) {
                Console.WriteLine("Вторая матрица не существует!");
              } else {
                Console.WriteLine("Вторая матрица существует!");
              }
              Console.WriteLine();
              break;
          }
          break;
        case 12:
          Console.Write("Выберите матрицы, чью детерминанту, Вы хотите найти\nПервая " +
            "матрица - 1\nВторая матрица -2\n Ваш выбор: ");
          int choiceMatrixDeterminant = Convert.ToInt32(Console.ReadLine());

          switch (choiceMatrixDeterminant) {
            case 1:
              firstRandomSquareMatrix.GetDeterminant();
              break;
            case 2:
              secondRandomSquareMatrix.GetDeterminant();
              break;
          }
          break;
        case 13:
          Console.Write("Выберите матрицы, чью обратную матрицу вы хотите найти\nПервая" +
            " матрица - 1\nВторая матрица -2\n Ваш выбор: ");
          int choiceMatrixReverseMatrix = Convert.ToInt32(Console.ReadLine());

          switch (choiceMatrixReverseMatrix) {
            case 1:
              firstRandomSquareMatrix.GetInverseMatrix();
              break;
            case 2:
              secondRandomSquareMatrix.GetInverseMatrix();
              break;
          }
          break;
        default:
          Console.WriteLine("Некорректный ввод или несуществующий вариант!" +
            " Перезапустите программу!");
          break;
      } 

      Console.ReadKey();
    }
  }
}
