package com.company;

import java.util.Arrays;
import java.util.Stack;

public class RowProcessor {
    private final String row;
    private final Stack<Double> operands = new Stack<>();
    private final Stack<Character> operators = new Stack<>();

    public RowProcessor(String row) {
        this.row = row;
    }

    public double calculate() {
        StringBuilder operand = new StringBuilder();
        for (char c : row.toCharArray()) {
            if (Character.isDigit(c))
                operand.append(c);
            else {
                operands.push(Double.parseDouble(operand.toString()));
                operand = new StringBuilder();
                if (!operators.isEmpty() && opHasHigherOrSamePriority(operators.peek(), c))
                    processTopOperator();
                operators.push(c);
            }
        }
        operands.push(Double.parseDouble(operand.toString()));
        while (!operators.isEmpty())
            processTopOperator();
        return operands.pop();
    }

    private void processTopOperator() {
        switch (operators.pop()) {
            case '+' -> operands.push(operands.pop() + operands.pop());
            case '-' -> operands.push(-1 * (operands.pop() - operands.pop()));
            case '*' -> operands.push(operands.pop() * operands.pop());
            case '/' -> operands.push(1 / operands.pop() * operands.pop());
        }
    }

    private static boolean opHasHigherOrSamePriority(char c1, char c2) {
        return Arrays.asList("*", "/").contains(Character.toString(c1)) || !Arrays.asList("*", "/").contains(Character.toString(c2));
    }
}
