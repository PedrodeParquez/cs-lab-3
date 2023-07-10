using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {
  public class PrototypeSquareMatrix : SquareMatrix, ICloneable {
    public PrototypeSquareMatrix(int matrixSize, int minValue,
      int maxValue) : base(matrixSize, minValue, maxValue) { }
    
    public object Clone() {
      PrototypeSquareMatrix Result = new PrototypeSquareMatrix(matrixSize, minValue, maxValue);

      Result.squareMatrix = this.squareMatrix;
      Result.matrixSize = this.matrixSize;
      Result.minValue = this.minValue;
      Result.maxValue = this.maxValue;  

      return Result;
    }
  }
}

