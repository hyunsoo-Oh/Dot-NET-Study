# WPF 컨테이너 구조

> 1️⃣ Header + Sidebar + Content  
> 2️⃣ Top Navigation + Content  
> 3️⃣ Card 기반 대시보드 레이아웃  
> 4️⃣ Dialog 중심 구조


## 1️⃣ Header + Sidebar + Content
#### 관리자툴, 모니터링툴, 트레이딩 툴, 장비 제어 프로그램에 적합
```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="60"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="200"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <!-- Header -->
    <Border Grid.Row="0" Grid.ColumnSpan="2"      Background="#2D2D30"/>

    <!-- Sidebar -->
    <StackPanel Grid.Row="1" Grid.Column="0" Background="#1E1E1E"/>

    <!-- Content -->
    <Grid Grid.Row="1" Grid.Column="1"/>
</Grid>
```
## 2️⃣ Top Navigation + Content
#### 메뉴 기반 프로그램 (설정툴, 개발툴)
```xml
<DockPanel>
    <Menu DockPanel.Dock="Top">
        <MenuItem Header="File"/>
        <MenuItem Header="Edit"/>
    </Menu>

    <Grid/>
</DockPanel>
```
## 3️⃣ Card 기반 대시보드 레이아웃

## 4️⃣ Dialog 중심 구조