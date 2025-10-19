using System;   // namespace import -> .NET 기본 클래스를 가져옴 (Console 등 사용 가능)

namespace Basic_Notes    // namespace 선언 -> 코드 조직화 및 충돌 방지
{
    class Program   // 클래스 선언 -> 프로그램의 진입점 역할
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : Hello.exe <이름>");
                return;
            }
            Console.WriteLine("Hello, {0}!", args[0]);
        }
    }
}