﻿namespace GPA_Calculator.Calculate_GPA
{
    public class GPACalcutor
    {

        public double Calculator(List<StudentGrade> studentGrade)
        {
            if(studentGrade.Count == 0) 
            {
              return 0.0;
            }
            var SumCredits = studentGrade.Sum(g => g.Credits);
            var gpaCredits = 0.0;
            foreach(var STgrade in studentGrade)
            {
                var GP = CalculeGp(STgrade.Score);
                gpaCredits += GP * STgrade.Credits;
            }

            return gpaCredits/SumCredits;
        }
    

    
     private double CalculeGp(int score)
    {
        if (score < 50) return 0;
        if (score <= 60) return 0.5;
        if (score <= 70) return 1.0;
        if (score <= 80) return 2.0;
        if (score <= 90) return 3.0;
        return 4.0;
    }
    
    }

   
}
