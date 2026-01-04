## 객체지향 Object-Oriented Programming, OOP
#### 코드 내의 모든 것을 객체(Object)로 표현하고자 하는 프로그래밍
프로퍼티, 대리자/이벤트. 리플렉션 & 애트리뷰트
### 클래스 Class
- 클래스 Class
    - 각 형식/클래스 별로 하나만 존재
    - 객체의 필드(변수), 메소드를 정의
- 객체 Object
    - 메모링에 적재된 실체 (무한대 생성 가능)
    - 선언된 데이터 항목에 실제 데이터 저장


**virtual** : 본문 있음, 선택적 재정의 -> override를 위해 필수

```C#
class Animal
{
    // 필드 정의 (private 캡슐화)
    private string _name;
    private string _color;

    // Property 정의
    // 필드(field)”에 접근하기 위한 중간 제어 지점(접근자, Accessor)
    public string Name { get => _name; set => _name = value; }
    public string Color { get; set; }

    // 생성자 정의
    public Animal()
    {
        this._name = ""; this._color = "";
    }
    public Animal(string name, string color)
    {
        this._name = Name; this._color = Color;
    }

    // 소멸자
    ~Animal()
    {
        // Console.WriteLine(Name+"객체 제거하기");
    }

    public virtual void Cry()
    {
        Console.WriteLine("동물 울음소리");
    }
}
Animal kitty = new Animal("kitty", "Black");
// kitty._name = "marry"; // 필드가 public인 경우
kitty.Name = "marry"; // 필드가 private인 경우 (Property)
```

#### 얕은 복사 / 깊은 복사
- 얕은 복사 : 참조를 복사하는 것
    - 클래스는 참조 형식이므로 얕은 복사
- 깊은 복사 : 데이터의 값 전체를 복사하는 것
```C#
Class c1 = new Class(5, 5);
Class c2 = c1; // 얕은 복사
v1.x = 10;
Console.WriteLine(v2.x); // 10
```

#### this 키워드
```C#
class MyClass
{
    int a, b, c;

    public MyClass()
    {
        this.a = 1;
    }
    public MyClass(int b) : this()
    {
        this.b = b;
    }
    public MyClass(int b, int c) :this(b)
    {
        this.c = c;
    }
}
```

#### 상속 Inheritance
```C#
class BaseClass
{
    protected int num;

    public BaseClass(int Number)
    {
        this.num = Number;
    }

    // virtual : 함수의 재정의를 허용
    public virtual int Sum(int a, int b)
    {
        return a + b;
    }
}
class DerivedClass : BaseClass
{
    // private로 선언된 멤버를 제외한 모든 멤버 변수 상속

    public DerivedClass(int Number) : Base(Number)
    {
        // 나머지
    }

    // 다형성 Override
    public override int Sum(int a, int b)
    {
        return a + b + 1;
    }
}
```

### 인터페이스 & 추상클래스
**abstract** : 본문 없음, 반드시 재정의를 해야 함

**virtual** : 본문 있음, 선택적 재정의

#### 인터페이스 Interface
- 해야 할 일 Method만 존재
    - 한정자를 사용하지 않음 (private, public)
    - public virtual를 사용

```C#
interface ILogger
{
    void WriteLog(string message);
    // public virtual void WriteLog(string message);
}

class ConsoleLogger : ILogger // ILogger, Interface1, Interface2
{
    void WriteLog(string message)
    {
        Console.WriteLine($"{message}");
    }
}
```

#### 추상클래스 Abstract
- 공통 상태(필드) + 공통 구현(메서드) + 추상 멤버
    - 멤버 변수 protected
    - 멤버 함수 protected abstract
    - protected virtual도 사용 가능

```C#
abstract class AbstractClass
{
    protected String message;
    protected abstract void WriteLog(String message);
}

class MyClass : AbstractClass
{
    public override void WriteLog(String message)
    {
        Console.WriteLine($"{message}");
    }
}
```
