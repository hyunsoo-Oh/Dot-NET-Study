# WinForms에서 File과 관련된 모든 기능

**Stream**: 출처에 독립적인 바이트 흐름 추상화

**Reader/Writer**: 바이트를 의미 있는 데이터로 해석하는 계층

**Metadata**: 파일 시스템 구조와 정책을 다루는 관리 계층

**Serialization**: 객체 상태를 외부 표현으로 고정하는 기술

**Async/Lock**: I/O 지연과 동시 접근을 제어하는 실행 모델

## 파일 I/O 계층 구조

#### **Stream**: 연속적인 바이트 흐름(byte sequence) 을 추상화한 인터페이스
* 데이터는 의미 없는 바이트열로 취급

* 읽기/쓰기/탐색(Seek) 등 저수준 I/O 제어 담당
* 상위 계층(텍스트, 직렬화, 압축, 암호화)의 공통 기반 파이프라인

#### **Reader/Writer**: Stream 위에서 바이트를 의미 있는 데이터 단위(문자, 기본형) 로 해석·변환하는 계층
* 바이트 ↔ 문자 변환 (Encoding/Decoding)

* 바이트 ↔ 기본 타입(int, double, bool 등) 변환
* 데이터의 형식화(Formating) 와 해석 책임

#### **Metadata**: 데이터 자체가 아닌 파일 시스템 상의 관리 정보와 구조를 다루는 API 집합
*  File / Directory / Path

* 파일/폴더의 생성, 삭제, 이동, 복사
* 파일 크기, 생성/수정 시간, 속성 관리
* 경로 조합 및 플랫폼 의존성 제거

#### **Serialization**: 메모리 내 객체 구조(Object Graph) 를 저장·전송 가능한 외부 표현(Text or Binary) 로 변환
* 객체 상태를 파일/네트워크로 영속화

* 언어·버전·도구 간 데이터 교환
* 구조화된 데이터의 재현성(Reproducibility) 확보

#### Async/Lock (Concurrency I/O): 파일 I/O를 비차단(non-blocking) 으로 수행
* UI/서비스 스레드 블로킹 방지

* 다중 스레드/프로세스 간 파일 접근 충돌 제어
* OS 수준 파일 공유 정책(FileShare) 명시

## 계층별 파일 I/O 시스템 (System.IO)
### 저수준 바이트 제어 (Stream)
```C#

```

### 데이터 직렬화 (Serialization)
```C#

```

### 고급 파일 기능 및 실무 테크닉
```C#

```
