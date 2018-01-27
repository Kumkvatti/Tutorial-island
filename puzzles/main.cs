using System;
using System.Collections;
using System.Collections.Generic;

public class PuzzleController
{

  class Guess {

     public Guess() {

     }
  }

  class Solution {
    private bool solved = false;
    private Stack solutionStack;
    private Stack temp;
    private int progress = 0;
    private int goal;

    public Solution (Stack solutionStack) {
      this.solutionStack = solutionStack;
      temp = solutionStack;
      goal = solutionStack.Count;
      System.Console.WriteLine("Created a solution with solutionStack [ {0} ].", string.Join(", ", solutionStack.ToArray()));
    }

    private void Solve (Stack guessStack) {
      while (guessStack.Count > 0) {
        if (solutionStack.Peek() == guessStack.Peek()) {
          solutionStack.Pop();
          guessStack.Pop();
          progress++;
        } else {
          solutionStack = temp;
          break;
        }
      }
      if (solutionStack.Count == 0)
        solved = true;
    }

    public void ForceSolve() {
      solved = true;
    }

    public bool IsSolved() {
      return solved;
    }

    public Tuple<int,int> Progress() {
      return new Tuple<int,int> (progress, goal);
    }

    public bool TrySolution(Stack guessStack) {
      Solve(guessStack);
      if (solved)
        return solved;
      else {
        Revert();
        return solved;
      }
    }

    public Tuple<bool,bool> AddToSolution(string Guess, bool Revertable = false) {
      Stack guessStack = new Stack();
      guessStack.Push(Guess);
      int tempProgress = progress;
      Solve(guessStack);
      if (tempProgress < progress)
        return new Tuple<bool,bool> (true, solved);
      else {
        if (Revertable)
          Revert();
        return new Tuple<bool,bool> (false, solved);
      }
    }

    public void Revert() {
      solutionStack = temp;
      progress = 0;
    }

  }


  class Puzzle {
    private Solution solution;
    private int tries = 0;


    public Puzzle (Solution solution) {
      this.solution = solution;
    }

    public Tuple<int,int> GetProgress () {
      return solution.Progress();
    }

    public Tuple<bool,bool> AddToSolution (string Guess) {
      return solution.AddToSolution(Guess);
    }
  }


    static public int Main (string[] args)
    {

      if (args.Length == 0) {
        System.Console.WriteLine("Please enter a solution.");
        return 1;
      }

      int i = args.Length-1;
      Stack solutionStack = new Stack ();
      while (i >= 0) {
        solutionStack.Push(args[i]);
        i--;
      }
      Solution solution = new Solution(solutionStack);
      Puzzle puzzle = new Puzzle(solution);

      return 0;
    }
}
