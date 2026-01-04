## Data Format & Operator
### Value Type
- int, float, bool, struct -> 값 형식
    - 메모리에 값을 담는 데이터 형식
    - 값 자체를 저장 (Stack 메모리)
    - 대입 시 값을 복사
- object, string, class -> 참조 형식
    - 메모리에 다른 변수의 주소를 담는 데이터 형식
    - 힙에 객체를 만들고, 변수는 그 주소를 참조 (Heap 메모리)
    - 대입 시 주소가 복사됨

```cs
int a = 20;
int b = a;
a = 99;
// -> a를 변경해도 b의 값은 유지
object o = 20;
object c = o;
o = 99;
// -> 새 object 생성, 이제 o != c
Box x = new Box();
x.Value = 10;
Box y = x;  // 참조 복사 (같은 Heap 객체)
y.Value = 99;
// x와 y는 동일한 객체를 가리키고 있으므로 x.Value == y.Value
```

## Data types
### 기본 데이터 형식 (Primitive Types)
| 구분 | 형식명 (C# 키워드) | .NET 형식명 | 크기 (byte) | 범위 | 설명 |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **논리형** | **bool** | System.Boolean | 1 | true / false | 논리형 값 |
| **정수형** | **sbyte** | System.SByte | 1 | -128 ~ 127 | 부호 있는 8비트 정수 |
| **정수형** | **byte** | System.Byte | 1 | 0 ~ 255 | 부호 없는 8비트 정수 |
| **정수형** | **short** | System.Int16 | 2 | -32,768 ~ 32,767 | 부호 있는 16비트 정수 |
| **정수형** | **ushort** | System.UInt16 | 2 | 0 ~ 65,535 | 부호 없는 16비트 정수 |
| **정수형** | **int** | System.Int32 | 4 | -2,147,483,648 ~ 2,147,483,647 | 가장 많이 쓰이는 기본 정수 |
| **정수형** | **uint** | System.UInt32 | 4 | 0 ~ 4,294,967,295 | 부호 없는 32비트 정수 |
| **정수형** | **long** | System.Int64 | 8 | -9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807 | 64비트 정수 |
| **정수형** | **ulong** | System.UInt64 | 8 | 0 ~ 18,446,744,073,709,551,615 | 부호 없는 64비트 정수 |
| **실수형** | **float** | System.Single | 4 | ±1.5×10⁻⁴⁵ ~ ±3.4×10³⁸ | 단정밀도 부동소수점 |
| **실수형** | **double** | System.Double | 8 | ±5.0×10⁻³²⁴ ~ ±1.7×10³⁰⁸ | 배정밀도 부동소수점 |
| **실수형** | **decimal** | System.Decimal | 16 | ±1.0×10⁻²⁸ ~ ±7.9×10²⁸ | 고정소수점, 금액·정밀 계산용 |
| **문자형** | **char** | System.Char | 2 | U+0000 ~ U+FFFF | 유니코드 문자 한 개 |
| **논리형** | **bool** | System.Boolean | 1 | true / false | 논리 값 |
| **문자열** | **string** | System.String | 가변 | - | 문자들의 연속 (**참조형**) |
| **객체형** | **object** | System.Object | - | - | 모든 형식의 최상위 형식 (**참조형**) |

-> object 형식은 모든 데이터 형식을 담아 처리 가능

### 복합 데이터 형식 (Composite Types)
| 구분 | 형식명 | 키워드 / 예시 | 설명 |
| :--- | :--- | :--- | :--- |
| **구조체** | **struct** | `struct Point { int x; int y; }` | 값 형식(Value Type), 스택에 저장 |
| **클래스** | **class** | `class Car { ... }` | 참조 형식(Reference Type), 힙에 저장 |
| **배열** | **Array** | `int[] nums = new int[5];` | 동일한 형식의 데이터 집합 |
| **열거형** | **enum** | `enum Direction { North, South, East, West }` | 상수 집합 정의 |
| **인터페이스** | **interface** | `interface IDrawable { void Draw(); }` | 메서드 규약 정의 |
| **대리자** | **delegate** | `delegate void Notify(string msg);` | 메서드를 참조하는 형식 |
| **튜플** | **Tuple**, `(T1, T2, …)` | `(int id, string name) = (1, "Alice");` | 여러 값을 하나로 묶은 형식 |
| **레코드** | **record** | `record Person(string Name, int Age);` | 불변 데이터 객체용 클래스 |
| **Nullable 형식** | **Nullable<T>** | `int? x = null;` | 값 형식에 null 허용 |
| **동적 형식** | **dynamic** | `dynamic data = 10;` | 런타임 시 형식 결정 |
| **컬렉션** | **List<T>**, **Dictionary<TKey, TValue>** | `List<int> list = new();` | 가변 크기 데이터 컨테이너 |

## 형변환


## Boxing vs Unboxing
### Boxing : 값을 참조 형식으로 변환
- 값 형식을 object 형식에 담아 참조 형식으로 변환
    - 데이터를 Heap 메모리에 저장
    - object o = a;

### Unboxing : 참조를 값 형식으로 변환
- 참조 형식에 있는 데이터(Heap)를 object에서 꺼내 값 형식으로 변환
    - 데이터를 Stack 메모리에 저장
    - int c = (int)o;

```
int a = 20;

// 값 형식끼리 값 복사
int b = a;

// Boxing: 값 형식(int) -> 참조 형식(object). 힙에 새 박스(20)가 만들어짐.
object o = a;

a = 99;                     // 원본 변경
Console.WriteLine(o);       // 20 (독립적인 복사본)

// Unboxing: object -> int (명시적 캐스팅 필요)
int b = (int)o;
Console.WriteLine(b);       // 20
```

## 상수, 열거형, 형식 추론
- 상수 const : 변하지 않는 값
    - const int MAX_INT_BIT = 32;
- 열거형 enum : 하나의 이름 아래 묶은 상수들의 집합
    - enum DialogResult { YES, NO, CANCEL }
    - YES == 0, NO == 1, CANCEL == 2
- 형식 추론 var : 컴파일러가 리터럴을 분석하여 자동으로 형식을 추론
    - var a = 3; // 지역변수에서만 사용 가능

## 연산자
| 구분 | 연산자 | 예시 | 설명 |
| :--- | :--- | :--- | :--- |
| 산술(이항) | `+  -  *  /  %` | `a+b`, `a-b`, `a*b`, `a/b`, `a%b` | 기본 산술 연산 |
| 산술(단항) | `+  -  ++  --` | `+a`, `-a`, `a++`, `--a` | 부호, 증가/감소 |
| 할당 | `=` | `x = y` | 대입 |
| 복합 할당 | `+=  -=  *=  /=  %=  &=  \|=  ^=  <<=  >>=` | `x += 3`, `x <<= 1` | 연산 + 대입 |
| **null 병합(대입)** | `??  ??=` | `x = a ?? b`, `x ??= y` | null이면 대체/대입 |
| 비교 | `==  !=  <  >  <=  >=` | `a==b`, `a<=b` | 값/순서 비교 |
| 논리(조건부) | `&&  \|\|  !` | `a && b`, `!flag` | 단락 평가 AND/OR/NOT |
| 비트 | `&  \|  ^  ~` | `a & b`, `~a` | 비트 AND/OR/XOR/NOT |
| 시프트 | `<<  >>` | `a << 2`, `b >> 1` | 비트 이동 |
| 조건 | `?:` | `cond ? x : y` | 삼항 조건 |
| 멤버/호출 | `.  ()  []` | `obj.M()`, `arr[i]` | 멤버 접근/호출/인덱서 |
| **null 조건부** | `?.  ?[]` | `obj?.M()`, `arr? [i]` | null이면 호출/인덱싱 건너뜀 |
| **null 무시(후위)** | `!` | `s!` | 컴파일러에 null 아님 단언 |
| 형변환 | `(T)` | `(int) x` | 명시적 캐스트 |
| 타입 검사 | `is` | `x is int` | 타입/패턴 검사 |
| 안전 캐스트 | `as` | `x as string` | 실패 시 `null` 반환 |
| 정보 | `typeof  nameof  sizeof` | `typeof(int)`, `nameof(User)` | 형식/이름/크기 |
| 기타 키워드 | `new  default  checked  unchecked  stackalloc  await` | `new T()`, `default(T)` | 객체 생성/기본값/오버플로우 검사/스택 메모리/비동기 |
| 인덱스/범위 | `^  ..` | `arr[^1]`, `arr[1..^1]` | 끝에서 인덱스, 범위 슬라이스 |
| 람다 | `=>` | `(x) => x*x` | 람다 식/식 본문 멤버 |