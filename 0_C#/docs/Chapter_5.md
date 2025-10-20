## C#의 심화 문법
### 일반화 프로그래밍 Generic Programming
#### 형식 매개변수 T 등을 사용해 형식에 의존하지 않는 코드를 작성
즉, 데이터 타입 일반화를 이용하는 프로그래밍 <T>(type T[])

자료구조/알고리즘을 한 번만 구현하고, 다양한 형식으로 형식 안전하게 재사용

```C#
// 제네릭 클래스
public class MyList<T> { /* ... */ }

// 제네릭 메서드
public static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;

// 제네릭 인터페이스
public interface IRepository<T> { T GetById(int id); void Add(T entity); }

// 제네릭 델리게이트
public delegate TResult Func2<T1, TResult>(T1 arg);
```

#### 제약조건
| 제약 구문                  | 설명                                   | 사용 예                                     |
| ---------------------- | ------------------------------------ | ---------------------------------------- |
| `where T : struct`     | **값 형식**만 허용(Nullable 제외).           | `struct`(int, double, DateTime 등) 대상 API |
| `where T : class`      | **참조 형식**만 허용(널 허용성은 컴파일러 설정에 따름).   | 엔티티/레퍼런스 전용 컨테이너                         |
| `where T : class?`     | nullable 참조 형식 허용(C# 8+).            | null 허용 모델                               |
| `where T : notnull`    | null 불가(값 형식 또는 non-nullable 참조).    | 키/사전의 키 제약                               |
| `where T : unmanaged`  | 포인터 연산 가능한 **비관리 값 형식**만.            | 고성능 버퍼/Interop                           |
| `where T : new()`      | 매개변수 없는 **기본 생성자** 필요.               | 팩터리/리플렉션 없이 인스턴스 생성                      |
| `where T : BaseClass`  | **지정한 기반 클래스**의 파생형만.                | 공통 베이스 API 요구                            |
| `where T : IInterface` | **지정 인터페이스**(여러 개 가능)를 구현해야 함.       | 비교/열거/직렬화 기능 요구                          |
| `where T : U`          | `T`가 다른 형식 매개변수 `U`의 **파생/구현**이어야 함. | 두 타입 매개변수 간 관계 고정                        |
| `where T : Enum`       | 열거형만(C# 7.3+).                       | 안전한 enum 처리/파싱                           |
| `where T : Delegate`   | 델리게이트만(C# 7.3+).                     | 콜백/표현식 래핑                                |

### 예외 처리 Exception Handling
```C#
try
{
    DoSomething();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finaly
{
    // 예외가 발생하든 발생하지 않든 발생할 코드
}
```

### 대리자 delegate / 이벤트 Event
#### 대리자
- 메서드를 변수처럼 다루기 위한 타입 안전한 포인터
    - 코드 실행 흐름을 동적으로 연결 (콜백, 전략 패턴, 이벤트 전달 등)

```C#
// ① 대리자 선언
public delegate void NotifyHandler(string msg);

// ② 대리자 변수 생성
NotifyHandler handler = ShowMessage;

// ③ 메서드 연결
void ShowMessage(string msg) => Console.WriteLine($"Message: {msg}");

// ④ 호출
handler("Hello Delegate!");
```

#### 익명 메소드 Anonymous Method
- 다른 코드 블록에서 재사용될 일이 없는 메소드
- 익명 메소드 구현 절차
    - 사전 정의된 대리자 형식
```C#
Calc = delegate(int a, int b)
        { 
            return a + b; 
        }
```

#### 이벤트
- 대리자를 기반으로, 특정 객체 상태 변화를 다른 객체에 알리는 메커니즘
    - Publisher(발생자)와 Subscriber(수신자)의 결합을 약화
```C#
public class Button
{
    // 이벤트 선언
    public event EventHandler? Click;

    // 이벤트 발생 함수
    public void OnClick()
    {
        Console.WriteLine("Button clicked!");
        Click?.Invoke(this, EventArgs.Empty); // null-safe 호출
    }
}
```

### 람다식 Lambda Expression
- 식 람다 : ```(매개변수) => 식```
- 문 람다 : ```(매개변수) => { 문장; 문장; 문장; }```
- Func대리자 : 값을 반환하는 메서드를 참조
- Action 대리자 : 값을 반환하지 않는 (즉, 반환 형식이 **void**인) 메서드를 참조
- 식 트리 : 코드(람다식)를 트리 형태의 데이터 구조로 표현
```C#
// Func
Func<int> f0;                 // () -> int
Func<string, int> f1;         // (string) -> int
Func<int, int, bool> f2;      // (int,int) -> bool
Func<Task> fAsync0;           // () -> Task
Func<string, Task> fAsync1;   // (string) -> Task

// Action
Action a0;                    // () -> void
Action<string> a1;            // (string) -> void
Action<int,int> a2;           // (int,int) -> void

// Expression Tree
ParameterExpression x = Expression.Parameter(typeof(int), "x");
ConstantExpression c2 = Expression.Constant(2);
BinaryExpression body = Expression.Add(Expression.Multiply(x, x), c2);
Expression<Func<int, int>> expr = Expression.Lambda<Func<int, int>>(body, x);

Console.WriteLine(expr);  // 출력: x => ((x * x) + 2)
```

### LINQ, Language-Integrated Query

- 구성요소
    - From : 어떤 데이터 집합에서
    - Where : 어떤 조건으로
    - Select : 어떤 항목을
``` C#
// SQL 스타일
var result = from n in numbers
             where n % 2 == 0
             orderby n descending
             select n;
// Method 스타일
var result = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .Select(n => n);
```
### Reflection / Attribute

### dynamic

### File Input/Output