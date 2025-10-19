## Data types
- 기본 데이터 형식
| 구분  | 형식명 (C# 키워드) | .NET 형식명       | 크기 (byte) | 범위                                                     | 설명               |
| --- | ------------ | -------------- | --------- | ------------------------------------------------------ | ---------------- |
| 정수형 | `sbyte`      | System.SByte   | 1         | -128 ~ 127                                             | 부호 있는 8비트 정수     |
| 정수형 | `byte`       | System.Byte    | 1         | 0 ~ 255                                                | 부호 없는 8비트 정수     |
| 정수형 | `short`      | System.Int16   | 2         | -32,768 ~ 32,767                                       | 부호 있는 16비트 정수    |
| 정수형 | `ushort`     | System.UInt16  | 2         | 0 ~ 65,535                                             | 부호 없는 16비트 정수    |
| 정수형 | `int`        | System.Int32   | 4         | -2,147,483,648 ~ 2,147,483,647                         | 가장 많이 쓰이는 기본 정수  |
| 정수형 | `uint`       | System.UInt32  | 4         | 0 ~ 4,294,967,295                                      | 부호 없는 32비트 정수    |
| 정수형 | `long`       | System.Int64   | 8         | -9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807 | 64비트 정수          |
| 정수형 | `ulong`      | System.UInt64  | 8         | 0 ~ 18,446,744,073,709,551,615                         | 부호 없는 64비트 정수    |
| 실수형 | `float`      | System.Single  | 4         | ±1.5×10⁻⁴⁵ ~ ±3.4×10³⁸                                 | 단정밀도 부동소수점       |
| 실수형 | `double`     | System.Double  | 8         | ±5.0×10⁻³²⁴ ~ ±1.7×10³⁰⁸                               | 배정밀도 부동소수점       |
| 실수형 | `decimal`    | System.Decimal | 16        | ±1.0×10⁻²⁸ ~ ±7.9×10²⁸                                 | 고정소수점, 금액/정밀 계산용 |
| 문자형 | `char`       | System.Char    | 2         | U+0000 ~ U+FFFF                                        | 유니코드 문자 한 개      |
| 논리형 | `bool`       | System.Boolean | 1         | true / false                                           | 논리 값             |
| 문자열 | `string`     | System.String  | 가변        | -                                                      | 문자들의 연속, 참조형     |
| 객체형 | `object`     | System.Object  | -         | -                                                      | 모든 형식의 최상위 형식    |

- 복합 데이터 형식
| 구분          | 형식명                                  | 키워드 / 예시                                      | 설명                           |
| ----------- | ------------------------------------ | --------------------------------------------- | ---------------------------- |
| 구조체         | `struct`                             | `struct Point { int x; int y; }`              | 값 형식(Value Type), 스택에 저장     |
| 클래스         | `class`                              | `class Car { ... }`                           | 참조 형식(Reference Type), 힙에 저장 |
| 배열          | `Array`                              | `int[] nums = new int[5];`                    | 동일한 형식의 데이터 집합               |
| 열거형         | `enum`                               | `enum Direction { North, South, East, West }` | 상수 집합 정의                     |
| 인터페이스       | `interface`                          | `interface IDrawable { void Draw(); }`        | 메소드 약속(규약) 정의                |
| 대리자         | `delegate`                           | `delegate void Notify(string msg);`           | 메소드를 참조하는 형식                 |
| 튜플          | `Tuple`, `(T1, T2, …)`               | `(int id, string name) = (1, "Alice");`       | 여러 값을 하나의 묶음으로 반환            |
| 레코드         | `record`                             | `record Person(string Name, int Age);`        | 불변 데이터 객체용 클래스               |
| Nullable 형식 | `Nullable<T>`                        | `int? x = null;`                              | 값 형식에 null 허용                |
| 동적 형식       | `dynamic`                            | `dynamic data = 10;`                          | 런타임 시 형식 결정                  |
| 컬렉션         | `List<T>`, `Dictionary<TKey,TValue>` | `List<int> list = new();`                     | 가변 크기 데이터 컨테이너               |
