## 배열과 컬랙션, 인덱서

| 구분         | 배열 (Array)   | 컬렉션 (Collection) | 인덱서 (Indexer)  |
| ---------- | ------------ | ---------------- | -------------- |
| **기본 개념**  | 고정 크기 데이터 저장 | 동적 크기 데이터 저장     | 객체 내부를 배열처럼 접근 |
| **타입 제약**  | 동일 타입만 가능    | 제네릭으로 타입 지정      | 클래스 내부에 종속     |
| **메모리 구조** | 연속적 메모리      | 내부적으로 동적 할당      | 내부 구조에 따라 다름   |
| **속도**     | 빠름 (고정 크기)   | 약간 느림 (유연성 대가)   | 내부 구현에 따라 다름   |
| **사용 예시**  | 센서값 배열, 버퍼   | 학생 리스트, 로그 사전    | 사용자 정의 컨테이너    |
| **장점**     | 빠르고 단순       | 유연하고 강력          | 직관적 접근         |
| **단점**     | 크기 변경 불가     | 약간의 오버헤드         | 구현 필요          |


```C#
// Array 배열 : 동일한 자료형의 데이터를 연속된 메모리 공간에 저장 (고정된 크기)
int[] nums = new int[3] {1, 2, 3};
string[] names = {"Lee", "Kim", "Park"};

// ArrayList : List<T>의 하위호환
ArrayList list = new ArrayList();
list.Add(1);
list.Add("Hello");
list.Add(3.14);

// Collection : 가변 길이 데이터 구조 (동적 관리)
// List<T> — 순차 리스트
var nums = new List<int>();
nums.Add(1);
nums.Add(3);
nums.Add(2);
nums.Sort();                 // 1,2,3
nums.Remove(2);              // 1,3
Console.WriteLine("[List<T>]");
foreach (var n in nums) Console.Write($"{n} ");   // 출력: 1 3
Console.WriteLine("\n");

// Hashtable — Key-Value (비제네릭)
Hashtable ht = new Hashtable();
ht.Add("name", "Lee");
ht["age"] = 29;               // 인덱서로 추가/갱신
Console.WriteLine(ht["name"]); // "Lee"
Console.WriteLine(ht.ContainsKey("age")); // True
Console.WriteLine(ht.Contains("age"));    // True (구버전 호환용)

// Dictionary<TKey, TValue> — Key-Value
var dict = new Dictionary<string, string>();
dict.Add("name", "Lee");
dict["city"] = "Seoul";      // 인덱서로 추가/갱신
Console.WriteLine("[Dictionary<TKey,TValue>]");
Console.WriteLine(dict["name"]);                  // 출력: Lee
Console.WriteLine(dict.ContainsKey("city"));      // 출력: True
dict.Remove("city");
Console.WriteLine(dict.ContainsKey("city"));      // 출력: False
Console.WriteLine();

// Queue<T> — FIFO
var queue = new Queue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
Console.WriteLine("[Queue<T>]");
Console.WriteLine(queue.Peek());  // 다음에 나올 값 확인: 10
Console.WriteLine(queue.Dequeue()); // 10 제거/반환
Console.WriteLine(queue.Dequeue()); // 20 제거/반환
Console.WriteLine(queue.Count);   // 0
Console.WriteLine();

// Stack<T> — LIFO
var stack = new Stack<string>();
stack.Push("first");
stack.Push("second");
Console.WriteLine("[Stack<T>]");
Console.WriteLine(stack.Peek());   // top 확인: second
Console.WriteLine(stack.Pop());    // second
Console.WriteLine(stack.Pop());    // first
Console.WriteLine(stack.Count);    // 0

// Indexer : 클래스나 구조체가 배열처럼 인덱스로 접근될 수 있게 하는 문법적 장치
class MyCollection
{
    private int[] data = new int[3];
    public int this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}

MyCollection c = new MyCollection();
c[0] = 100;           // set 호출
Console.WriteLine(c[0]); // get 호출
```

#### Collection : 가변 길이 데이터 구조 (동적 관리)
| 타입                        | 구조        | 주요 메서드                               | 예시                                     |
| ------------------------- | --------- | ------------------------------------ | -------------------------------------- |
| `List<T>`                 | 순차 리스트    | `Add()`, `Remove()`, `Sort()`        | `List<int> nums = new(); nums.Add(1);` |
| `Dictionary<TKey,TValue>` | Key-Value | `Add()`, `ContainsKey()`, `Remove()` | `dict["name"] = "Lee";`                |
| `Queue<T>`                | FIFO      | `Enqueue()`, `Dequeue()`             | `queue.Enqueue(1);`                    |
| `Stack<T>`                | LIFO      | `Push()`, `Pop()`                    | `stack.Push(1);`                       |

