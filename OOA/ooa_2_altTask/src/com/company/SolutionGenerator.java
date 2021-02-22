package com.company;

import java.util.ArrayList;

public class SolutionGenerator {
    public static ArrayList<String> getAllVariants() {
        ArrayList<String> result = new ArrayList<>();
        doRecursion(8, "9", result);
        return result;
    }

    public static ArrayList<String> filterWith(double expectedResult, ArrayList<String> rows) {
        ArrayList<String> result = new ArrayList<>();
        for (String row : rows)
            if (Math.abs(new RowProcessor(row).calculate() - expectedResult) < 1e-5)
                result.add(row);
        return result;
    }

    private static void doRecursion(int curOperand, String row, ArrayList<String> result) {
        if (curOperand == 1)
            result.add(row);
        else
            for (int i=0; i<5; i++)
                switch (i) {
                    case 0 -> doRecursion(curOperand - 1, row + curOperand, result);
                    case 1 -> doRecursion(curOperand - 1, row + "+" + curOperand, result);
                    case 2 -> doRecursion(curOperand - 1, row + "-" + curOperand, result);
                    case 3 -> doRecursion(curOperand - 1, row + "*" + curOperand, result);
                    case 4 -> doRecursion(curOperand - 1, row + "/" + curOperand, result);
                }
    }
}
