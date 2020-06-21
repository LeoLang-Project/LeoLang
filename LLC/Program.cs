using System;

namespace LLC
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true) {
                Console.Write("> ");
                var line = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(line)) {
                    return;
                }

            }
        }
    }
}
