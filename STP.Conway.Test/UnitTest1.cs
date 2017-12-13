using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;

namespace STP.Conway.Test
{
  [TestClass]
  public class UnitTest1
  {

   
    public UnitTest1()
    {
    
    }
    /// <summary>
    ///  WORK IN PROGRESS
    /// </summary>
    [TestMethod]
    public void KilLLiveCellWithNoLiveNeighbors()
    {
      List<List<int>> input = new List<List<int>>();  
      List<List<int>> expectedOutput = new List<List<int>>();
      List<int> row = new List<int> { 0, 0, 0 };
      List<int> row1 = new List<int> { 0, 1, 0 };

      //INPUT
      // create a 3x3 grid
      input.Add(row);       // 0 0 0 
      input.Add(row);      // 0 1 0 
      input.Add(row);       // 0 0 0 

      // OUTPUT
      // create a 3x3 grid
      expectedOutput.Add(row);       // 0 0 0 
      expectedOutput.Add(row);      // 0 0 0 
      expectedOutput.Add(row);       // 0 0 0 

      var p = new Prototype(input);

      //input = p.ApplyRules(); 

      NUnit.Framework.Assert.AreEqual(expectedOutput, input );
    }
  }
}
