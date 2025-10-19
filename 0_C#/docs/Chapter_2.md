## 흐름 제어 Flow of Control & 함수 Method
#### 코드 실행 순서를 결정하는 것

### 조건문 (if, switch)
#### if else 문
```
Console.WriteLine("A");

if ( 조건1 )
    Console.WriteLine("B1");
else if ( 조건2 )
    Console.WriteLine("B2");
else
    Console.WriteLine("B3");

Console.WriteLine("C");
```

#### switch 문
```
Console.WriteLine("A");

switch ( ch )
{
    case B1:
        Console.WriteLine("B1");
        break;
    case B2:
        Console.WriteLine("B2");
        break;
    default:
        Console.WriteLine("B3");
}
```

#### switch 식
```
string grade = score switch
{
    90 => "A",
    80 => "B",
    70 => "C",
    60 => "D",
    _  => "F"
};
```

### 반복문 (while, for, )
#### while 문
```
while ( 조건1 )
{
    Console.WriteLine("참이면 계속 동작");
}
```

#### do ~ while 문
```
do {
    Console.WiteLine("코드 실행 후");
    Console.WiteLine("조건을 평가하여 반복 수행");
} while ( 조건1 )
```

#### for 문
```
for (int i = 1; i < 10, i++)
{
    Console.WriteLine("조건을 만족하는 동안 반복");
}
```

#### foreach 문
```
foreach (element in iterable-item)
{
    // body
}
```
```
foreach (int elem in arr)
{
    // 배열 arr의 각 원소만큼 반복
}
```

#### Jump 문
- break : 반복문이나 switch 문의 실행을 중단
- continue : 반복을 건너 뛰어 수행 다음 반복을 수행
- goto : 지정한 레이블로 제어를 이동 ```goto label -> label:```
- return : 호출자에게 결과를 반환
- throw : 

### Method
- Method 선언
    - 클래스 내부에 선언
    - 필수 요소 3가지
        - 반환 형식 (void, bool, int, float, double)
        - Method 이름
        - 매개변수 목록
    - 결과를 반환할 때 return 문 사용
```
class ClassName
{
    public bool MyMethod(int num)
    {
        // 실행하고자 하는 코드
        return result;
    }
}
```

#### 참조로 매개변수의 인수 전달하기
함수 안에서 변경한 값이, 함수 밖의 변수에도 그대로 반영

-> 인수의 값이 수정되지 않아도 컴파일 에러를 출력하지 않음
```
static void Swap(ref int a, ref int b)
{
    int temp = b;
    b = a;
    a = temp;
}

int a, b = 10, 20;
Swap(a, b);
```

#### 출력 전용 매개변수
함수 안에서 새로운 값을 만들어 함수 밖으로 전달

-> 함수 밖에서 미리 초기화를 할 필요가 없음
```
void GetDouble(int input, out int result)
{
    result = input * 2; // out은 반드시 할당해야 함
}

int b;                 // 초기화 안 해도 됨
GetDouble(10, out b);
Console.WriteLine(b);  // 출력: 20
```

#### 가변길이 인수
개수를 유연하게 조절할 수 있는 인수

- params 키워드와 배열을 이용하여 선언
- 데이터 형식이 같다면 가변길이 인수를 통해 Overloading 대신 사용 가능
```
int Sum(params int[] args)
{
    int sum = 0;
    for (int i = 0; i < args.Length; i++)
    {
        sum += args[i];
    }
    return sum;
}
```

#### 선택적 인수
매소드 선언시 매개변수에 기본값을 할당
```
void MyMethod(int a = 0, int b = 0)
{
    Console.WriteLine("{0}, {1}", a, b);
}
```

### 구조체 struct
- Class는 참조형식, 구조체는 값형식
- 클래스 인스턴스는 가비지 콜렉터가 제거, 구조체 인스턴스는 스택이 자동 제거
```
struct MyStruct
{
    public int MyField1;
    public int MyField2;
    public void MyMethod()
    {
        // ...
    }
}
```

### 튜플 Tuple
- 기본적으로 구조체, 즉 값형식
- 형식 이름 없이 선언하여 사용
- 즉석에서 활용되는 형식을 만들 때 적합
```
var tuple = (123, 789);
```