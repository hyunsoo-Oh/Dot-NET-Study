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
```
class Animal
{
    // 필드 정의 (private 캡슐화)
    private string _name;
    private string _color;

    // Property 정의
    // 필드(field)”에 접근하기 위한 중간 제어 지점(접근자, Accessor)
    public string Name { get => name; set => name = value; }
    public string Color { get; set; }

    // 생성자 정의
    public Animal()
    {
        Name = ""; Color = "";
    }
    public Animal(string name, string color)
    {
        this._name = Name; this._color = Color;
    }

    // 소멸자
    ~Cat()
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

### 인터페이스 & 추상클래스

