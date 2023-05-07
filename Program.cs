  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {
  internal class Program {
    static void Main() {
      int firstMatrixSize, firstMinNumber, firstMaxNumber, secondMatrixSize, secondMinNumber, secondMaxNumber;
        
      Console.Write("Введите размер первой квадратичной матрицы: ");
      firstMatrixSize = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите минимальное число первой матрицы: ");
      firstMinNumber = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите максимальное число первой матрицы: ");
      firstMaxNumber = Convert.ToInt32(Console.ReadLine());

      if (firstMinNumber > firstMaxNumber) {
        throw new ArgumentException("Переменная minNumber должно быть меньше или равно maxNumber");
      }

      Console.Write("Введите размер второй квадратичной матрицы: ");
      secondMatrixSize = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите минимальное число второй матрицы: ");
      secondMinNumber = Convert.ToInt32(Console.ReadLine());

      Console.Write("Введите максимальное число второй матрицы: ");
      secondMaxNumber = Convert.ToInt32(Console.ReadLine());
        
      if (secondMinNumber > secondMaxNumber) {
        throw new ArgumentException("Переменная minNumber должно быть меньше или равно maxNumber");
      }

      /* Создание первой квадратной матрицы с опеределённым размером и заполнение
      случайными значениями от минимального до максимального числа*/
      SquareMatrix firstRandomSquareMatrix = new SquareMatrix(firstMatrixSize, firstMinNumber, firstMaxNumber);
         
      Console.WriteLine("Первая квадратная матрица со случайными значениями");
      firstRandomSquareMatrix.PrintMatrix();

      /* Создание первой квадратной матрицы с опеределённым размером и заполнение
      случайными значениями от минимального до максимального числа*/
      SquareMatrix secondRandomSquareMatrix = new SquareMatrix(secondMatrixSize, secondMinNumber, secondMaxNumber);

      Console.WriteLine("Первая квадратная матрица со случайными значениями");
      secondRandomSquareMatrix.PrintMatrix();
      Console.ReadKey();
    }
  }
}
