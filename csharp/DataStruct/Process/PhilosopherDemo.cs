using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using semaphore = System.Int32;


namespace DataStruct.Process
{

    /// <summary>
    /// 哲学家状态
    /// </summary>
    public enum StateEnum
    {
        // 思考状态
        THINKING = 0,
        // 饥饿状态
        HUNGRY = 1,
        // 吃饭状态
        EATING = 2
    }

    public static class PhilosopherDemo
    {
        private const int NumOfPhilosopher = 5; // 哲学家人数
        private static StateEnum[] states = new StateEnum[NumOfPhilosopher]; // 记录每个哲学家当前状态的数组
        private static semaphore mutex = 1; // 模拟互斥信号量
        private static semaphore[] s = new semaphore[NumOfPhilosopher]; // 每个哲学家等待一个单独的信号量

        /// <summary>
        /// 初始化哲学家状态
        /// </summary>
        private static void InitializePhilosopher()
        {
            for (int i = 0; i < NumOfPhilosopher; i++)
            {
                states[i] = StateEnum.THINKING;
                s[i] = 1;
            }
        }

        /// <summary>
        /// 哲学家程序
        /// </summary>
        /// <param name="philosopher">哲学家编号</param>
        private static void PhilosopherRoutine(object number)
        {
            int philosopher = (semaphore)number;
            while (true)
            {
                Think(philosopher);
                TakeChopsticks(philosopher);    // 同时获得两根筷子，否则阻塞等待
                Eat(philosopher);
                PutChopsticks(philosopher);     // 同时放下两根筷子
            }
        }

        /// <summary>
        /// 获取筷子
        /// </summary>
        /// <param name="philosoper">哲学家编号</param>
        private static void TakeChopsticks(int philosopher)
        {
            Down(mutex);

            states[philosopher] = StateEnum.HUNGRY;
            Test(philosopher);  // 试图拿起两根筷子
            Up(mutex);

            Down(ref s[philosopher]);    // 如果没有拿到筷子，则继续阻塞等待
        }

        /// <summary>
        /// 放下筷子
        /// </summary>
        /// <param name="philosoper">哲学家编号</param>
        private static void PutChopsticks(int philosopher)
        {
            Down(mutex);

            states[philosopher] = StateEnum.THINKING;
            int right = (philosopher + NumOfPhilosopher - 1) % NumOfPhilosopher;
            int left = (philosopher + 1) % NumOfPhilosopher;
            // 测试左面的哲学家是否可以吃饭
            Test(left);
            // 测试右面的哲学家是否可以吃饭
            Test(right);

            Up(mutex);
        }

        /// <summary>
        /// 测试是否可以同时拿起两根筷子
        /// </summary>
        /// <param name="philosopher">哲学家编号</param>
        private static void Test(int philosopher)
        {
            int right = (philosopher + NumOfPhilosopher - 1) % NumOfPhilosopher;
            int left = (philosopher + 1) % NumOfPhilosopher;

            if (states[philosopher] == StateEnum.HUNGRY && states[left] != StateEnum.EATING &&
                states[right] != StateEnum.EATING)
            {
                // 可以拿起两根筷子，改变哲学家状态到吃饭状态
                states[philosopher] = StateEnum.EATING;
                // 发出叫醒信号
                Up(ref s[philosopher]);
            }
        }

        /// <summary>
        /// 思考
        /// </summary>
        /// <param name="philosoper">哲学家编号</param>
        private static void Think(int philosopher)
        {
            Console.WriteLine("Philosopher:{0} IS THINKING.", philosopher + 1);
            System.Diagnostics.Debug.WriteLine("Philosopher:{0} IS THINKING.", philosopher + 1);
        }

        /// <summary>
        /// 吃饭
        /// </summary>
        /// <param name="philosoper">哲学家编号</param>
        private static void Eat(int philosopher)
        {
            Console.WriteLine("Philosopher:{0} IS EATING.", philosopher + 1);
            System.Diagnostics.Debug.WriteLine("Philosopher:{0} IS EATING.", philosopher + 1);
        }

        /// <summary>
        /// 互斥信号量Down
        /// </summary>
        private static void Down(semaphore mutex)
        {
            if (mutex == 1)
            {
                mutex--;
            }
        }

        /// <summary>
        /// 互斥信号量Down
        /// </summary>
        private static void Down(ref semaphore mutex)
        {
            // 阻塞操作
            while (mutex < 1) { }
        }

        /// <summary>
        /// 互斥信号量Up
        /// </summary>
        private static void Up(semaphore mutex)
        {
            if (mutex == 0)
            {
                mutex++;
            }
        }

        /// <summary>
        /// 互斥信号量Up
        /// </summary>
        private static void Up(ref semaphore mutex)
        {
            if (mutex == 0)
            {
                mutex++;
            }
        }


        public static void startprocess()
        {
            InitializePhilosopher();

            for (int i = 0; i < NumOfPhilosopher; i++)
            {
                Thread thread = new Thread(PhilosopherRoutine);
                thread.Start(i);
            }

            Console.ReadKey();
        }
    }

}