package com.company;

import java.util.concurrent.LinkedBlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicInteger;

public class Task2 {
    public static void main(String[] args) throws InterruptedException {
        ThreadPoolExecutor executor = new ThreadPoolExecutor(
                // не изменяйте эти параметры
                3, 3, 1, TimeUnit.SECONDS, new LinkedBlockingQueue<>(3));

        AtomicInteger count = new AtomicInteger(0);
        AtomicInteger inProgress = new AtomicInteger(0);

        for (int i = 0; i < 30; i++) {
            final int number = i;
            Thread.sleep(10);

            while (inProgress.get() >= 3)
                Thread.sleep(20);

            System.out.println("creating #" + number);
            executor.submit(() -> {
                int working = inProgress.incrementAndGet();
                System.out.println("start #" + number + ", in progress: " + working);
                try {Thread.sleep(Math.round(1000 + Math.random() * 2000));}
                catch (InterruptedException ignored) {}
                working = inProgress.decrementAndGet();
                System.out.println("end #" + number + ", in progress: " + working + ", done tasks: " + count.incrementAndGet());
            });
        }

        while (executor.getActiveCount() > 0)
            Thread.sleep(20);
        System.out.println("Done");
    }
}
