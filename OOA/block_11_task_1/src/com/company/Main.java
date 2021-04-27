package com.company;

public class Main {
    static int count = 0;

    static class LuckyThread extends Thread {
        @Override
        public void run() {
            while (LuckyCounterState.getX() < 999999)
                LuckyCounterState.iterate();
        }
    }

    private static class LuckyCounterState {
        private static int x;

        static synchronized void iterate() {
            x++;
            if ((x % 10) + (x / 10) % 10 + (x / 100) % 10 != (x / 1000) % 10 + (x / 10000) % 10 + (x / 100000) % 10 ||
                x > 999999)
                return;
            System.out.println(x);
            count++;
        }

        static synchronized int getX() {
            return x;
        }
    }

    public static void main(String[] args) throws InterruptedException {
        Thread t1 = new LuckyThread();
        Thread t2 = new LuckyThread();
        Thread t3 = new LuckyThread();
        t1.start();
        t2.start();
        t3.start();
        t1.join();
        t2.join();
        t3.join();
        System.out.println("Total: " + count);
    }
}
