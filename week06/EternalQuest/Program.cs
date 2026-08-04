using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity Added:
         * ----------------------------------------------------------
         * This program exceeds the core requirements by implementing
         * a Level System based on the user's total score.
         *
         * Levels:
         * - Novice
         * - Beginner
         * - Explorer
         * - Champion
         * - Goal Master
         *
         * As the user earns more points, their level automatically
         * increases and is displayed in the main menu.
         *
         * This adds a gamification element to encourage users to
         * continue accomplishing goals.
         */

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}