package com.company;

import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> result = SolutionGenerator.filterWith(100.0,SolutionGenerator.getAllVariants());

        for (String str: result) {
            System.out.println(str + " = 100");
        }

        System.out.println("-----------");
        System.out.println("Found " + result.size() + " solutions");
    }
}
